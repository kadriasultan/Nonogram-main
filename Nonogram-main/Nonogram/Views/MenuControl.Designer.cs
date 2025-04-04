namespace Nonogram
{
    partial class Main
    {
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
            picLogo = new PictureBox(); // Voeg een PictureBox toe voor de afbeelding
            pnlNav.SuspendLayout();
            SuspendLayout();

            // 
            // btnUser
            // 
            btnUser.Anchor = AnchorStyles.None;
            btnUser.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUser.Location = new Point(599, 25);
            btnUser.Margin = new Padding(0);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(150, 50);
            btnUser.TabIndex = 1;
            btnUser.Tag = "login";
            btnUser.Text = "User";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.BackColor = Color.FromArgb(255, 165, 0); // Oranje achtergrondkleur
            btnUser.ForeColor = Color.White; // Witte tekstkleur
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.MouseEnter += new EventHandler(Button_MouseEnter);
            btnUser.MouseLeave += new EventHandler(Button_MouseLeave);
            btnUser.Click += NavButton_User;

            // 
            // btnMenu
            // 
            btnMenu.Anchor = AnchorStyles.None;
            btnMenu.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMenu.Location = new Point(25, 25);
            btnMenu.Margin = new Padding(0);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(150, 50);
            btnMenu.TabIndex = 0;
            btnMenu.Text = "Menu";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.BackColor = Color.FromArgb(255, 127, 80); // Coral achtergrondkleur
            btnMenu.ForeColor = Color.White; // Witte tekstkleur
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.MouseEnter += new EventHandler(Button_MouseEnter);
            btnMenu.MouseLeave += new EventHandler(Button_MouseLeave);
            btnMenu.Click += NavButton_Menu;

            // 
            // pnlBody
            // 
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 100);
            pnlBody.Margin = new Padding(0);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(774, 629);
            pnlBody.TabIndex = 1;
            pnlBody.BackColor = Color.FromArgb(255, 159, 0); // Nieuwe oranje achtergrondkleur

            // 
            // pnlNav
            // 
            pnlNav.ColumnCount = 3;
            pnlNav.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            pnlNav.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlNav.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            pnlNav.Controls.Add(btnMenu, 0, 0);
            pnlNav.Controls.Add(btnUser, 2, 0);
            pnlNav.Controls.Add(lblUser, 1, 0);
            pnlNav.Dock = DockStyle.Top;
            pnlNav.Location = new Point(0, 0);
            pnlNav.Margin = new Padding(0);
            pnlNav.Name = "pnlNav";
            pnlNav.RowCount = 1;
            pnlNav.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlNav.Size = new Size(774, 100);
            pnlNav.TabIndex = 2;
            pnlNav.BackColor = Color.FromArgb(255, 69, 0); // Dark Orange voor de navigatie

            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Right;
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI Semibold", 13.875F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUser.Location = new Point(454, 25);
            lblUser.Margin = new Padding(0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(120, 50);
            lblUser.TabIndex = 2;
            lblUser.Text = "label1";
            lblUser.ForeColor = Color.White; // Witte tekstkleur voor het label

            // 
            // picLogo
            // 
            picLogo = new PictureBox(); // Maak een nieuwe PictureBox
            picLogo.Location = new Point(300, 100); // Zet de locatie
            picLogo.Size = new Size(200, 200); // Stel de grootte in
            picLogo.SizeMode = PictureBoxSizeMode.Zoom; // Zorg ervoor dat de afbeelding proportioneel schaalt
            picLogo.ImageLocation = "https://mathequalslove.net/wp-content/uploads/2015/04/nonogram-puzzles-featured-image-1024x1024.jpg"; // Zet de afbeelding URL hier
            // 

            // Main
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 729);
            Controls.Add(pnlBody);
            Controls.Add(pnlNav);
            Name = "Main";
            Text = "Nonogram Game";
            pnlNav.ResumeLayout(false);
            pnlNav.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlBody;
        private Button btnUser;
        private Button btnMenu;
        private TableLayoutPanel pnlNav;
        private Label lblUser;
        private PictureBox picLogo; // Declare the PictureBox

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
