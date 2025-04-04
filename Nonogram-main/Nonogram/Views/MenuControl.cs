using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nonogram.Views
{
    public partial class MenuControl : UserControl
    {
        // Kleuren voor de knoppen
        private readonly Color NormalColor = Color.FromArgb(52, 152, 219);
        private readonly Color HoverColor = Color.FromArgb(41, 128, 185);
        private readonly Color TextColor = Color.White;

        // Oorspronkelijke button properties
        private Size originalPlayButtonSize;
        private Size originalUserButtonSize;
        private Point originalPlayButtonLocation;
        private Point originalUserButtonLocation;

        public MenuControl()
        {
            InitializeComponent();
            InitializeComponentLayout();
            InitializeButtonProperties();
            SetupButtonEvents();
        }

        private void InitializeComponentLayout()
        {
            // Pas de verticale positie van de knoppen aan
            int verticalOffset = 70; // Verplaats knoppen 100 pixels naar beneden

            btnPlay.Location = new Point(btnPlay.Location.X, btnPlay.Location.Y + verticalOffset);
            btnUser.Location = new Point(btnUser.Location.X, btnUser.Location.Y + verticalOffset);

            // Maak de knoppen groter
            btnPlay.Size = new Size(200, 60);
            btnUser.Size = new Size(200, 60);

            // Pas de tekstgrootte aan
            btnPlay.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnUser.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        }

        private void InitializeButtonProperties()
        {
            // Bewaar de originele properties van de knoppen
            originalPlayButtonSize = btnPlay.Size;
            originalUserButtonSize = btnUser.Size;
            originalPlayButtonLocation = btnPlay.Location;
            originalUserButtonLocation = btnUser.Location;

            // Stel basis styling in voor beide knoppen
            StyleButton(btnPlay);
            StyleButton(btnUser);
        }

        private void StyleButton(Button button)
        {
            button.BackColor = NormalColor;
            button.ForeColor = TextColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void SetupButtonEvents()
        {
            // Voeg events toe voor btnPlay
            btnPlay.MouseEnter += (sender, e) => Button_MouseEnter(btnPlay, originalPlayButtonSize, originalPlayButtonLocation);
            btnPlay.MouseLeave += (sender, e) => Button_MouseLeave(btnPlay, originalPlayButtonSize, originalPlayButtonLocation);

            // Voeg events toe voor btnUser
            btnUser.MouseEnter += (sender, e) => Button_MouseEnter(btnUser, originalUserButtonSize, originalUserButtonLocation);
            btnUser.MouseLeave += (sender, e) => Button_MouseLeave(btnUser, originalUserButtonSize, originalUserButtonLocation);
        }

        private void Button_MouseEnter(Button btn, Size originalSize, Point originalLocation)
        {
            const int sizeIncrease = 12; // Grotere toename bij hover

            btn.BackColor = HoverColor;
            btn.Size = new Size(originalSize.Width + sizeIncrease, originalSize.Height + sizeIncrease);
            btn.Location = new Point(originalLocation.X - sizeIncrease / 2, originalLocation.Y);
            btn.Font = new Font("Segoe UI", 14, FontStyle.Bold); // Grotere tekst bij hover
            btn.BringToFront();
        }

        private void Button_MouseLeave(Button btn, Size originalSize, Point originalLocation)
        {
            btn.BackColor = NormalColor;
            btn.Size = originalSize;
            btn.Location = originalLocation;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Terug naar normale tekstgrootte
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Main.ChangeView("login", FindForm().Controls);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Main.ChangeView("game", FindForm().Controls);
        }

        private void lblMenu_Click(object sender, EventArgs e)
        {
            // Event handler voor label klik (indien nodig)
        }
    }
}