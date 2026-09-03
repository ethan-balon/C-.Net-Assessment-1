namespace BCIT615.Assessment1.GamePlayer;

/// <summary>Defines the observable behaviour of a Game Player Model.</summary>
public interface IGamePlayer
{
    Position StartPosition { get; }
    Position TargetPosition { get; }
    Position CurrentPosition { get; }
    bool IsComplete { get; }
    IReadOnlyList<MoveRecord> MoveHistory { get; }
    PieceType? GetPieceAt(Position position); // Nullable piece type
    MoveResult TryMove(Position destination); //Not nullable move result, either success or invalid outcomes
    void Restart();
}
