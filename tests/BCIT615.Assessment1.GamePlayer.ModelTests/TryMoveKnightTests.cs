using BCIT615.Assessment1.GamePlayer;
using BCIT615.Assessment1.GamePlayer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCIT615.Assessment1.GamePlayer.ModelTests;

[TestClass]
public sealed class TryMoveKnightTests
{
    [TestMethod]
    public void TryMove_Knight_IllegalMove_ReturnsInvalidMovement()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        // a position that is not a legal Knight move (Two squares on one axis and one on the other)
        MoveResult TestResult = player.TryMove(new Position(2, 2));
        // check if game prevents illegal Knight move from succeeding
        Assert.AreEqual(MoveResult.InvalidMovement, TestResult);
    }


    [TestMethod]
    public void TryMove_Knight_EmptyDestination_ReturnsInvalidDestination()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        //perform rook move first as per referenceboardata
        MoveResult InitialSetup = player.TryMove(new Position(5, 3));
        Assert.AreEqual(MoveResult.Success, InitialSetup);
        MoveResult InitialSetup2 = player.TryMove(new Position(3, 5));
        Assert.AreEqual(MoveResult.Success, InitialSetup2);

        // a position that is a legal unblocked Knight move, but is a completley blank square
        MoveResult TestResult = player.TryMove(new Position(2, 3));
        // check if game prevents move from succeeding
        Assert.AreEqual(MoveResult.InvalidDestination, TestResult);
    }


    [TestMethod]
    public void TryMove_Knight_SuccesfulMove_ReturnsSuccess()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();


        //perform rook move first as per referenceboardata
        MoveResult InitialSetup = player.TryMove(new Position(5, 3));
        Assert.AreEqual(MoveResult.Success, InitialSetup);
        MoveResult InitialSetup2 = player.TryMove(new Position(3, 5));
        Assert.AreEqual(MoveResult.Success, InitialSetup2);

        MoveResult TestResult = player.TryMove(new Position(1, 4));
        // check if the move has a successful result
        Assert.AreEqual(MoveResult.Success, TestResult);
        // check if the player position successfully updated to the new king position
        Assert.AreEqual(new Position(1, 4), player.CurrentPosition);
    }
}