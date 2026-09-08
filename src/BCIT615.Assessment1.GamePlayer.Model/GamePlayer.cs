using BCIT615.Assessment1.GamePlayer;
using System.Runtime.CompilerServices;

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
        return _pieces.ContainsKey(position) ? _pieces[position] : null;
    }

    public MoveResult TryMove(Position destination)
    {
        //get the piece at the current position
        PieceType? currentPiece = GetPieceAt(_CurrentPosition);
        PieceType? targetPiece = GetPieceAt(destination);
        //test for unsuccessful move conditions
        if (_IsComplete)
        {
            return MoveResult.GameAlreadyCompleted;
        }
        if (destination.Row < 0 ||
            destination.Row >= _Rows ||
            destination.Column < 0 ||
            destination.Column >= _Columns)
        {
            return MoveResult.OutOfBounds;
        }



        if (currentPiece == PieceType.Rook)
        {
            //check if the movement is valid
            if (destination.Row != _CurrentPosition.Row && destination.Column != _CurrentPosition.Column)
            {
                return MoveResult.InvalidMovement;
            }

            //to do next
            //account for path blocked condition
            


        }

        //things to do next
        /*
         * check what chess piece is in the current position
            check if it is a legal move based on the chess piece
            check if the path going to the target position is not blocked
            check if the target position has a chess peice
         */

        //use this for something else
        if (targetPiece == null)
        {
            return MoveResult.InvalidDestination;
        }

        return MoveResult.Success;
    }

    public void Restart()
    {
        // TODO
    }
}