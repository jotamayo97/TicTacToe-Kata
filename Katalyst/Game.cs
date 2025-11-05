namespace Katalyst;


public class Game
{
    private readonly Player?[,] _board = new Player?[3, 3];
    public Player CurrentPlayer { get; private set; } = Player.X;
    private bool _isGameOver;

    public Player?[,] GetBoard() => _board;

    public void Play(Player player, int row, int col)
    {
        if (_isGameOver)
            throw new InvalidOperationException("Game is already over");

        if (_board[row, col] != null)
            throw new InvalidOperationException("Cell already occupied");

        if (player != CurrentPlayer)
            throw new InvalidOperationException("Not this player's turn");

        _board[row, col] = player;

        var winner = GetWinner();
        var draw = IsDraw();

        if (winner != null || draw)
        {
            _isGameOver = true;
            return;
        }

        CurrentPlayer = CurrentPlayer == Player.X ? Player.O : Player.X;
    }
    public Player? GetWinner()
    {
        for (int row = 0; row < 3; row++)
            if (_board[row, 0] != null &&
                _board[row, 0] == _board[row, 1] &&
                _board[row, 0] == _board[row, 2])
                return _board[row, 0];
        
        for (int col = 0; col < 3; col++)
            if (_board[0, col] != null &&
                _board[0, col] == _board[1, col] &&
                _board[0, col] == _board[2, col])
                return _board[0, col];
        
        if (_board[0, 0] != null &&
            _board[0, 0] == _board[1, 1] &&
            _board[0, 0] == _board[2, 2])
            return _board[0, 0];

        if (_board[0, 2] != null &&
            _board[0, 2] == _board[1, 1] &&
            _board[0, 2] == _board[2, 0])
            return _board[0, 2];

        return null;
    }

    public bool IsDraw()
    {
        if (GetWinner() != null)
            return false;

        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                if (_board[row, col] == null)
                    return false;

        return true;
    }
}