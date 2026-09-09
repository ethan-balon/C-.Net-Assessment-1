# Chess Maze

Designed using C# .NET environment \
Version 09.10\
10th September 2026 9:39AM - 10:27AM\
Ethan Balon\
ebb0039@arastudent.ac.nz

### About
ChessMaze is a Chess based maze game built using C# and .NET, this is for the BCDE222 Best Programming Practices (C# .NET) Practical Assessment 1\

In this game, the
player starts on a square containing a chess piece. On each move, the player must
follow the movement rules of the chess piece on the square they are currently standing
on. The chess pieces stay in fixed positions and never move during the game. The goal is
to find a path through the maze and reach the target square.

## Changes in v09.10
- Completed Bishop tests
- Started development on Bishop functionality

## Plans for next version
- Continued development on Bishop functionaltiy
- Pass BlockedPath test for Bishop
- Pass SuccessfulMove test for Bishop

## Plans for future
- Improve UML to industry standard
- Write tests for TryMove
- Continue working on TryMove (bishop move)
- Modify private variables to internal variables, remove any unnecessary public duplicates
- Further improve feature cards

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


### Authority and environment
Use the exact released **BCIT615 Assessment 1 Game Player Technical Specification** published with this starter. Use .NET SDK **9.0.316** as pinned in `global.json`, unless teaching staff issue a centrally controlled replacement.

### Supplied and frozen
Do not edit, delete, rename, split, merge, relocate, or reproduce:
- files in `src/BCIT615.Assessment1.GamePlayer.Contracts/`;
- `src/BCIT615.Assessment1.GamePlayer.Model/ReferenceBoardData.cs`;
- supplied baseline tests.

### Learner-owned work
Create your own Model implementation and risk-based MSTest tests. Suggested names:
- `src/BCIT615.Assessment1.GamePlayer.Model/BoardGamePlayer.cs`
- `src/BCIT615.Assessment1.GamePlayer.Model/GamePlayerFactory.cs`
- `tests/BCIT615.Assessment1.GamePlayer.ModelTests/BoardGamePlayerConstructionTests.cs`
- `tests/BCIT615.Assessment1.GamePlayer.ModelTests/BoardGamePlayerMovementTests.cs`
- `tests/BCIT615.Assessment1.GamePlayer.ModelTests/BoardGamePlayerStateTests.cs`

These names support professional organisation but do not prescribe the internal algorithm. The supplied baseline tests check only contracts and reference data and are **not sufficient learner testing evidence**.

## Commands
```text
dotnet restore
dotnet build --no-restore
dotnet test --no-build
dotnet run --project src/BCIT615.Assessment1.GamePlayer.App
```
Then run tests to ensure stable functionality