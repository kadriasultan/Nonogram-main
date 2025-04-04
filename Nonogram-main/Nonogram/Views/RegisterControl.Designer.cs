namespace Nonogram.Views
{
    partial class RegisterControl
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
            btnLogin = new Button();
            btnRegister = new Button();
            tbPassword2 = new TextBox();
            tbPassword1 = new TextBox();
            tbName = new TextBox();
            lblRegister = new Label();
            pnlLayout.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLayout
            // 
            pnlLayout.Anchor = AnchorStyles.None;
            pnlLayout.BackColor = SystemColors.Control;
            pnlLayout.Controls.Add(btnLogin);
            pnlLayout.Controls.Add(btnRegister);
            pnlLayout.Controls.Add(tbPassword2);
            pnlLayout.Controls.Add(tbPassword1);
            pnlLayout.Controls.Add(tbName);
            pnlLayout.Controls.Add(lblRegister);
            pnlLayout.Location = new Point(0, 0);
            pnlLayout.Margin = new Padding(0);
            pnlLayout.Name = "pnlLayout";
            pnlLayout.Size = new Size(500, 500);
            pnlLayout.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.Location = new Point(50, 400);
            btnLogin.Margin = new Padding(0);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(400, 50);
            btnLogin.TabIndex = 10;
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
            btnRegister.TabIndex = 9;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // tbPassword2
            // 
            tbPassword2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPassword2.Font = new Font("Segoe UI", 12F);
            tbPassword2.Location = new Point(50, 250);
            tbPassword2.Margin = new Padding(0);
            tbPassword2.MaxLength = 50;
            tbPassword2.Name = "tbPassword2";
            tbPassword2.PasswordChar = '*';
            tbPassword2.PlaceholderText = "Confirm Password";
            tbPassword2.Size = new Size(400, 50);
            tbPassword2.TabIndex = 8;
            tbPassword2.TextAlign = HorizontalAlignment.Center;
            // 
            // tbPassword1
            // 
            tbPassword1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPassword1.Font = new Font("Segoe UI", 12F);
            tbPassword1.Location = new Point(50, 175);
            tbPassword1.Margin = new Padding(0);
            tbPassword1.MaxLength = 50;
            tbPassword1.Name = "tbPassword1";
            tbPassword1.PasswordChar = '*';
            tbPassword1.PlaceholderText = "Password";
            tbPassword1.Size = new Size(400, 50);
            tbPassword1.TabIndex = 7;
            tbPassword1.TextAlign = HorizontalAlignment.Center;
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
            tbName.TabIndex = 6;
            tbName.TextAlign = HorizontalAlignment.Center;
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblRegister.Location = new Point(132, 0);
            lblRegister.Margin = new Padding(0);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(236, 72);
            lblRegister.TabIndex = 5;
            lblRegister.Text = "Register";
            // 
            // RegisterControl
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlLayout);
            Margin = new Padding(0);
            Name = "RegisterControl";
            Size = new Size(500, 500);
            pnlLayout.ResumeLayout(false);
            pnlLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLayout;
        private Label lblRegister;
        private TextBox tbPassword2;
        private TextBox tbPassword1;
        private TextBox tbName;
        private Button btnLogin;
        private Button btnRegister;
    }
}
