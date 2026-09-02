using BCIT615.Assessment1.GamePlayer;

namespace BCIT615.Assessment1.GamePlayer.Model;

public class GamePlayer : IGamePlayer
{
    private readonly List<MoveRecord> _moveRecord = new();

    public Position StartPosition { get; }

    public Position TargetPosition { get; }

    public Position CurrentPosition { get; private set; }

    public bool IsComplete { get; private set; }

    public IReadOnlyList<MoveRecord> MoveHistory => _moveRecord;

    public PieceType? GetPieceAt(Position position)
    {
        // TODO
        return null;
    }

    public MoveResult TryMove(Position destination)
    {
        // TODO
        return MoveResult.InvalidMovement;
    }

    public void Restart()
    {
        // TODO
    }
}