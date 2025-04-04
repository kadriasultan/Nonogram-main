namespace Nonogram.Views
{
    partial class MenuControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlLayout = new Panel();
            btnScoreboard = new Button();
            btnUser = new Button();
            btnPlay = new Button();
            lblMenu = new Label();
            pnlLayout.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLayout
            // 
            pnlLayout.Anchor = AnchorStyles.None;
            pnlLayout.Controls.Add(btnScoreboard);
            pnlLayout.Controls.Add(btnUser);
            pnlLayout.Controls.Add(btnPlay);
            pnlLayout.Controls.Add(lblMenu);
            pnlLayout.Location = new Point(0, 0);
            pnlLayout.Margin = new Padding(0);
            pnlLayout.Name = "pnlLayout";
            pnlLayout.Size = new Size(500, 500);
            pnlLayout.TabIndex = 0;
            // 
            // btnScoreboard
            // 
            btnScoreboard.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnScoreboard.Location = new Point(100, 392);
            btnScoreboard.Name = "btnScoreboard";
            btnScoreboard.Size = new Size(300, 100);
            btnScoreboard.TabIndex = 3;
            btnScoreboard.Text = "Scoreboard";
            btnScoreboard.UseVisualStyleBackColor = true;
            // 
            // btnUser
            // 
            btnUser.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUser.Location = new Point(100, 272);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(300, 100);
            btnUser.TabIndex = 2;
            btnUser.Text = "Login";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += btnUser_Click;
            // 
            // btnPlay
            // 
            btnPlay.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlay.Location = new Point(100, 152);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(300, 100);
            btnPlay.TabIndex = 1;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMenu.Location = new Point(93, 5);
            lblMenu.Margin = new Padding(0);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new Size(314, 128);
            lblMenu.TabIndex = 0;
            lblMenu.Text = "Menu";
            // 
            // MenuControl
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlLayout);
            Margin = new Padding(0);
            Name = "MenuControl";
            Size = new Size(500, 500);
            pnlLayout.ResumeLayout(false);
            pnlLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLayout;
        private Label lblMenu;
        private Button btnScoreboard;
        private Button btnUser;
        private Button btnPlay;
    }
}
