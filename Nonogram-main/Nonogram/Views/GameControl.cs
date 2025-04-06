using Nonogram.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nonogram.Views
{
    public partial class GameControl : UserControl
    {
        private Game _game;
        private Font font;
        private readonly FontFamily fontFamily = new("Arial");
        private bool _showCompletionMessage = true;

        public event Action? GameCompleted;

        public GameControl()
        {
            InitializeComponent();
            DoubleBuffered = true;

            pnlGame.Paint += PnlGame_Paint;
            pnlGame.MouseClick += PnlGame_MouseClick;
            pnlGame.Resize += (s, e) => pnlGame.Invalidate();

            // Voeg event handler toe voor inGridSize (let op de hoofdletter)
            if (inGridSize != null)
            {
                inGridSize.KeyPress += InGridSize_KeyPress;
            }
        }

        public void ChangeGrid(int size)
        {
            _game = new Game(size);
            _showCompletionMessage = true; // Reset completion message flag
            pnlGame.Invalidate();
        }

        private void PnlGame_MouseClick(object? sender, MouseEventArgs e)
        {
            if (_game == null || _game.Complete) return;

            if (!IsInsideGrid(e.Location)) return;

            int col = (e.X - _game.GridStart.X) / _game.CellSize;
            int row = (e.Y - _game.GridStart.Y) / _game.CellSize;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    _game.Marked[row, col] = _game.Marked[row, col] != Marked.Done ? Marked.Done : Marked.None;
                    break;
                case MouseButtons.Right:
                    _game.Marked[row, col] = _game.Marked[row, col] != Marked.Wrong ? Marked.Wrong : Marked.None;
                    break;
            }

            pnlGame.Invalidate();
        }

        private bool IsInsideGrid(Point location)
        {
            return location.X >= _game.GridStart.X &&
                   location.Y >= _game.GridStart.Y &&
                   location.X <= _game.GridStart.X + _game.GridArea &&
                   location.Y <= _game.GridStart.Y + _game.GridArea;
        }

        private void PnlGame_Paint(object? sender, PaintEventArgs e)
        {
            if (_game == null) return;

            bool wasComplete = _game.Complete;
            _game.ValidateGame();

            if (_game.Complete && !wasComplete && _showCompletionMessage)
            {
                _showCompletionMessage = false;
                ShowCompletionMessage();
                GameCompleted?.Invoke();
            }

            Graphics g = e.Graphics;
            SetupGridSizeAndFont();
            DrawGridBackground(g);
            DrawGridLines(g);
            DrawMarkedCells(g);
            DrawHints(g);

            if (_game.Complete)
            {
                DrawCompletionOverlay(g);
            }
        }

        private void ShowCompletionMessage()
        {
            MessageBox.Show("Gefeliciteerd! Je hebt de puzzel opgelost!",
                          "Puzzel voltooid",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void DrawCompletionOverlay(Graphics g)
        {
            var rect = new Rectangle(_game.GridStart.X, _game.GridStart.Y,
                                   _game.GridArea, _game.GridArea);

            using (var brush = new SolidBrush(Color.FromArgb(128, Color.LightGreen)))
            {
                g.FillRectangle(brush, rect);
            }

            var font = new Font("Arial", 24, FontStyle.Bold);
            var text = "Voltooid!";
            var size = g.MeasureString(text, font);

            g.DrawString(text, font, Brushes.DarkGreen,
                        rect.X + (rect.Width - size.Width) / 2,
                        rect.Y + (rect.Height - size.Height) / 2);
        }

        private void SetupGridSizeAndFont()
        {
            _game.CellSize = Math.Min(pnlGame.ClientSize.Width, pnlGame.ClientSize.Height) /
                           (_game.GridSize + Math.Max(_game.RowHintMax, _game.ColHintMax));
            _game.GridStart = new Point(_game.CellSize * _game.RowHintMax, _game.CellSize * _game.ColHintMax);
            _game.GridArea = _game.CellSize * _game.GridSize;
            font = new Font(fontFamily, _game.CellSize, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        private void DrawGridBackground(Graphics g)
        {
            Rectangle area = new(_game.GridStart.X, _game.GridStart.Y, _game.GridArea, _game.GridArea);
            g.FillRectangle(Brushes.White, area);
            g.DrawRectangle(Pens.Black, area);
        }

        private void DrawGridLines(Graphics g)
        {
            for (int i = 0; i <= _game.GridSize; i++)
            {
                g.DrawLine(Pens.Black,
                    _game.GridStart.X,
                    _game.GridStart.Y + i * _game.CellSize,
                    _game.GridStart.X + _game.GridArea,
                    _game.GridStart.Y + i * _game.CellSize);

                g.DrawLine(Pens.Black,
                    _game.GridStart.X + i * _game.CellSize,
                    _game.GridStart.Y,
                    _game.GridStart.X + i * _game.CellSize,
                    _game.GridStart.Y + _game.GridArea);
            }
        }

        private void DrawMarkedCells(Graphics g)
        {
            for (int row = 0; row < _game.GridSize; row++)
            {
                for (int col = 0; col < _game.GridSize; col++)
                {
                    Point pos = GetCellPosition(row, col);
                    Rectangle rect = new(pos.X + _game.CellPadding.Left, pos.Y + _game.CellPadding.Top,
                                      _game.CellSize - _game.CellPadding.Left - _game.CellPadding.Right,
                                      _game.CellSize - _game.CellPadding.Top - _game.CellPadding.Bottom);

                    switch (_game.Marked[row, col])
                    {
                        case Marked.Done:
                            g.FillRectangle(Brushes.Black, rect);
                            break;
                        case Marked.Wrong:
                            g.DrawString("X", font, Brushes.DarkRed, new Rectangle(pos.X, pos.Y, _game.CellSize, _game.CellSize));
                            break;
                    }
                }
            }
        }

        private void DrawHints(Graphics g)
        {
            // Row Hints
            for (int i = 0; i < _game.RowHints.Length; i++)
            {
                for (int j = 0; j < _game.RowHints[i].Length; j++)
                {
                    int x = _game.GridStart.X - (_game.CellSize * _game.RowHints[i].Length) + (_game.CellSize * j);
                    int y = _game.GridStart.Y + (_game.CellSize * i);
                    g.DrawString(_game.RowHints[i][j].ToString(), font, Brushes.Black, new Rectangle(x, y, _game.CellSize, _game.CellSize));
                }
            }

            // Column Hints
            for (int i = 0; i < _game.ColHints.Length; i++)
            {
                for (int j = 0; j < _game.ColHints[i].Length; j++)
                {
                    int x = _game.GridStart.X + (_game.CellSize * i);
                    int y = _game.GridStart.Y - (_game.CellSize * _game.ColHints[i].Length) + (_game.CellSize * j);
                    g.DrawString(_game.ColHints[i][j].ToString(), font, Brushes.Black, new Rectangle(x, y, _game.CellSize, _game.CellSize));
                }
            }
        }

        private Point GetCellPosition(int row, int col)
        {
            return new Point(
                _game.GridStart.X + col * _game.CellSize,
                _game.GridStart.Y + row * _game.CellSize
            );
        }

        private void InGridSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSubmitSize_Click(sender, e);
            }
        }

        private void btnSubmitSize_Click(object sender, EventArgs e)
        {
            if (inGridSize != null)
            {
                ChangeGrid((int)inGridSize.Value);
            }
        }
    }
}