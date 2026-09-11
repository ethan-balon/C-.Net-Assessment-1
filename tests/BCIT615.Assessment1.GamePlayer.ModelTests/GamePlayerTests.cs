using BCIT615.Assessment1.GamePlayer;
using BCIT615.Assessment1.GamePlayer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCIT615.Assessment1.GamePlayer.ModelTests;

[TestClass]
public sealed class GamePlayerTests
{
    [TestMethod]
    public void NewGame_InitializesSuccesfully()
    {
        //initialize new instance of GamePlayer
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        //check if the game initializes with the correct values
        Assert.AreEqual(6, player.Rows);
        Assert.AreEqual(6, player.Columns);
        //check if iscomplete is set to false (indicating new game instance)
        Assert.IsFalse(player.IsComplete);
        //check if move history is empty, expected to be 0 upon initialisation
        Assert.AreEqual(0, player.MoveHistory.Count);
    }

    [TestMethod]
    public void NewGame_CorrectPlayerPositions()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        //checks if the game places the player's positions in the correct areas
        Assert.AreEqual(new Position(5,0), player.StartPosition);
        Assert.AreEqual(new Position(5, 0), player.CurrentPosition);
        Assert.AreEqual(new Position(0, 5), player.TargetPosition);
    }


    [TestMethod]
    public void NewGame_CorrectPiecePositions()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        //checks if the game places the piece positions in the correct areas
        Assert.AreEqual(PieceType.Rook, player.GetPieceAt(new Position(5, 0)));
        Assert.AreEqual(PieceType.Bishop, player.GetPieceAt(new Position(5, 3)));
        Assert.AreEqual(PieceType.Knight, player.GetPieceAt(new Position(3, 5)));
        Assert.AreEqual(PieceType.King, player.GetPieceAt(new Position(1, 4)));
        //checks if unused positions are null, indicating no piece is present
        Assert.AreEqual(null, player.GetPieceAt(new Position(0, 0)));
    }




    [TestMethod]
    public void Restart_InitializesSuccesfully()
    {
        //initialize new instance of GamePlayer
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        //initial setup for test condition
        MoveResult InitialSetup = player.TryMove(new Position(5, 3));
        Assert.AreEqual(MoveResult.Success, InitialSetup);
        MoveResult InitialSetup2 = player.TryMove(new Position(3, 5));
        Assert.AreEqual(MoveResult.Success, InitialSetup2);
        MoveResult InitialSetup3 = player.TryMove(new Position(1, 4));
        Assert.AreEqual(MoveResult.Success, InitialSetup3);
        MoveResult InitialSetup4 = player.TryMove(new Position(0, 5));
        Assert.AreEqual(MoveResult.GameCompleted, InitialSetup4);
        MoveResult InitialSetup5 = player.TryMove(new Position(0, 4));
        Assert.AreEqual(MoveResult.GameAlreadyCompleted, InitialSetup5);

        //restart game and check if values are set back to defaults
        player.Restart();

        //check if the game initializes with the correct values
        Assert.AreEqual(6, player.Rows);
        Assert.AreEqual(6, player.Columns);
        //check if iscomplete is set to false (indicating new game instance)
        Assert.IsFalse(player.IsComplete);
        //check if move history is empty, expected to be 0 upon initialisation
        Assert.AreEqual(0, player.MoveHistory.Count);
    }

    [TestMethod]
    public void Restart_CorrectPlayerPositions()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        //initial setup for test condition
        MoveResult InitialSetup = player.TryMove(new Position(5, 3));
        Assert.AreEqual(MoveResult.Success, InitialSetup);
        MoveResult InitialSetup2 = player.TryMove(new Position(3, 5));
        Assert.AreEqual(MoveResult.Success, InitialSetup2);
        MoveResult InitialSetup3 = player.TryMove(new Position(1, 4));
        Assert.AreEqual(MoveResult.Success, InitialSetup3);
        MoveResult InitialSetup4 = player.TryMove(new Position(0, 5));
        Assert.AreEqual(MoveResult.GameCompleted, InitialSetup4);
        MoveResult InitialSetup5 = player.TryMove(new Position(0, 4));
        Assert.AreEqual(MoveResult.GameAlreadyCompleted, InitialSetup5);

        //restart game and check if values are set back to defaults
        player.Restart();

        //checks if the game places the player's positions in the correct areas
        Assert.AreEqual(new Position(5, 0), player.StartPosition);
        Assert.AreEqual(new Position(5, 0), player.CurrentPosition);
        Assert.AreEqual(new Position(0, 5), player.TargetPosition);
    }
}