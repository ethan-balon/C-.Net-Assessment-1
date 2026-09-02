# Chess Maze

Designed using C# .NET environment \
Version 09.2\
2nd September 2026 11:19AM - 7:01PM\
Ethan Balon\
ebb0039@arastudent.ac.nz

### About
ChessMaze is a Chess based maze game built using C# and .NET, this is for the BCDE222 Best Programming Practices (C# .NET) Practical Assessment 1

## Changes from previous
- Began developing UML diagram (completed UML diagram in backlog)
- Improve feature card (account for InvalidDestination)
- Create GamePlayer template

### v09.01.1
- Organised folder structure
- Inserted finished feature cards document
- Insert UML Diagram document
- Begin version control and documentation

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