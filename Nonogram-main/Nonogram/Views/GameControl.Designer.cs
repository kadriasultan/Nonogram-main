
namespace Nonogram.Views
{
    partial class GameControl
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
            pnlGameBtns = new TableLayoutPanel();
            pnlSizeChange = new TableLayoutPanel();
            inGridSize = new NumericUpDown();
            btnSubmitSize = new Button();
            lblChange = new Label();
            pnlGame = new Panel();
            pnlGameBtns.SuspendLayout();
            pnlSizeChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inGridSize).BeginInit();
            SuspendLayout();
            // 
            // pnlGameBtns
            // 
            pnlGameBtns.ColumnCount = 2;
            pnlGameBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlGameBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlGameBtns.Controls.Add(pnlSizeChange, 0, 0);
            pnlGameBtns.Dock = DockStyle.Bottom;
            pnlGameBtns.Location = new Point(0, 250);
            pnlGameBtns.Margin = new Padding(0);
            pnlGameBtns.Name = "pnlGameBtns";
            pnlGameBtns.RowCount = 1;
            pnlGameBtns.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pnlGameBtns.Size = new Size(308, 62);
            pnlGameBtns.TabIndex = 0;
            // 
            // pnlSizeChange
            // 
            pnlSizeChange.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pnlSizeChange.ColumnCount = 4;
            pnlSizeChange.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlSizeChange.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 74F));
            pnlSizeChange.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 74F));
            pnlSizeChange.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlSizeChange.Controls.Add(inGridSize, 1, 1);
            pnlSizeChange.Controls.Add(btnSubmitSize, 2, 1);
            pnlSizeChange.Controls.Add(lblChange, 1, 0);
            pnlSizeChange.Location = new Point(0, 1);
            pnlSizeChange.Margin = new Padding(0);
            pnlSizeChange.Name = "pnlSizeChange";
            pnlSizeChange.RowCount = 2;
            pnlSizeChange.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            pnlSizeChange.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlSizeChange.Size = new Size(154, 59);
            pnlSizeChange.TabIndex = 1;
            // 
            // inGridSize
            // 
            inGridSize.Anchor = AnchorStyles.Bottom;
            inGridSize.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            inGridSize.Location = new Point(9, 29);
            inGridSize.Margin = new Padding(0);
            inGridSize.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            inGridSize.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            inGridSize.Name = "inGridSize";
            inGridSize.Size = new Size(59, 40);
            inGridSize.TabIndex = 0;
            inGridSize.Value = new decimal(new int[] { 5, 0, 0, 0 });
            inGridSize.KeyPress += inGridSize_KeyPress;
            // 
            // btnSubmitSize
            // 
            btnSubmitSize.Anchor = AnchorStyles.Bottom;
            btnSubmitSize.Location = new Point(78, 28);
            btnSubmitSize.Margin = new Padding(0);
            btnSubmitSize.Name = "btnSubmitSize";
            btnSubmitSize.Size = new Size(71, 31);
            btnSubmitSize.TabIndex = 1;
            btnSubmitSize.Text = "Speel nu";
            btnSubmitSize.UseVisualStyleBackColor = true;
            btnSubmitSize.Click += btnSubmitSize_Click;
            // 
            // lblChange
            // 
            lblChange.Anchor = AnchorStyles.Bottom;
            lblChange.AutoSize = true;
            pnlSizeChange.SetColumnSpan(lblChange, 2);
            lblChange.Location = new Point(30, 5);
            lblChange.Margin = new Padding(2, 0, 2, 0);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(94, 20);
            lblChange.TabIndex = 2;
            lblChange.Text = "kees de level";
            lblChange.TextAlign = ContentAlignment.MiddleCenter;
            lblChange.Click += lblChange_Click;
            // 
            // pnlGame
            // 
            pnlGame.Dock = DockStyle.Fill;
            pnlGame.Location = new Point(0, 0);
            pnlGame.Margin = new Padding(0);
            pnlGame.Name = "pnlGame";
            pnlGame.Size = new Size(308, 250);
            pnlGame.TabIndex = 1;
            
            // 
            // GameControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlGame);
            Controls.Add(pnlGameBtns);
            Margin = new Padding(0);
            Name = "GameControl";
            Size = new Size(308, 312);
            pnlGameBtns.ResumeLayout(false);
            pnlSizeChange.ResumeLayout(false);
            pnlSizeChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inGridSize).EndInit();
            ResumeLayout(false);
        }

        private void inGridSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PnlGame_Paint_1(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblChange_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TableLayoutPanel pnlGameBtns;
        private Panel pnlGame;
        private NumericUpDown inGridSize;
        private TableLayoutPanel pnlSizeChange;
        private Button btnSubmitSize;
        private Label lblChange;
    }
}
