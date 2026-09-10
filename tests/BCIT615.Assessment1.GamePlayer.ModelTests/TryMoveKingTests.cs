using BCIT615.Assessment1.GamePlayer;
using BCIT615.Assessment1.GamePlayer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCIT615.Assessment1.GamePlayer.ModelTests;

[TestClass]
public sealed class TryMoveKingTests
{
    [TestMethod]
    public void TryMove_King_IllegalMove_ReturnsInvalidMovement()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        // a position that is not a legal King move (Two squares on one axis and one on the other)
        MoveResult TestResult = player.TryMove(new Position(1, 2));
        // check if game prevents illegal King move from succeeding
        Assert.AreEqual(MoveResult.InvalidMovement, TestResult);

        MoveResult TestResult2 = player.TryMove(new Position(0, 2));
        Assert.AreEqual(MoveResult.InvalidMovement, TestResult2);
        MoveResult TestResult3 = player.TryMove(new Position(3, 4));
        Assert.AreEqual(MoveResult.InvalidMovement, TestResult3);
    }


    [TestMethod]
    public void TryMove_King_EmptyDestination_ReturnsInvalidDestination()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        //perform rook move first as per referenceboardata
        MoveResult InitialSetup = player.TryMove(new Position(5, 3));
        Assert.AreEqual(MoveResult.Success, InitialSetup);
        MoveResult InitialSetup2 = player.TryMove(new Position(3, 5));
        Assert.AreEqual(MoveResult.Success, InitialSetup2);
        MoveResult InitialSetup3 = player.TryMove(new Position(1, 4));
        Assert.AreEqual(MoveResult.Success, InitialSetup3);

        // a position that is a legal unblocked King move, but is a completley blank square
        MoveResult TestResult = player.TryMove(new Position(1, 3));
        // check if game prevents move from succeeding
        Assert.AreEqual(MoveResult.InvalidDestination, TestResult);
        MoveResult TestResult2 = player.TryMove(new Position(0, 3));
        Assert.AreEqual(MoveResult.InvalidDestination, TestResult2);
    }


    [TestMethod]
    public void TryMove_King_SuccesfulMove_ReturnsSuccess()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();


        //perform rook move first as per referenceboardata
        MoveResult InitialSetup = player.TryMove(new Position(5, 3));
        Assert.AreEqual(MoveResult.Success, InitialSetup);
        MoveResult InitialSetup2 = player.TryMove(new Position(3, 5));
        Assert.AreEqual(MoveResult.Success, InitialSetup2);
        MoveResult InitialSetup3 = player.TryMove(new Position(1, 4));
        Assert.AreEqual(MoveResult.Success, InitialSetup3);

        MoveResult TestResult = player.TryMove(new Position(0, 5));
        // check if the move has a successful result
        Assert.AreEqual(MoveResult.Success, TestResult);
        // check if the player position successfully updated to the new king position
        Assert.AreEqual(new Position(0, 5), player.CurrentPosition);
    }
}