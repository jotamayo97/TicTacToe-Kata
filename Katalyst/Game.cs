namespace Katalyst;


public class Game
{
    private readonly Player?[] _board = new Player?[9];

    public Player?[] GetBoard() => _board;

    public void Play(Player player, int row, int col)
    {
        var index = row * 3 + col;

        if (_board[index] != null)
            throw new InvalidOperationException("Cell already occupied");

        _board[index] = player;
    }

    public Player? GetWinner()
    {
        int[,] winningPositions =
        {
            { 0, 1, 2 }, 
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 }
        };

        for (int i = 0; i < winningPositions.GetLength(0); i++)
        {
            var a = winningPositions[i, 0];
            var b = winningPositions[i, 1];
            var c = winningPositions[i, 2];

            if (_board[a] != null &&
                _board[a] == _board[b] &&
                _board[a] == _board[c])
            {
                return _board[a];
            }
        }

        return null;
    }
}