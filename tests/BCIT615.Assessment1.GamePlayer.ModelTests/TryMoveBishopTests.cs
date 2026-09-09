using BCIT615.Assessment1.GamePlayer;
using BCIT615.Assessment1.GamePlayer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCIT615.Assessment1.GamePlayer.ModelTests;

[TestClass]
public sealed class TryMoveBishopTests
{
    [TestMethod]
    public void TryMove_Bishop_IllegalMove_ReturnsInvalidMovement()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        // a position that is not diagonally aligned with the current position of Bishop piece (not a legal rook move)
        MoveResult TestResult = player.TryMove(new Position(3, 3));
        // check if game prevents illegal Bishop move from succeeding
        Assert.AreEqual(MoveResult.InvalidMovement, TestResult);
    }

    [TestMethod]
    public void TryMove_Bishop_BlockedPath_ReturnsBlockedPath()
    {




        Dictionary<Position, PieceType> TestPieces = new()
        {
            [new Position(5, 0)] = PieceType.Bishop,
            [new Position(3, 2)] = PieceType.Knight,
            [new Position(4, 1)] = PieceType.Rook
        };

        //BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new(TestPieces);




        // a position that is not legal but blocked by Bishop piece
        //MoveResult TestResult = player.TryMove(new Position(3, 2));
        // check if game prevents blocked Bishop move from succeeding
        //Assert.AreEqual(MoveResult.PathBlocked, TestResult);
        Assert.Inconclusive("This test is not implemented yet. The GamePlayer class constructor that accepts a dictionary of pieces is not implemented, so we cannot create a player with a specific board state to test the blocked path scenario.");
    }

    [TestMethod]
    public void TryMove_Bishop_SuccesfulMove_ReturnsSuccess()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        MoveResult TestResult = player.TryMove(new Position(3, 5));
        // check if the move has a successful result
        Assert.AreEqual(MoveResult.Success, TestResult);
        // check if the player position successfully updated to the new bishop position
        Assert.AreEqual(new Position(3, 5), player.CurrentPosition);
    }
}


