using Nonogram.Views;
using Nonogram.Models;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Nonogram
{
    public partial class Main : Form
    {
        // Professional color palette
        private readonly Color PrimaryColor = Color.FromArgb(44, 62, 80);
        private readonly Color SecondaryColor = Color.FromArgb(52, 152, 219);
        private readonly Color LightBackground = Color.FromArgb(236, 240, 241);
        private readonly Color DarkText = Color.FromArgb(44, 62, 80);

        public static User? User = null;
        private Label lblWelcome;
        private PictureBox logoPictureBox;

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
            // Main form styling
            this.BackColor = LightBackground;
            this.Font = new Font("Segoe UI", 9);
            this.Text = "Nonogram Puzzle";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(400, 400); // Smaller minimum size
            this.Resize += Main_Resize; // Add resize event handler

            // Navigation panel
            pnlNav.BackColor = PrimaryColor;
            pnlNav.Padding = new Padding(3); // Reduced padding
            pnlNav.Height = 40; // Smaller navigation bar

            // Style navigation buttons
            foreach (Control ctrl in pnlNav.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = SecondaryColor;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 9, FontStyle.Bold); // Smaller font
                    btn.Padding = new Padding(8, 3, 8, 3); // Reduced padding
                    btn.Cursor = Cursors.Hand;
                    btn.Margin = new Padding(2); // Reduced margin
                    btn.Height = 30; // Smaller buttons
                }
                else if (ctrl is Label lbl)
                {
                    lbl.ForeColor = Color.White;
                    lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold); // Smaller font
                }
            }

            // Body panel
            pnlBody.BackColor = LightBackground;
            pnlBody.Padding = new Padding(10); // Reduced padding
        }

        private void InitializeWelcomeSection()
        {
            // Welcome label - smaller and more compact
            lblWelcome = new Label
            {
                Text = "WELKOM BIJ NONOGRAM",
                Font = new Font("Segoe UI", 14, FontStyle.Bold), // Smaller font
                ForeColor = PrimaryColor,
                Dock = DockStyle.Top,
                Height = 40, // Smaller height
                TextAlign = ContentAlignment.MiddleCenter,
                Name = "lblWelcome",
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, 10) // Reduced margin
            };

            // Logo/image - size will be adjusted dynamically
            logoPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Top,
                Name = "logoPictureBox",
                Height = CalculateLogoHeight(), // Initial height based on form size
                Margin = new Padding(0, 0, 0, 10), // Reduced margin
                BackColor = Color.Transparent
            };

            try
            {
                // Load image from resources
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

            // Add controls to panel (logo first, then label)
            pnlBody.Controls.Add(logoPictureBox);
            pnlBody.Controls.Add(lblWelcome);
        }

        private int CalculateLogoHeight()
        {
            // Calculate logo height based on form height
            int baseHeight = 80; // Default height for small screens
            int formHeight = this.ClientSize.Height;

            if (formHeight > 800)
                return 200; // Large screens
            else if (formHeight > 600)
                return 150; // Medium-large screens
            else if (formHeight > 400)
                return 100; // Medium screens
            else
                return baseHeight; // Small screens
        }

        public static void ChangeView(string control, Control.ControlCollection controls)
        {
            var bodyPanel = controls.Find("pnlBody", false).FirstOrDefault();
            if (bodyPanel == null) return;

            // Show/hide welcome section only for menu
            bool showWelcome = (control == "menu");
            var welcomeLabel = bodyPanel.Controls.Find("lblWelcome", false).FirstOrDefault();
            var logo = bodyPanel.Controls.Find("logoPictureBox", false).FirstOrDefault();

            if (welcomeLabel != null) welcomeLabel.Visible = showWelcome;
            if (logo != null) logo.Visible = showWelcome;

            // Show/hide views
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

        #region Views Initialization
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
            menu = new MenuControl();
            menu.Dock = DockStyle.Fill;
            menu.Name = "menu";
            menu.Visible = false;

            // Style menu buttons - smaller for small screens
            foreach (Control ctrl in menu.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = SecondaryColor;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.ForeColor = DarkText;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Smaller font
                    btn.Padding = new Padding(10, 5, 10, 5); // Reduced padding
                    btn.Height = 40; // Smaller height
                    btn.Margin = new Padding(0, 5, 0, 5); // Reduced margin
                    btn.Cursor = Cursors.Hand;
                }
            }
        }

        private void InitializeLoginControl()
        {
            login = new LoginControl();
            login.Dock = DockStyle.Fill;
            login.Name = "login";
            login.Visible = false;
        }

        private void InitializeRegisterControl()
        {
            register = new RegisterControl();
            register.Dock = DockStyle.Fill;
            register.Name = "register";
            register.Visible = false;
        }

        private void InitializeGameControl()
        {
            game = new GameControl();
            game.Dock = DockStyle.Fill;
            game.Name = "game";
            game.Visible = false;
        }

        private MenuControl menu;
        private LoginControl login;
        private RegisterControl register;
        private GameControl game;
        #endregion

        #region Event Handlers
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

        private void Main_Resize(object sender, EventArgs e)
        {
            // Update logo size when form is resized
            var logo = pnlBody.Controls.Find("logoPictureBox", false).FirstOrDefault();
            if (logo != null)
            {
                logo.Height = CalculateLogoHeight();
            }
        }
        #endregion
    }
}