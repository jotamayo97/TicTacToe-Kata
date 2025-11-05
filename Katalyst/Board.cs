using Katalyst;

public class Board
{
    private readonly Player?[,] _cells = new Player?[3, 3];

    public Player? GetCell(int row, int col) => _cells[row, col];

    public void Place(Player player, int row, int col)
    {
        if (_cells[row, col] != null)
            throw new InvalidOperationException("Cell already occupied");

        _cells[row, col] = player;
    }

    public bool IsFull()
    {
        foreach (var cell in _cells)
            if (cell == null) return false;
        return true;
    }

    public Player? GetWinner()
    {
        for (int i = 0; i < 3; i++)
        {
            if (_cells[i, 0] != null && _cells[i, 0] == _cells[i, 1] && _cells[i, 1] == _cells[i, 2])
                return _cells[i, 0];
            if (_cells[0, i] != null && _cells[0, i] == _cells[1, i] && _cells[1, i] == _cells[2, i])
                return _cells[0, i];
        }

        if (_cells[0, 0] != null && _cells[0, 0] == _cells[1, 1] && _cells[1, 1] == _cells[2, 2])
            return _cells[0, 0];
        if (_cells[0, 2] != null && _cells[0, 2] == _cells[1, 1] && _cells[1, 1] == _cells[2, 0])
            return _cells[0, 2];

        return null;
    }
}