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
            btnUser = new Button();
            btnPlay = new Button();
            pnlLayout.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLayout
            // 
            pnlLayout.Anchor = AnchorStyles.None;
            pnlLayout.Controls.Add(btnUser);
            pnlLayout.Controls.Add(btnPlay);
            pnlLayout.Location = new Point(0, 0);
            pnlLayout.Margin = new Padding(0);
            pnlLayout.Name = "pnlLayout";
            pnlLayout.Size = new Size(308, 312);
            pnlLayout.TabIndex = 0;
            // 
            // btnUser
            // 
            btnUser.BackColor = SystemColors.MenuHighlight;
            btnUser.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUser.Location = new Point(62, 170);
            btnUser.Margin = new Padding(2);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(185, 62);
            btnUser.TabIndex = 2;
            btnUser.Text = "Login";
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUser_Click;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = SystemColors.MenuHighlight;
            btnPlay.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlay.Location = new Point(62, 95);
            btnPlay.Margin = new Padding(2);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(185, 62);
            btnPlay.TabIndex = 1;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // MenuControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlLayout);
            Margin = new Padding(0);
            Name = "MenuControl";
            Size = new Size(308, 312);
            pnlLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLayout;
        private Button btnUser;
        private Button btnPlay;
    }
}
