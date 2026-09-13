# Chess Maze

Designed using C# .NET environment \
Version 09.14\
14th September 2026 7:00AM\
Ethan Balon\
ebb0039@arastudent.ac.nz

### About
ChessMaze is a Chess based maze game built using C# and .NET, this is for the BCDE222 Best Programming Practices (C# .NET) Practical Assessment 1

In this game, the
player starts on a square containing a chess piece. On each move, the player must
follow the movement rules of the chess piece on the square they are currently standing
on. The chess pieces stay in fixed positions and never move during the game. The goal is
to find a path through the maze and reach the target square.

## Commands to setup application
```text
dotnet restore
dotnet build --no-restore
dotnet test --no-build
dotnet run --project src/BCIT615.Assessment1.GamePlayer.App
```

## Changes in v09.14
- Completed final solution
- Completed evidence pack
- Completed UML
- Completed README
- Final overlook on documents


### v09.13.1
- Continued development on evidence pack
- increase coverage of tests to improve application tests

### v09.12
- fixed some typos in the ccode ommentation
- continue filling evidence pack document

### v09.11.2
- Completed basic fundemental application
- development King tests
- development of king functionality
- Created evidence pack document


### v09.11.1
- Fixed issue in King tests

### v09.11
- Partially completed King tests

### v09.10.2
- completed Knight functionality
- added _CustomDataMode variable to enhance program's flexibility with custom piece positions

### v09.10.1
- Completed Bishop functionaltiy
- Passed BlockedPath test for Bishop
- Passed SuccessfulMove test for Bishop

### v09.10
- Completed Bishop tests
- Started development on Bishop functionality

### v09.9.2
- Complete all Rook functionality and tests

### v09.9.1
- Succesfully created Rook tests

### v09.9
- seperated tests into more specific files

### v09.8.2
- Fixed uncommitted changes on github

### v09.8.1
- Fixed git commit message

### v09.8
- Made improvements to UML
- Plan to change variables to be more consistent, easier to test, and still secure (internal read only variables)
- Expanded description for better application explanation

### v09.6
- Continue developing TryMove functionality (rook move)
- Start test development on TryMove (invalid move, out of bounds)

### v09.5
- Start planning the development of TryMove functionality

### v09.4
- Continue development of GamePlayer test and initialisation (setting piece positions and testing if it works)
- Develop GetPieceAt() functionality

### v09.03
- Further development of UML diagram
- Begin development of GamePlayer initialisation (create a new game instance)
- Succesful testing of GamePlayer initialisation

### v09.02
- Improve feature card (account for InvalidDestination)
- Create GamePlayer template
- Begin development on UML diagram

### v09.01.1
- Organised folder structure
- Inserted finished feature cards document
- Insert UML Diagram document
- Begin version control and documentation

### v09.01
- Created git repository
- test git repository and push

## Additional notes



### Supplied and frozen
Files that were included in the starter solution and were unmodified
- files in `src/BCIT615.Assessment1.GamePlayer.Contracts/`;
- `src/BCIT615.Assessment1.GamePlayer.Model/ReferenceBoardData.cs`;
- supplied baseline tests.

### Learner-owned work
Files created for the assessment
- `src/BCIT615.Assessment1.GamePlayer.Model/\GamePlayer.cs`
- `tests/BCIT615.Assessment1.GamePlayer.ModelTests/GamePlayerTests.cs`
- `tests/BCIT615.Assessment1.GamePlayer.ModelTests/TryMoveAllPiecesTests.cs`
- `tests/BCIT615.Assessment1.GamePlayer.ModelTests/TryMoveRookTests.cs`
- `tests/BCIT615.Assessment1.GamePlayer.ModelTests/TryMoveBishopTests.cs`
- `tests/BCIT615.Assessment1.GamePlayer.ModelTests/TryMoveKnightTests.cs`
- `tests/BCIT615.Assessment1.GamePlayer.ModelTests/TryMoveKingTests.cs`


