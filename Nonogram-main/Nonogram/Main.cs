using Nonogram.Views;
using Nonogram.Models;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Nonogram
{
    public partial class Main : Form
    {
        private readonly Color PrimaryColor = Color.FromArgb(44, 62, 80);
        private readonly Color SecondaryColor = Color.FromArgb(52, 152, 219);
        private readonly Color LightBackground = Color.FromArgb(236, 240, 241);
        private readonly Color DarkText = Color.FromArgb(44, 62, 80);

        public static User? User = null;
        private Label lblWelcome;
        private PictureBox logoPictureBox;
        private MenuControl menu;
        private LoginControl login;
        private RegisterControl register;
        private GameControl game;

        public Main()
        {
            InitializeComponent();
            ApplyProfessionalStyling();
            InitializeWelcomeSection();
            InitializeView();

            ChangeNavUser(Controls);
            ChangeView("menu", Controls);
        }

        private void ApplyProfessionalStyling()
        {
            this.BackColor = LightBackground;
            this.Font = new Font("Segoe UI", 9);
            this.Text = "Nonogram Puzzle";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(400, 400);
            Resize += Main_Resize;

            pnlNav.BackColor = PrimaryColor;
            pnlNav.Padding = new Padding(3);
            pnlNav.Height = 40;

            foreach (Control ctrl in pnlNav.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = SecondaryColor;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                    btn.Padding = new Padding(8, 3, 8, 3);
                    btn.Cursor = Cursors.Hand;
                    btn.Margin = new Padding(2);
                    btn.Height = 40;

                    if (btn.Name == "btnMenu")
                    {
                        btn.Text = "HOME";
                    }
                    else if (btn.Name == "btnUser")
                    {
                        btn.Text = (User == null) ? "LOGIN" : "LOGOUT";
                        btn.Tag = (User == null) ? "login" : "logout";
                    }
                }
                else if (ctrl is Label lbl)
                {
                    lbl.ForeColor = Color.White;
                    lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }


            pnlBody.BackColor = LightBackground;
            pnlBody.Padding = new Padding(10, 80, 10, 10);
        }

        private void InitializeWelcomeSection()
        {
            lblWelcome = new Label
            {
                Text = "WELKOM BIJ NONOGRAM",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = PrimaryColor,
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                Name = "lblWelcome",
                BackColor = Color.Transparent,
                Margin = new Padding(0, 20, 0, 10)
            };

            logoPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Top,
                Name = "logoPictureBox",
                Height = CalculateLogoHeight(),
                Margin = new Padding(0, 50, 0, 0),
                BackColor = Color.Transparent
            };

            try
            {
                if (Properties.Resources.nono != null)
                {
                    using (var ms = new MemoryStream(Properties.Resources.nono))
                    {
                        logoPictureBox.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }

            pnlBody.Controls.Add(logoPictureBox);
            pnlBody.Controls.Add(lblWelcome);
        }

        private int CalculateLogoHeight()
        {
            int baseHeight = 80;
            int formHeight = this.ClientSize.Height;

            if (formHeight > 800) return 200;
            else if (formHeight > 600) return 150;
            else if (formHeight > 400) return 100;
            else return baseHeight;
        }

        private int CalculateButtonHeight()
        {
            int formHeight = this.ClientSize.Height;

            if (formHeight > 800) return 50;
            else if (formHeight > 600) return 45;
            else if (formHeight > 400) return 40;
            else return 35;
        }

        private float CalculateButtonFontSize()
        {
            int formHeight = this.ClientSize.Height;

            if (formHeight > 800) return 10.0f;
            else if (formHeight > 600) return 9.5f;
            else if (formHeight > 400) return 9.0f;
            else return 8.5f;
        }

        public static void ChangeView(string control, Control.ControlCollection controls)
        {
            var bodyPanel = controls.Find("pnlBody", false).FirstOrDefault();
            if (bodyPanel == null) return;


            if (control == "game" && User == null)
            {
                return;
            }

            bool showWelcome = (control == "menu");
            var welcomeLabel = bodyPanel.Controls.Find("lblWelcome", false).FirstOrDefault();
            var logo = bodyPanel.Controls.Find("logoPictureBox", false).FirstOrDefault();

            if (welcomeLabel != null) welcomeLabel.Visible = showWelcome;
            if (logo != null) logo.Visible = showWelcome;

            foreach (Control ctrl in bodyPanel.Controls)
            {
                if (ctrl is UserControl view)
                {
                    view.Visible = (view.Name == control);
                }
            }
        }

        public static void ChangeNavUser(Control.ControlCollection controls)
        {
            var navPanel = controls.Find("pnlNav", false).FirstOrDefault();
            if (navPanel == null) return;

            foreach (Control ctrl in navPanel.Controls)
            {
                if (ctrl.Name == "lblUser")
                {
                    ctrl.Visible = (User != null);
                    if (User != null) ctrl.Text = User.Name.ToUpper();
                }
                else if (ctrl.Name == "btnUser")
                {
                    ctrl.Text = (User == null) ? "LOGIN" : "LOGOUT";
                    ctrl.Tag = (User == null) ? "login" : "logout";
                }
            }
        }

        private void InitializeView()
        {
            InitializeMenuControl();
            InitializeLoginControl();
            InitializeRegisterControl();
            InitializeGameControl();

            pnlBody.Controls.Add(menu);
            pnlBody.Controls.Add(login);
            pnlBody.Controls.Add(register);
            pnlBody.Controls.Add(game);
        }

        private void InitializeMenuControl()
        {
            menu = new MenuControl
            {
                Dock = DockStyle.Fill,
                Name = "menu",
                Visible = false
            };

            var playButton = menu.Controls.Find("btnPlay", true).FirstOrDefault() as Button;
            if (playButton != null)
            {
                playButton.Click += (s, e) =>
                {
                    if (User == null)
                    {
                        MessageBox.Show("Je moet ingelogd zijn om te kunnen spelen.", "Niet ingelogd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ChangeView("game", this.Controls);
                };
            }

            foreach (Control ctrl in menu.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = SecondaryColor;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.ForeColor = DarkText;
                    btn.Font = new Font("Segoe UI", CalculateButtonFontSize(), FontStyle.Bold);
                    btn.Padding = new Padding(10, 5, 10, 5);
                    btn.Height = CalculateButtonHeight();
                    btn.Margin = new Padding(0, 5, 0, 5);
                    btn.Cursor = Cursors.Hand;
                }
            }
        }

        private void InitializeLoginControl()
        {
            login = new LoginControl
            {
                Dock = DockStyle.Fill,
                Name = "login",
                Visible = false
            };
        }

        private void InitializeRegisterControl()
        {
            register = new RegisterControl
            {
                Dock = DockStyle.Fill,
                Name = "register",
                Visible = false
            };
        }

        private void InitializeGameControl()
        {
            game = new GameControl
            {
                Dock = DockStyle.Fill,
                Name = "game",
                Visible = false
            };
        }

        private void NavButton_Menu(object sender, EventArgs e)
        {
            ChangeView("menu", Controls);
        }

        private void NavButton_User(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Tag?.ToString() == "logout")
                {
                    User = null;
                    ChangeNavUser(Controls);
                    ChangeView("menu", Controls);
                }
                else
                {
                    ChangeView("login", Controls);
                }
            }
        }

        private void Main_Resize(object? sender, EventArgs e)
        {
            var logo = pnlBody.Controls.OfType<PictureBox>().FirstOrDefault(p => p.Name == "logoPictureBox");
            if (logo != null)
            {
                logo.Height = CalculateLogoHeight();
            }

            var menuControl = pnlBody.Controls.OfType<MenuControl>().FirstOrDefault();
            if (menuControl != null && menuControl.Visible)
            {
                foreach (Control ctrl in menuControl.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        btn.Height = CalculateButtonHeight();
                        btn.Font = new Font("Segoe UI", CalculateButtonFontSize(), FontStyle.Bold);
                    }
                }
            }
        }

        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
