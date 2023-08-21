using Sudoku.Engine.Exceptions;
using Sudoku.GameBoard;
using System.Data;
using System.Diagnostics;

namespace Sudoku.Engine
{
  public class Engine
  {
    private const int MaxLoopCount = 100;
    private readonly IGameBoard _OriginalGameBoard;
    private IGameBoard _GameBoard;
    
    public Engine(IGameBoard gameBoard)
    {
      _OriginalGameBoard = GameBoardFactory.Create(gameBoard.GetValuesAsString());
      _GameBoard = gameBoard;
    }

    public IGameBoard Solve()
    {
      EnsureGameBoardProvided();
      var notSolved = true;
      var loopCount = 0;
      ComputePencilMarks(); 
      while (notSolved && loopCount <= MaxLoopCount)
      {
        SolveEachCellWithSinglePencilMark();
        TryToSolveRows();
        TryToSolveColumns();
        TryToSolveGroups();
        notSolved = IsGameUnsolved();
        loopCount++;
      }
      return _GameBoard;
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
        if (cellIsSolved) continue;
        //solve cell if there is only one pencil mark
        var onlyOneChoice = cell.PencilMarks.Count() == 1;
        if (onlyOneChoice)
        {
          cell.Value = cell.PencilMarks.First();
        }
      }
    }

    private void TryToSolveRows()
    {
      foreach (var row in _GameBoard.GetRows())
      {
        var workToDo = RowIsNotSolved(row);
        if (workToDo)
        {
          TryToSolveRow(row);
        }
      }
    }

    private static bool RowIsNotSolved(GameBoardRow row)
    {
      var emptyCellsInRow = row.Cells.Any(x => x.Value is null);
      return emptyCellsInRow;
    }

    private static void TryToSolveRow(GameBoardRow row)
    {
    }

    private void TryToSolveColumns() { }

    private void TryToSolveGroups() { }

    private void EnsureGameBoardProvided()
    {
      var gameBoardNotProvided = !_GameBoard.GetCells().Any();
      if (gameBoardNotProvided)
      {
        throw new NoGameBoardProvided("GameBoard NOT provided");
      }
    }
  }
}