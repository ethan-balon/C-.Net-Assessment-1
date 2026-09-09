using BCIT615.Assessment1.GamePlayer;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace BCIT615.Assessment1.GamePlayer.Model;

public class GamePlayer : IGamePlayer
{
    

    //game data values
    internal readonly int _Rows;
    internal readonly int _Columns;
    internal bool _IsComplete;
    internal readonly IReadOnlyDictionary<Position, PieceType> _pieces;

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

        /*
                        TEST FOR UNSUCCESFUL MOVE CONDITIONS
         */
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

        /*
         *            PIECE SPECIFIC MOVE CONDITIONS
         */

        if (currentPiece == PieceType.Rook)
        {
            //check if the movement is valid
            if (destination.Row != _CurrentPosition.Row && destination.Column != _CurrentPosition.Column)
            {
                return MoveResult.InvalidMovement;
            }

            //to do next
            //account for path blocked condition

            int rowStep = Math.Sign(destination.Row - _CurrentPosition.Row);
            int columnStep = Math.Sign(destination.Column - _CurrentPosition.Column);
            int targetRow = _CurrentPosition.Row + rowStep;
            int targetColumn = _CurrentPosition.Column + columnStep;

            while (targetRow != destination.Row || targetColumn != destination.Column)
            {
                if (GetPieceAt(new Position(targetRow, targetColumn)) != null)
                {
                    return MoveResult.PathBlocked;
                }

                targetRow += rowStep;
                targetColumn += columnStep;
            }
        }



        //check if the destination position isnt empty, indicating no other piece is present
        if (targetPiece == null)
        {
            return MoveResult.InvalidDestination;
        }

        /*
                                    PERFORM PIECE MOVE
        */


        //if all fail conditions are not met, proceed with successful move
        _CurrentPosition = destination;

        //document a new successful move
        MoveRecord move = new(
            _MoveRecord.Count + 1,
            _CurrentPosition,
            destination,
            targetPiece.Value);
        _MoveRecord.Add(move);

        //checks if the game is complete as a result of the new move
        if (destination == TargetPosition)
        {
            //game complete, no further moves accepted
            _IsComplete = true;
            return MoveResult.GameCompleted;
        }
        else
        {
            //game still incomplete, normal success returned, can accept more moves from player
            return MoveResult.Success;
        }

    }

    public void Restart()
    {
        // TODO
    }
}