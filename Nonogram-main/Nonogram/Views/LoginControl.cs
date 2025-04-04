using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nonogram.Models;
using Nonogram.Database;

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

            if (!HandleInput(name) || !HandleInput(password))
            {
                MessageBox.Show("Error with inputs", "Error Message");
                return;
            }

            JsonUserDatabase db = new JsonUserDatabase();
            List<User> users = db.GetUsers("../../../Database/Users.json");
            User user = users.Where(u => u.Name == name).FirstOrDefault();

            if (user == null)
            {
                MessageBox.Show(string.Format("Name: {0} does not match any user", name));
                return;
            }

            if (!User.VerifyPassword(password, user.Password))
            {
                MessageBox.Show("Password does not match user");
                return;
            }
            //User.VerifyPassword(password);
            MessageBox.Show("Succefully logged in");
            Main.User = user;
            Main.ChangeNavUser(FindForm().Controls);
            Main.ChangeView("menu", FindForm().Controls);
        }

        // Make Input handler class
        private bool HandleInput(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;
            return true;
        }
    }
}
