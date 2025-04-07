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
            pnlNav.SuspendLayout();
            SuspendLayout();
            // 
            // btnUser
            // 
            btnUser.Anchor = AnchorStyles.None;
            btnUser.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUser.Location = new Point(368, 15);
            btnUser.Margin = new Padding(0);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(92, 31);
            btnUser.TabIndex = 1;
            btnUser.Tag = "login";
            btnUser.Text = "User";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += NavButton_User;
            // 
            // btnMenu
            // 
            btnMenu.Anchor = AnchorStyles.None;
            btnMenu.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMenu.Location = new Point(15, 15);
            btnMenu.Margin = new Padding(0);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(92, 31);
            btnMenu.TabIndex = 0;
            btnMenu.Text = "Menu";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += NavButton_Menu;
            // 
            // pnlBody
            // 
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 62);
            pnlBody.Margin = new Padding(0);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(476, 394);
            pnlBody.TabIndex = 1;
            pnlBody.Paint += pnlBody_Paint;
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
            pnlNav.Size = new Size(476, 62);
            pnlNav.TabIndex = 2;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 456);
            Controls.Add(pnlBody);
            Controls.Add(pnlNav);
            Margin = new Padding(2);
            Name = "Main";
            Text = "Nonogram Game";
            pnlNav.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlBody;
        private Button btnUser;
        private Button btnMenu;
        private TableLayoutPanel pnlNav;
    }
}
