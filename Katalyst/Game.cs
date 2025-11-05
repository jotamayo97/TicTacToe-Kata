namespace Katalyst;


public class Game
{
    private readonly Board _board = new();
    private bool _isGameOver;

    public Player CurrentPlayer { get; private set; } = Player.X;

    public Player? GetWinner() => _board.GetWinner();
    public bool IsDraw() => _board.IsFull() && GetWinner() == null;

    public void Play(Player player, int row, int col)
    {
        if (_isGameOver)
            throw new InvalidOperationException("Game is already over");

        if (player != CurrentPlayer)
            throw new InvalidOperationException("Not this player's turn");

        _board.Place(player, row, col);

        if (_board.GetWinner() != null || _board.IsFull())
        {
            _isGameOver = true;
            return;
        }

        CurrentPlayer = CurrentPlayer == Player.X ? Player.O : Player.X;
    }

    public Player?[,] GetBoard() => GetSnapshot();

    private Player?[,] GetSnapshot()
    {
        var snapshot = new Player?[3, 3];
        for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
            snapshot[i, j] = _board.GetCell(i, j);
        return snapshot;
    }
}