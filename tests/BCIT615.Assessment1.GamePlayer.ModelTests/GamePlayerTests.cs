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
    public void TryMove_OutOfBounds_ReturnsOutOfBounds()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        // a position that is outside of the playable game board
        MoveResult TestResult = player.TryMove(new Position(5,6));
        // check if game prevents out of bounds move from succeeding
        Assert.AreEqual(MoveResult.OutOfBounds, TestResult);
    }

    [TestMethod]
    public void TryMove_GameCompleted_ReturnsGameCompleted()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        Assert.Inconclusive("Test not yet implemented.");
    }


    [TestMethod]
    public void TryMove_Rook_IllegalMove_ReturnsInvalidMovement()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        // a position that is not vertically aligned with the current position of rook piece (not a legal rook move)
        MoveResult TestResult = player.TryMove(new Position(4, 1));
        // check if game prevents illegal rook move from succeeding
        Assert.AreEqual(MoveResult.InvalidMovement, TestResult);
    }

    [TestMethod]
    public void TryMove_Rook_BlockedPath_ReturnsBlockedPath()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        Assert.Inconclusive("Test not yet implemented.");
    }

    [TestMethod]
    public void TryMove_Rook_SuccesfulMove_ReturnsSuccess()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        MoveResult TestResult = player.TryMove(new Position(5, 3));
        //check if the move has a successful result
        Assert.AreEqual(MoveResult.Success, TestResult);
        //check if the player position successfully updated to the new bishop position
        Assert.AreEqual(new Position(5, 3), player.CurrentPosition);
    }
}