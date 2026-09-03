using BCIT615.Assessment1.GamePlayer;

namespace BCIT615.Assessment1.GamePlayer.Model;

public class GamePlayer : IGamePlayer
{
    

    //game data values
    private readonly int _Rows;
    private readonly int _Columns;
    private bool _IsComplete;
    private readonly IReadOnlyDictionary<Position, PieceType> _pieces;

    //public game data values FOR TESTING PURPOSES
    public bool IsComplete => _IsComplete;
    public int Rows => _Rows;
    public int Columns => _Columns;

    //move record values
    private readonly List<MoveRecord> _MoveRecord = new();
    public IReadOnlyList<MoveRecord> MoveHistory => _MoveRecord.AsReadOnly();

    // position values
    private Position _CurrentPosition;
    public Position StartPosition { get; }
    public Position TargetPosition { get; }
    public Position CurrentPosition => _CurrentPosition;

    public GamePlayer()
    {
        // initialise the game using referenceboarddata values for the first time
        _Rows = ReferenceBoardData.Rows;
        _Columns = ReferenceBoardData.Columns;
        _IsComplete = false;

        //fill newly created game instance with positions from referenceboarddata
        _pieces = ReferenceBoardData.Pieces;
        StartPosition = ReferenceBoardData.Start;
        TargetPosition = ReferenceBoardData.Target;
        _CurrentPosition = StartPosition;


    }

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