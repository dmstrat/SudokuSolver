﻿using Sudoku.GameBoard;
using System.Data;

namespace Sudoku.Engine.Solvers
{
  /// <summary>
  /// NAME: Hidden Single Column
  /// Finds a cell with a single pencil mark among other pencil marks
  /// that is the ONLY pencil mark across the column.
  /// SOLVE cell with this pencil mark.
  /// Example: Searching the pencil marks in a group reveals that there is only one value of '4'
  ///          in a single cell across that group: meaning that cell should be solved to a '4' value.
  /// </summary>
  public class HiddenSingleColumnSolver : ISolver
  {
    private Dictionary<int, int> _ValuesWithCount = new();
    private IGameBoard _GameBoard;

    public int GetExecutionOrder()
    {
      return SolverExecutionOrder.HiddenSingleColumn;
    }

    public IGameBoard GetGameBoard()
    {
      return _GameBoard;
    }

    public int Solve(IGameBoard gameBoard)
    {
      _GameBoard = gameBoard;
      foreach (var cell in _GameBoard.Cells)
      {
        var cellDoesNotQualifyForSolver = cell.Value.HasValue;
        if (cellDoesNotQualifyForSolver)
        {
          continue;
        }

        foreach (var cellPencilMark in cell.PencilMarks)
        {
          var qualifyingPencilMarkForCell = IsHiddenSinglePencilMark(cell, cellPencilMark);
          if (qualifyingPencilMarkForCell)
          {
            cell.Value = cellPencilMark;
            return SolverReturnCodes.ValueFound;
          }
        }
      }
      return SolverReturnCodes.NoChanges;
    }

    private bool IsHiddenSinglePencilMark(GameCell cell, int cellPencilMark)
    {
      //get group, row, and column values
      //check if value is only value across those items
      //if yes, then return that value and stop working. 
      var exceptList = new List<GameCell>() { cell };
      var columnMinusCell = _GameBoard.GetColumnBy(cell).Cells.Except(exceptList).SelectMany(x => x.PencilMarks);
      var cellsPencilMarksGroupedWithCount = columnMinusCell.GroupBy(val => val).Where(numGroup => numGroup.Key == cellPencilMark);
      var pencilMarkQualifiesForSolver = !cellsPencilMarksGroupedWithCount.Any();
      if (pencilMarkQualifiesForSolver)
      {
        return true;
      }
      return false;
    }
  }
}
