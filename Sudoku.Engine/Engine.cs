using System.Data;
using Sudoku.GameBoard;
using Sudoku.GameBoard.Constants;

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
        TryToSolveRows();
        TryToSolveColumns();
        TryToSolveGroups();
        loopCount++;
      }
      return _GameBoard;
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
      var haveWorkToDo = !cell.Value.HasValue;
      if (haveWorkToDo)
      {
        var validGameNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //get group, row, and column
        var group = _GameBoard.GetGroupByCellIndex(cell.GroupIndex);
        var row = _GameBoard.GetRowByCellIndex(cell.RowIndex);
        var column = _GameBoard.GetColumnByCellIndex(cell.ColumnIndex);
        //determine possible pencil marks 
        //what are the missing numbers from group?
        //var missingNumbersFromGroup = group.Cells.Select(x => x.Value ?? 0).ToList();
        var actualNumberListFromGroup = group.Cells.Select(x => x.Value ?? 0).ToList();
        var missingNumbersListFromGroup = validGameNumbers.Except<int>(actualNumberListFromGroup);
        //missing numbers from column?
        var actualNumberListFromRow = row.Cells.Select(x => x.Value ?? 0).ToList();
        var missingNumbersListFromRow = validGameNumbers.Except<int>(actualNumberListFromRow);
        //missing numbers from row?
        var actualNumberListFromColumn = column.Cells.Select(x => x.Value ?? 0).ToList();
        var missingNumbersListFromColumn = validGameNumbers.Except<int>(actualNumberListFromColumn);
        //merge missing numbers list 
        var allMissingNumbersWithZero = missingNumbersListFromGroup
          .Concat(missingNumbersListFromRow.Concat(missingNumbersListFromColumn)).Distinct();
        var allMissingNumbers = allMissingNumbersWithZero.Except((new[] { 0 }).ToList());
        //add missing numbers as pencil marks to cell 

        foreach (var missingNumber in allMissingNumbers)
        {
          cell.AddPencilMark(missingNumber);
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

    private bool RowIsNotSolved(GameBoardRow row)
    {
      var emptyCellsInRow = row.Cells.Any(x => x.Value is null);
      return emptyCellsInRow;
    }

    private void TryToSolveRow(GameBoardRow row)
    {
      //any cell with only one pencil mark? 
      //yes, make that cell that value 
      foreach (var cell in row.Cells)
      {
        var onlyOneChoice = cell.PencilMarks.Count() == 1;
        if (onlyOneChoice)
        {
          cell.Value = cell.PencilMarks.First();
        }
      }
    }

    private void TryToSolveColumns() { }

    private void TryToSolveGroups() { }

    private void EnsureGameBoardProvided()
    {
      var gameBoardNotProvided = !_GameBoard.GetCells().Any();
      if (gameBoardNotProvided)
      {

      }
    }
  }
}