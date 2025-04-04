public partial class GameControl : UserControl
{
    private Game _game;
    private bool _isPaused = false;
    FontFamily fontFamily = new("Arial");
    Font font;

    public GameControl()
    {
        InitializeComponent();

        DoubleBuffered = true;
        pnlGame.Paint += PnlGame_Paint;
        pnlGame.MouseClick += PnlGame_MouseClick;
        pnlGame.Resize += PnlGame_Resize;

        // Voeg pauze-knop en score label toe
        btnPause.Click += BtnPause_Click;
        lblScore.Text = "Score: 0";
    }

    private void BtnPause_Click(object sender, EventArgs e)
    {
        _isPaused = !_isPaused;
        if (_isPaused)
        {
            MessageBox.Show("Game Paused");
        }
        else
        {
            MessageBox.Show("Game Resumed");
        }
        pnlGame.Invalidate();  // Refresh the game area
    }

    private void PnlGame_Paint(object sender, PaintEventArgs e)
    {
        if (_game == null || _isPaused) return;

        _game.ValidateGame();

        if (_game.Complete) MessageBox.Show("Game is complete");

        Graphics g = e.Graphics;

        _game.CellSize = Math.Min(pnlGame.ClientSize.Width, pnlGame.ClientSize.Height) / (_game.GridSize + Math.Max(_game.RowHintMax, _game.ColHintMax));
        _game.GridStart = new Point(_game.CellSize * _game.RowHintMax, _game.CellSize * _game.ColHintMax);
        _game.GridArea = _game.CellSize * _game.GridSize;

        font = new Font(fontFamily, _game.CellSize, FontStyle.Regular, GraphicsUnit.Pixel);

        Rectangle area = new Rectangle(_game.GridStart.X, _game.GridStart.Y, _game.GridArea, _game.GridArea);

        g.FillRectangle(Brushes.White, area);

        // Tekenen van het raster
        for (int i = 0; i < _game.GridSize; i++)
        {
            g.DrawLine(Pens.Black, _game.GridStart.X, _game.GridStart.Y + i * _game.CellSize, _game.GridStart.X + _game.GridArea, _game.GridStart.Y + i * _game.CellSize);
            g.DrawLine(Pens.Black, _game.GridStart.X + i * _game.CellSize, _game.GridStart.Y, _game.GridStart.X + i * _game.CellSize, _game.GridStart.Y + _game.GridArea);
        }
        g.DrawRectangle(Pens.Black, area);

        // Score berekening
        int correctCells = 0;
        for (int row = 0; row < _game.Marked.GetLength(0); row++)
        {
            for (int col = 0; col < _game.Marked.GetLength(1); col++)
            {
                if (_game.Marked[row, col] == Marked.Done)
                {
                    correctCells++;
                }
            }
        }
        lblScore.Text = $"Score: {correctCells}";  // Update score

        // Markeren van de cellen
        for (int row = 0; row < _game.Marked.GetLength(0); row++)
        {
            for (int col = 0; col < _game.Marked.GetLength(1); col++)
            {
                if (_game.Marked[row, col] == Marked.Done)
                {
                    g.FillRectangle(Brushes.Black, _game.GridStart.X + (col * _game.CellSize + _game.CellPadding.Left), _game.GridStart.Y + (row * _game.CellSize + _game.CellPadding.Top), _game.CellSize - _game.CellPadding.Left - _game.CellPadding.Right, _game.CellSize - _game.CellPadding.Bottom - _game.CellPadding.Top);
                }
                else if (_game.Marked[row, col] == Marked.Wrong)
                {
                    g.DrawString("X", font, Brushes.DarkRed, new Rectangle(_game.GridStart.X + (col * _game.CellSize), _game.GridStart.Y + (row * _game.CellSize), _game.CellSize, _game.CellSize));
                }
            }
        }

        // Horizontal en verticale hints tekenen
        for (int i = 0; i < _game.RowHints.Length; i++)
        {
            for (int j = 0; j < _game.RowHints[i].Length; j++)
            {
                g.DrawString(_game.RowHints[i][j].ToString(), font, Brushes.Black, new Rectangle((_game.GridStart.X - (_game.CellSize * _game.RowHints[i].Length)) + (_game.CellSize * j), _game.GridStart.Y + (_game.CellSize * i), _game.CellSize, _game.CellSize));
            }
        }
        for (int i = 0; i < _game.ColHints.Length; i++)
        {
            for (int j = 0; j < _game.ColHints[i].Length; j++)
            {
                g.DrawString(_game.ColHints[i][j].ToString(), font, Brushes.Black, new Rectangle(_game.GridStart.X + (_game.CellSize * i), (_game.GridStart.Y - (_game.CellSize * _game.ColHints[i].Length)) + (_game.CellSize * j), _game.CellSize, _game.CellSize));
            }
        }
    }

    // Andere methoden blijven hetzelfde

    public void ChangeGrid(int size)
    {
        _game = new Game(size);
        pnlGame.Refresh();
    }

    private void inGridSize_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
            btnSubmitSize_Click(sender, e);
    }

    private void btnSubmitSize_Click(object sender, EventArgs e)
    {
        ChangeGrid((int)inGridSize.Value);
        pnlGame.Refresh();
    }
}
