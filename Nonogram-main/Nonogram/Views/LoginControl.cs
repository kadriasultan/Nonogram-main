using System;
using System.Linq;
using System.Windows.Forms;
using Nonogram.Models;
using Nonogram.Services;

namespace Nonogram.Views
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Main.ChangeView("register", FindForm().Controls);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string password = tbPassword.Text;

            if (!ValidateInputs(name, password))
            {
                MessageBox.Show("Please enter both username and password", "Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Gebruik UserService in plaats van JsonUserDatabase
                var users = UserService.LoadUsers();
                var user = users.FirstOrDefault(u => u.Name.Equals(name, StringComparison.Ordinal));

                if (user == null)
                {
                    MessageBox.Show($"User '{name}' not found", "Login Failed",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!User.VerifyPassword(password, user.Password))
                {
                    MessageBox.Show("Incorrect password", "Login Failed",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Succesvol ingelogd
                Main.User = user;
                Main.ChangeNavUser(FindForm().Controls);
                Main.ChangeView("menu", FindForm().Controls);

                MessageBox.Show($"Welcome back, {user.Name}!", "Login Successful",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs(string username, string password)
        {
            return !string.IsNullOrWhiteSpace(username) &&
                   !string.IsNullOrWhiteSpace(password);
        }

        private void pnlLayout_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}