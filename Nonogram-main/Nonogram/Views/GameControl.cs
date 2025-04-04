public partial class GameControl : UserControl
{
    private Game _game;
    private FontFamily fontFamily = new("Arial");
    private Font font;
    private int score;
    private DateTime startTime;

    public GameControl()
    {
        InitializeComponent();

        DoubleBuffered = true;
        pnlGame.Paint += PnlGame_Paint;
        pnlGame.MouseClick += PnlGame_MouseClick;
        pnlGame.Resize += PnlGame_Resize;

        score = 0;
        lblScore.Text = "Score: " + score;
    }

    private void PnlGame_Resize(object? sender, EventArgs e)
    {
        pnlGame.Invalidate();
    }

    private void PnlGame_MouseClick(object? sender, MouseEventArgs e)
    {
        if (e.X < _game.GridStart.X || e.X - _game.GridStart.X > _game.GridStart.X + (_game.CellSize * _game.GridSize))
            return;
        if (e.Y < _game.GridStart.Y || e.Y - _game.GridStart.Y > _game.GridStart.Y + (_game.CellSize * _game.GridSize))
            return;

        int col = (int)Math.Floor(((float)e.X - _game.GridStart.X) / _game.CellSize);
        int row = (int)Math.Floor(((float)e.Y - _game.GridStart.Y) / _game.CellSize);

        switch (e.Button)
        {
            case MouseButtons.Left:
                if (_game.Marked[row, col] != Marked.Done)
                    _game.Marked[row, col] = Marked.Done;
                else
                    _game.Marked[row, col] = Marked.None;
                break;
            case MouseButtons.Right:
                if (_game.Marked[row, col] != Marked.Wrong)
                {
                    _game.Marked[row, col] = Marked.Wrong;
                    score++;  // Fout gemarkeerd, verhoog de score
                }
                else
                    _game.Marked[row, col] = Marked.None;
                break;
        }

        lblScore.Text = "Score: " + score; // Update de score

        pnlGame.Invalidate();
    }

    private void PnlGame_Paint(object? sender, PaintEventArgs e)
    {
        if (_game == null) return;
        _game.ValidateGame();

        if (_game.Complete) MessageBox.Show("Game is complete!");

        Graphics g = e.Graphics;
        _game.CellSize = Math.Min(pnlGame.ClientSize.Width, pnlGame.ClientSize.Height) / (_game.GridSize + Math.Max(_game.RowHintMax, _game.ColHintMax));
        _game.GridStart = new Point(_game.CellSize * _game.RowHintMax, _game.CellSize * _game.ColHintMax);
        _game.GridArea = _game.CellSize * _game.GridSize;

        font = new Font(fontFamily, _game.CellSize, FontStyle.Regular, GraphicsUnit.Pixel);

        Rectangle area = new Rectangle(_game.GridStart.X, _game.GridStart.Y, _game.GridArea, _game.GridArea);

        g.FillRectangle(Brushes.White, area);

        for (int i = 0; i < _game.GridSize; i++)
        {
            g.DrawLine(Pens.Black, _game.GridStart.X, _game.GridStart.Y + i * _game.CellSize, _game.GridStart.X + _game.GridArea, _game.GridStart.Y + i * _game.CellSize);
            g.DrawLine(Pens.Black, _game.GridStart.X + i * _game.CellSize, _game.GridStart.Y, _game.GridStart.X + i * _game.CellSize, _game.GridStart.Y + _game.GridArea);
        }
        g.DrawRectangle(Pens.Black, area);

        // Teken gemarkeerde cellen
        for (int row = 0; row < _game.Marked.GetLength(0); row++)
            for (int col = 0; col < _game.Marked.GetLength(1); col++)
                if (_game.Marked[row, col] == Marked.Done)
                    g.FillRectangle(Brushes.Black, _game.GridStart.X + (col * _game.CellSize + _game.CellPadding.Left), _game.GridStart.Y + (row * _game.CellSize + _game.CellPadding.Top), _game.CellSize - _game.CellPadding.Left - _game.CellPadding.Right, _game.CellSize - _game.CellPadding.Bottom - _game.CellPadding.Top);
                else if (_game.Marked[row, col] == Marked.Wrong)
                    g.DrawString("X", font, Brushes.DarkRed, new Rectangle(_game.GridStart.X + (col * _game.CellSize), _game.GridStart.Y + (row * _game.CellSize), _game.CellSize, _game.CellSize));

        // Hints tekenen (zoals je het al deed)
    }

    public void ChangeGrid(int size)
    {
        _game = new Game(size);
        score = 0;  // Reset de score
        lblScore.Text = "Score: " + score; // Update de score
    }

    private void btnSubmitSize_Click(object sender, EventArgs e)
    {
        ChangeGrid((int)inGridSize.Value);
        pnlGame.Refresh();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        ChangeGrid(_game.GridSize); // Reset de game met dezelfde grootte
        pnlGame.Refresh();
    }
}
