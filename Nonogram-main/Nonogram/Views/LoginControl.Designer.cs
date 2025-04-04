namespace Nonogram.Views
{
    partial class LoginControl
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
            tbName = new TextBox();
            tbPassword = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            pnlLayout = new Panel();
            lblLogin = new Label();
            pnlLayout.SuspendLayout();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbName.Font = new Font("Segoe UI", 12F);
            tbName.Location = new Point(50, 100);
            tbName.Margin = new Padding(0);
            tbName.MaxLength = 50;
            tbName.Name = "tbName";
            tbName.PlaceholderText = "Name";
            tbName.Size = new Size(400, 50);
            tbName.TabIndex = 0;
            tbName.TextAlign = HorizontalAlignment.Center;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPassword.Font = new Font("Segoe UI", 12F);
            tbPassword.Location = new Point(50, 175);
            tbPassword.Margin = new Padding(0);
            tbPassword.MaxLength = 50;
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.PlaceholderText = "Password";
            tbPassword.Size = new Size(400, 50);
            tbPassword.TabIndex = 1;
            tbPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.Location = new Point(50, 250);
            btnLogin.Margin = new Padding(0);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(400, 50);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegister.Location = new Point(50, 325);
            btnRegister.Margin = new Padding(0);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(400, 50);
            btnRegister.TabIndex = 3;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // pnlLayout
            // 
            pnlLayout.Anchor = AnchorStyles.None;
            pnlLayout.Controls.Add(lblLogin);
            pnlLayout.Controls.Add(tbName);
            pnlLayout.Controls.Add(tbPassword);
            pnlLayout.Controls.Add(btnLogin);
            pnlLayout.Controls.Add(btnRegister);
            pnlLayout.Location = new Point(0, 0);
            pnlLayout.Margin = new Padding(0);
            pnlLayout.Name = "pnlLayout";
            pnlLayout.Size = new Size(500, 500);
            pnlLayout.TabIndex = 4;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblLogin.Location = new Point(164, 5);
            lblLogin.Margin = new Padding(0);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(172, 72);
            lblLogin.TabIndex = 4;
            lblLogin.Text = "Login";
            // 
            // LoginControl
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlLayout);
            Margin = new Padding(0);
            Name = "LoginControl";
            Size = new Size(500, 500);
            pnlLayout.ResumeLayout(false);
            pnlLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox tbName;
        private TextBox tbPassword;
        private Button btnLogin;
        private Button btnRegister;
        private Panel pnlLayout;
        private Label lblLogin;
    }
}
