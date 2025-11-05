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

        foreach (var cell in board)
            Assert.Null(cell);
    }

    [Fact]
    public void AllowPlayerToPlaceSymbol()
    {
        var game = new Game();
        game.Play(Player.X, 0, 0);

        var board = game.GetBoard();

        Assert.Equal(Player.X, board[0, 0]);
    }

    [Fact]
    public void NotAllowPlayingInOccupiedCell()
    {
        var game = new Game();
        game.Play(Player.X, 0, 0);

        Assert.Throws<InvalidOperationException>(() =>
            game.Play(Player.O, 0, 0)
        );
    }

    [Fact]
    public void DetectWinner_WhenPlayerHasThreeInARow()
    {
        var game = new Game();

        game.Play(Player.X, 0, 0);
        game.Play(Player.X, 0, 1);
        game.Play(Player.X, 0, 2);

        Assert.Equal(Player.X, game.GetWinner());
    }

    [Fact]
    public void DetectDraw_WhenAllCellsFilledWithoutWinner()
    {
        var game = new Game();

        game.Play(Player.X, 0, 0);
        game.Play(Player.O, 0, 1);
        game.Play(Player.X, 0, 2);
        game.Play(Player.X, 1, 0);
        game.Play(Player.O, 1, 1);
        game.Play(Player.X, 1, 2);
        game.Play(Player.O, 2, 0);
        game.Play(Player.X, 2, 1);
        game.Play(Player.O, 2, 2);

        Assert.True(game.IsDraw());
    }
}