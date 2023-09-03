using Microsoft.Extensions.Logging;
using Sudoku.Engine.Exceptions;
using Sudoku.Engine.Loggers;
using Sudoku.Engine.Solvers;
using Sudoku.GameBoard;
using System.Data;
using System.Diagnostics;

namespace Sudoku.Engine
{
  public class Engine
  {
    private readonly int[] _ValidGameNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private const int MAX_LOOP_COUNT = 100;
    private readonly IGameBoard _OriginalGameBoard;
    private IGameBoard _GameBoard;
    private IEnumerable<ISolver> _Solvers;
    private bool _BoardHadActivity;
    private const int BOARD_INACTIVITY_MAX_COUNT = 2;
    private readonly ILogger _Logger;

    public Engine(IGameBoard gameBoard, ILoggerFactory loggerFactory)
    {
      _Logger = loggerFactory.CreateLogger(nameof(Engine));

      _OriginalGameBoard = GameBoardFactory.Create(gameBoard.GetValuesAsString(), _Logger);
      _GameBoard = (GameBoard.GameBoard)gameBoard;
      _Solvers = CollectDefaultSolversForEngine();
      _BoardHadActivity = false;
      gameBoard.OnChanged += SomethingChanged;
    }

    public void SomethingChanged(IGameBoard gameBoard)
    {
      _BoardHadActivity = true;
      _Logger.LogBoardValues(gameBoard.BuildZeroBasedString());
    }

    public IGameBoard Solve()
    {
      EnsureGameBoardProvided();
      var notSolved = true;
      var loopCount = 0;
      var pencilMarksGenerator = new PencilMarksGenerator(_Logger);
      _GameBoard = pencilMarksGenerator.GeneratePencilMarks(_GameBoard);
      var boardHadNoActivityCount = 0;
      while (notSolved && (boardHadNoActivityCount <= BOARD_INACTIVITY_MAX_COUNT) && loopCount <= MAX_LOOP_COUNT)
      {
        foreach (var solver in _Solvers)
        {
          _GameBoard = solver.Solve(_GameBoard);
        }

        LogPencilMarks();
        notSolved = IsGameUnsolved();
        if (_BoardHadActivity)
        {
          boardHadNoActivityCount = 0;
        }
        else
        {
          boardHadNoActivityCount++;
        }
        loopCount++;
        _BoardHadActivity = false;
      }
      return _GameBoard;
    }

    public void RegisterSolvers(IEnumerable<ISolver> solvers)
    {
      _Solvers = solvers;
    }

    private static IEnumerable<ISolver> CollectDefaultSolversForEngine()
    {
      var solverList = new List<ISolver>
      {
        new SinglePencilMarkLeftSolver(),
        new SinglePencilMarkAcrossGroupColumnRowSolver(),
        new StraightLineRemovesPencilMarksSolver(),
        new Pattern01Solver()
      };
      return solverList;
    }

    private bool IsGameUnsolved()
    {
      var atLeastOneCellNotSolved = _GameBoard.GetCells().Any(x => x.Value is null);
      return atLeastOneCellNotSolved;
    }

    private void EnsureGameBoardProvided()
    {
      var gameBoardNotProvided = !_GameBoard.GetCells().Any();
      if (gameBoardNotProvided)
      {
        throw new NoGameBoardProvided("GameBoard NOT provided");
      }
    }

    private void LogPencilMarks()
    {
      Trace.WriteLine($"Pencil Marks: ");
      Trace.Indent();
      foreach (var cell in _GameBoard.GetCells())
      {
        if (cell.Value is null)
        {
          Trace.WriteLine(
            $"Cell Index: {cell.Index} => Pencil Marks: {string.Join(",", cell.GetPencilMarks())}"); //add missing numbers as pencil marks to cell 
        }
      }
      Trace.Unindent();
    }
  }
}