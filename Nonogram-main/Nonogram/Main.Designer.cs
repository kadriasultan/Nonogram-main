namespace Nonogram
{
    partial class Main
    {
        private PictureBox picLogo;

        private void InitializeComponent()
        {
            btnUser = new Button();
            btnMenu = new Button();
            pnlBody = new Panel();
            pnlNav = new TableLayoutPanel();
            lblUser = new Label();
            pnlNav.SuspendLayout();
            SuspendLayout();

            // Voeg de PictureBox toe
            picLogo = new PictureBox(); // Maak een nieuwe PictureBox
            picLogo.Location = new Point(300, 100); // Zet de locatie van de afbeelding
            picLogo.Size = new Size(200, 200); // Stel de grootte in van de afbeelding
            picLogo.SizeMode = PictureBoxSizeMode.Zoom; // Zorg ervoor dat de afbeelding proportioneel schaalt

            // Voeg de PictureBox toe aan pnlBody
            pnlBody.Controls.Add(picLogo);

            // Laad de afbeelding vanaf een lokaal bestand
            string imagePath = @"C:\Users\kadri\Desktop\Nonogram-main\nonogram-puzzles-featured-image.jpg; // Pad naar je lokale afbeelding

            try
            {
                picLogo.Image = Image.FromFile(imagePath); // Laad de afbeelding van het bestand
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden bij het laden van de afbeelding: " + ex.Message);
            }

            // Rest van je code...
            // Hier wordt je originele code verder uitgevoerd (zoals knoppen en panels instellen)
        }

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUser = new Button();
            btnMenu = new Button();
            pnlBody = new Panel();
            pnlNav = new TableLayoutPanel();
            lblUser = new Label();

            pnlNav.SuspendLayout();
            SuspendLayout();

            // Code voor knoppen en andere UI-elementen blijft hetzelfde
            // Voorbeeld voor de btnUser en btnMenu zoals je ze al hebt.

            // Verander de achtergrond van de panel en knoppen
            pnlBody.BackColor = Color.FromArgb(255, 159, 0); // Oranjekleur voor de achtergrond
            pnlNav.BackColor = Color.FromArgb(255, 69, 0);  // Donkeroranje voor de navigatiebalk

            // Voeg de PictureBox opnieuw toe in de pnlBody

            // Voeg je knoppen en labels toe zoals je dat eerder hebt gedaan
        }

        #endregion
        private Panel pnlBody;
        private Button btnUser;
        private Button btnMenu;
        private TableLayoutPanel pnlNav;
        private Label lblUser;

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(255, 140, 0); // Orange Red bij hover
            btn.ForeColor = Color.White; // Witte tekstkleur bij hover
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(255, 165, 0); // Terug naar originele oranje
            btn.ForeColor = Color.White; // Terug naar originele witte tekstkleur
        }

    }

}
