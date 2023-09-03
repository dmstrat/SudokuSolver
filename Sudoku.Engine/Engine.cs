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
    private const int MAX_LOOP_COUNT = 100;
    private readonly IGameBoard _OriginalGameBoard;
    private IGameBoard _GameBoard;
    private IEnumerable<ISolver> _Solvers;
    private bool _BoardHadActivity;
    private const int BOARD_INACTIVITY_MAX_COUNT = 2;
    private ILoggerFactory _LoggerFactory;
    private ILogger _Logger;

    public Engine(IGameBoard gameBoard, ILoggerFactory loggerFactory)
    {
      _LoggerFactory = loggerFactory;
      _Logger = _LoggerFactory.CreateLogger(nameof(Engine));

      _OriginalGameBoard = GameBoardFactory.Create(gameBoard.GetValuesAsString());
      _GameBoard = (GameBoard.GameBoard)gameBoard;
      _Solvers = CollectDefaultSolversForEngine();
      _BoardHadActivity = false;
      gameBoard.OnChanged += SomethingChanged;
    }

    public void SomethingChanged(IGameBoard gameBoard)
    {
      _BoardHadActivity = true;
      _Logger.LogBoardValues(gameBoard.BuildZeroBasedString());
      Trace.WriteLine($"CurrentBoard:{_GameBoard.BuildZeroBasedString()}");
    }

    public IGameBoard Solve()
    {
      EnsureGameBoardProvided();
      var notSolved = true;
      var loopCount = 0;
      var pencilMarksGenerator = new PencilMarksGenerator();
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

    private IEnumerable<ISolver> CollectDefaultSolversForEngine()
    {
      var solverList = new List<ISolver>();
      solverList.Add(new SinglePencilMarkLeftSolver());
      solverList.Add(new SinglePencilMarkAcrossGroupColumnRowSolver());
      solverList.Add(new StraightLineRemovesPencilMarksSolver());
      solverList.Add(new Pattern01Solver());
      return solverList;
    }

    private bool IsGameUnsolved()
    {
      var atLeastOneCellNotSolved = _GameBoard.GetCells().Any(x => x.Value is null);
      return atLeastOneCellNotSolved;
    }

    private void ComputePencilMarks()
    {
      foreach (var cell in _GameBoard.GetCells())
      {
        ComputePencilMarksForCell(cell);
      }
    }

    private void ComputePencilMarksForCell(GameCell cell)
    {
      var numberOfListsJoined = 3;
      var haveWorkToDo = !cell.Value.HasValue;
      if (haveWorkToDo)
      {
        var validGameNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //get group, row, and column
        var group = _GameBoard.GetGroupBy(cell);
        var row = _GameBoard.GetRowBy(cell);
        var column = _GameBoard.GetColumnBy(cell);
        //determine possible pencil marks 
        //what are the missing numbers from group?
        var actualNumberListFromGroup = group.Cells.Select(x => x.Value ?? 0).Except(new List<int>(){0}).ToList();
        var missingNumbersListFromGroup = validGameNumbers.Except<int>(actualNumberListFromGroup);
        //missing numbers from column?
        var actualNumberListFromRow = row.Cells.Select(x => x.Value ?? 0).Except(new List<int>() { 0 }).ToList();
        var missingNumbersListFromRow = validGameNumbers.Except<int>(actualNumberListFromRow);
        //missing numbers from row?
        var actualNumberListFromColumn = column.Cells.Select(x => x.Value ?? 0).Except(new List<int>() { 0 }).ToList();
        var missingNumbersListFromColumn = validGameNumbers.Except<int>(actualNumberListFromColumn);
        //merge missing numbers from all lists
        var allMissingNumbersJoinedTogether = missingNumbersListFromGroup
          .Concat(missingNumbersListFromRow.Concat(missingNumbersListFromColumn));//.Distinct();
        //build list of numbers that are in every list
        var missingNumbers = allMissingNumbersJoinedTogether.GroupBy(val => val)
          .Where(group => group.Count() == numberOfListsJoined)
          .Select(groupValue => groupValue.Key).ToList();

        Trace.WriteLine($"Cell Index: {cell.Index} => Pencil Marks: {string.Join(",", missingNumbers)}");//add missing numbers as pencil marks to cell 
        foreach (var missingNumber in missingNumbers)
        {
          cell.AddPencilMark(missingNumber);
        }
      }
    }

    private void SolveEachCellWithSinglePencilMark()
    {
      foreach (var cell in _GameBoard.GetCells())
      {
        //is cell already solved?
        var cellIsSolved = cell.Value.HasValue;
        if (cellIsSolved)
        {
          continue;
        }

        //solve cell if there is only one pencil mark
        var onlyOneChoice = cell.PencilMarks.Count() == 1;
        if (onlyOneChoice)
        {
          cell.Value = cell.PencilMarks.First();
        }
      }
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
            $"Cell Index: {cell.Index} => Pencil Marks: {string.Join(",", cell.PencilMarks)}"); //add missing numbers as pencil marks to cell 
        }
      }
      Trace.Unindent();
    }
  }
}