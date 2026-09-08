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
    public void TryMove_GameCompleted_ReturnsGameCompleted()
    {
        BCIT615.Assessment1.GamePlayer.Model.GamePlayer player = new();

        Assert.Inconclusive("Test not yet implemented.");
    }
}