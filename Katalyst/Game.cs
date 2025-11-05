namespace Katalyst;


public class Game
{
    private readonly string?[] _board = new string?[9];

    public string?[] GetBoard() => _board;

    public void Play(string player, int row, int col)
    {
        var index = row * 3 + col;
        _board[index] = player;
    }
}