using System;
using System.Linq;
using System.Windows.Forms;
using Nonogram.Models;
using Nonogram.Services;

namespace Nonogram.Views
{
    public partial class RegisterControl : UserControl
    {
        public RegisterControl()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Main.ChangeView("login", FindForm().Controls);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = tbName.Text.Trim();
            string password1 = tbPassword1.Text;
            string password2 = tbPassword2.Text;

            if (!ValidateInputs(name, password1, password2))
            {
                MessageBox.Show("Please fill in all fields", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Load existing users
                var users = UserService.LoadUsers();

                // Check if username already exists
                if (users.Any(u => u.Name.Equals(name, StringComparison.Ordinal)))
                {
                    MessageBox.Show($"Username '{name}' is already taken", "Registration Failed",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verify password match
                if (password1 != password2)
                {
                    MessageBox.Show("Passwords do not match", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create and save new user
                var hashedPassword = User.HashPassword(password1, password2);
                var newUser = new User(name, hashedPassword);

                users.Add(newUser);
                UserService.SaveUsers(users);

                MessageBox.Show("Account created successfully!\nYou can now log in.", "Success",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Return to login screen
                Main.ChangeView("login", FindForm().Controls);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed: {ex.Message}", "Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs(string username, string password1, string password2)
        {
            return !string.IsNullOrWhiteSpace(username) &&
                   !string.IsNullOrWhiteSpace(password1) &&
                   !string.IsNullOrWhiteSpace(password2);
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {

        }

        private void pnlLayout_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}