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
}