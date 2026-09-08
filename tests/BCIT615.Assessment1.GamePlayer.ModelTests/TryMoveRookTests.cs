using BCIT615.Assessment1.GamePlayer;
using BCIT615.Assessment1.GamePlayer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCIT615.Assessment1.GamePlayer.ModelTests;

[TestClass]
public sealed class TryMoveRookTests
{


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
        //Assert.AreEqual(MoveResult.Success, TestResult);
        //check if the player position successfully updated to the new bishop position
        //Assert.AreEqual(new Position(5, 3), player.CurrentPosition);
        Assert.Inconclusive("Test not yet implemented.");
    }
}