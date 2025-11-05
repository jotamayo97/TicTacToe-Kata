using Xunit;
using System;
using Assert = Xunit.Assert;

namespace Katalyst.Tests;

public class GameShould
{
    [Fact]
    public void NewGame_ShouldStartWithEmptyBoard()
    {
        var game = new Game();

        var board = game.GetBoard();

        Assert.All(board, cell => Assert.Null(cell));
    }
    
}