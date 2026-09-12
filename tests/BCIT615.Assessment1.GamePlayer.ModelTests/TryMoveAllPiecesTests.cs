using BCIT615.Assessment1.GamePlayer;
using BCIT615.Assessment1.GamePlayer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCIT615.Assessment1.GamePlayer.ModelTests;

[TestClass]
public sealed class TryMoveAllPiecesTests
{

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
    public void TryMove_GameCompleted_ReturnsGameAlreadyCompleted()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        //perform rook move first as per referenceboardata
        MoveResult InitialSetup = player.TryMove(new Position(5, 3));
        Assert.AreEqual(MoveResult.Success, InitialSetup);
        MoveResult InitialSetup2 = player.TryMove(new Position(3, 5));
        Assert.AreEqual(MoveResult.Success, InitialSetup2);
        MoveResult InitialSetup3 = player.TryMove(new Position(1, 4));
        Assert.AreEqual(MoveResult.Success, InitialSetup3);
        MoveResult InitialSetup4 = player.TryMove(new Position(0, 5));
        Assert.AreEqual(MoveResult.GameCompleted, InitialSetup4);

        // check if the player position successfully updated to the new king position
        MoveResult TestResult = player.TryMove(new Position(0, 4));
        Assert.AreEqual(MoveResult.GameAlreadyCompleted, TestResult);

        //checks if the player position remains unchanged after finished game
        Assert.AreEqual(new Position(0, 5), player.CurrentPosition);
    }
}