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
            pnlNav = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            Play = new Button();
            button1 = new Button();
            pnlNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnUser
            // 
            btnUser.Anchor = AnchorStyles.None;
            btnUser.BackColor = SystemColors.MenuHighlight;
            btnUser.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUser.Location = new Point(426, 15);
            btnUser.Margin = new Padding(0);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(92, 31);
            btnUser.TabIndex = 1;
            btnUser.Tag = "login";
            btnUser.Text = "Login";
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += NavButton_User;
            // 
            // btnMenu
            // 
            btnMenu.Anchor = AnchorStyles.None;
            btnMenu.BackColor = SystemColors.MenuHighlight;
            btnMenu.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMenu.Location = new Point(15, 15);
            btnMenu.Margin = new Padding(0);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(92, 31);
            btnMenu.TabIndex = 0;
            btnMenu.Text = "Home";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += NavButton_Menu;
            // 
            // pnlNav
            // 
            pnlNav.ColumnCount = 3;
            pnlNav.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 123F));
            pnlNav.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlNav.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 123F));
            pnlNav.Controls.Add(btnMenu, 0, 0);
            pnlNav.Controls.Add(btnUser, 2, 0);
            pnlNav.Dock = DockStyle.Top;
            pnlNav.Location = new Point(0, 0);
            pnlNav.Margin = new Padding(0);
            pnlNav.Name = "pnlNav";
            pnlNav.RowCount = 1;
            pnlNav.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlNav.Size = new Size(534, 62);
            pnlNav.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = Properties.Resources.nonogram_puzzles_featured_image;
            pictureBox1.Location = new Point(76, 112);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(363, 172);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Play
            // 
            Play.Anchor = AnchorStyles.Top;
            Play.BackColor = SystemColors.MenuHighlight;
            Play.Location = new Point(215, 310);
            Play.Name = "Play";
            Play.Size = new Size(94, 29);
            Play.TabIndex = 4;
            Play.Text = "Play";
            Play.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.BackColor = SystemColors.MenuHighlight;
            button1.Location = new Point(215, 369);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 456);
            Controls.Add(button1);
            Controls.Add(Play);
            Controls.Add(pictureBox1);
            Controls.Add(pnlNav);
            Margin = new Padding(2);
            Name = "Main";
            Text = "Nonogram Game";
            pnlNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnUser;
        private Button btnMenu;
        private TableLayoutPanel pnlNav;
        private PictureBox pictureBox1;
        private Button Play;
        private Button button1;
    }
}
