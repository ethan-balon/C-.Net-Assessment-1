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

    // variable to decide whether to use default reference databoard or custom databoard (if provided)
    public bool _CustomDataMode;

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

    // DEFAULT CONSTRUCTOR - When no custom test data is provided
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

        //setup with custom data mode turned off
        _CustomDataMode = false;
    }

    public GamePlayer(Dictionary<Position, PieceType> TestPieces)
    {
        // initialise the game using referenceboarddata values for the first time
        _Rows = ReferenceBoardData.Rows;
        _Columns = ReferenceBoardData.Columns;
        _IsComplete = false;

        //fill newly created game instance with positions from referenceboarddata
        //custom pieces are passed in via the TestPieces parameter during testing purposes
        _pieces = TestPieces;
        StartPosition = ReferenceBoardData.Start;
        TargetPosition = ReferenceBoardData.Target;
        _CurrentPosition = StartPosition;

        //setup with custom data mode turned on
        _CustomDataMode = true;
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

        if (currentPiece == PieceType.Bishop)
        {
            //check if movement is valid
            if (Math.Abs(destination.Row - _CurrentPosition.Row) != Math.Abs(destination.Column - _CurrentPosition.Column))
            {
                return MoveResult.InvalidMovement;
            }

            int rowAxisMovement = Math.Sign(destination.Row - _CurrentPosition.Row);
            int rowColumnMovement = Math.Sign(destination.Column - _CurrentPosition.Column);

            int targetRow = _CurrentPosition.Row + rowAxisMovement;
            int targetColumn = _CurrentPosition.Column + rowColumnMovement;

            while (targetRow != destination.Row || targetColumn != destination.Column)
            {
                if (GetPieceAt(new Position(targetRow, targetColumn)) != null)
                {
                    return MoveResult.PathBlocked;
                }
                else
                {
                    targetRow += rowAxisMovement;
                    targetColumn += rowColumnMovement;
                }
            }
        }


        if (currentPiece == PieceType.Knight)
        {
            int rowAxisMovement = Math.Abs(destination.Row - _CurrentPosition.Row);
            int rowColumnMovement = Math.Abs(destination.Column - _CurrentPosition.Column);

            // checks if the movement is valid Two squares on one axis and one on the other.
            bool validKnightMove = (rowAxisMovement == 2 && rowColumnMovement == 1) ||
                             (rowAxisMovement == 1 && rowColumnMovement == 2);

            if (!validKnightMove)
            {
                return MoveResult.InvalidMovement;
            }
        }

        if (currentPiece == PieceType.King)
        {
            int rowAxisMovement = Math.Abs(destination.Row - _CurrentPosition.Row);
            int rowColumnMovement = Math.Abs(destination.Column - _CurrentPosition.Column);

            // checks if the movement is valid Two squares on one axis and one on the other.
            bool validKingMove = (rowAxisMovement <= 1 && rowColumnMovement <= 1);

            if (!validKingMove)
            {
                return MoveResult.InvalidMovement;
            }
        }



        //check if the destination position isnt empty, indicating no other piece is present
        if (targetPiece == null && destination != TargetPosition)
        {
            return MoveResult.InvalidDestination;
        }

        /*
                                    PERFORM PIECE MOVE
        */


        //if all failable conditions are not met, proceed with successful move
        _CurrentPosition = destination;

        

        //checks if the game is complete as a result of the new move
        if (destination == TargetPosition)
        {
            //game complete, no further moves accepted
            _IsComplete = true;
            return MoveResult.GameCompleted;
        }
        else if (targetPiece != null) 
        {
            MoveRecord move = new(
                _MoveRecord.Count + 1,
                _CurrentPosition,
                destination,
                targetPiece.Value);
            _MoveRecord.Add(move);
            //game still incomplete, normal success returned, can accept more moves from player
            return MoveResult.Success;
            //document a new successful move
            
        }
        return MoveResult.InvalidMovement;
    }

    public void Restart()
    {
        _CurrentPosition = StartPosition;
        _IsComplete = false;
        _MoveRecord.Clear();
    }
}