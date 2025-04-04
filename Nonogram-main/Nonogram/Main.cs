using Nonogram.Views;
using Nonogram.Models;

namespace Nonogram
{
    public partial class Main : Form
    {
        public static User? User = null;
        public Main()
        {
            InitializeComponent();
            InitializeView();

            Main.ChangeNavUser(Controls);
            Main.ChangeView("menu", Controls);
        }

        public static void ChangeView(string control, Control.ControlCollection Controls)
        {
            Control? collectionControl = Controls.Find("pnlBody", false).FirstOrDefault();

            if (collectionControl == null) return;

            for (int i = 0; i < collectionControl.Controls.Count; i++)
            {
                if (collectionControl.Controls[i].Name == control) collectionControl.Controls[i].Visible = true;
                else collectionControl.Controls[i].Visible = false;
            }
        }

        public static void ChangeNavUser(Control.ControlCollection Controls)
        {
            Control? collectionControl = Controls.Find("pnlNav", false).FirstOrDefault();
            if (collectionControl == null) return;

            if (Main.User == null)
            {
                for (int i = 0; i < collectionControl.Controls.Count; i++)
                {
                    Control control = collectionControl.Controls[i];
                    if (control.Name == "lblUser") control.Visible = false;
                    else if (control.Name == "btnUser")
                    {
                        control.Text = "login";
                        control.Tag = "login";
                    }
                }
                return;
            }

            for (int i = 0; i < collectionControl.Controls.Count; i++)
            {
                Control control = collectionControl.Controls[i];
                if (control.Name == "lblUser")
                {
                    control.Visible = true;
                    control.Text = Main.User.Name;
                }
                else if (control.Name == "btnUser")
                {
                    control.Text = "logout";
                    control.Tag = "logout";
                }
            }
        }

        #region Views code
        private void InitializeView()
        {
            menu = new MenuControl();
            login = new LoginControl();
            register = new RegisterControl();
            game = new GameControl();
            SuspendLayout();
            ///
            /// menu
            /// 
            menu.Dock = DockStyle.Fill;
            menu.Location = new Point(0, 0);
            menu.Margin = new Padding(0);
            menu.Name = "menu";
            menu.TabIndex = 0;
            menu.Visible = false;
            ///
            /// login
            ///
            login.Dock = DockStyle.Fill;
            login.Location = new Point(0, 0);
            login.Margin = new Padding(0);
            login.Name = "login";
            login.TabIndex = 0;
            login.Visible = false;
            ///
            /// Register
            ///
            register.Dock = DockStyle.Fill;
            register.Location = new Point(0, 0);
            register.Margin = new Padding(0);
            register.Name = "register";
            register.TabIndex = 0;
            register.Visible = false;
            ///
            /// Game
            /// 
            game.Dock = DockStyle.Fill;
            game.Location = new Point(0, 0);
            game.Margin = new Padding(0);
            game.Name = "game";
            game.TabIndex = 0;
            game.Visible = false;
            ///
            /// Main
            ///
            pnlBody.Controls.Add(menu);
            pnlBody.Controls.Add(login);
            pnlBody.Controls.Add(register);
            pnlBody.Controls.Add(game);
            ResumeLayout(false);
        }

        MenuControl menu;
        LoginControl login;
        RegisterControl register;
        GameControl game;
        #endregion

        private void NavButton_Menu(object sender, EventArgs e)
        {
            Main.ChangeView("menu", Controls);
        }

        private void NavButton_User(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Tag == "logout")
            {
                Main.User = null;
                ChangeNavUser(Controls);
            }
            else if (btn.Tag == "login")
                Main.ChangeView("login", Controls);
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            Update();
        }
    }
}
