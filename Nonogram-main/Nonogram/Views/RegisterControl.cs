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
            string name = tbName.Text;
            string password1 = tbPassword1.Text;
            string password2 = tbPassword2.Text;

            if (!HandleInput(name) || !HandleInput(password1) || !HandleInput(password2))
            {
                MessageBox.Show("Error with inputs", "Error Message");
                return;
            }

            JsonUserDatabase db = new JsonUserDatabase();
            List<User> users = db.GetUsers("../../../Database/Users.json");

            User dbUser = users.Where(u => u.Name == name).FirstOrDefault();

            if (dbUser != null)
            {
                MessageBox.Show(string.Format("User: {0} already exists", name));
                return;
            }

            User user = new User(name, User.HashPassword(password1, password2));
            db.Save(user, "../../../Database/Users.json");
            MessageBox.Show("Succefully created a account");

            // Change to game/menu screen
            Main.ChangeView("login", FindForm().Controls);
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
