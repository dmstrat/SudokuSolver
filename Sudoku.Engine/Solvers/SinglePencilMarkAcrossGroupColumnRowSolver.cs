﻿using System.Data;
using Sudoku.GameBoard;

namespace Sudoku.Engine.Solvers
{
  /// <summary>
  /// This solver will determine if one value in the pencil marks for one cell in a:
  /// group
  /// row
  /// column
  /// is found and will solve that cell.
  /// Example: Searching the pencil marks in a group reveals that there is only one value of '4'
  ///          in a single cell across that group: meaning that cell should be solved to a '4' value.
  /// </summary>
  public class SinglePencilMarkAcrossGroupColumnRowSolver : ISolver
  {
    private IGameBoard _GameBoard;

    public IGameBoard Solve(IGameBoard gameBoard)
    {
      _GameBoard = gameBoard;

      //loop through each row, column, and group: see if there is a single pencil mark regardless of 
      // other pencil marks in that group, row, column

      var groups = _GameBoard.GetGroups();
      foreach (var group in groups)
      {
        var groupedByPencilMarksWithCount = BuildPencilMarksWithCount(group.Cells);
        var pencilMarksWithCountOfOne = groupedByPencilMarksWithCount.Where(x => x.Value == 1);
        foreach (var kvp in pencilMarksWithCountOfOne)
        {
          SolveGroupWithValue(group.Cells, kvp.Key);
        }
      }

      var rows = _GameBoard.GetRows();
      foreach (var row in rows)
      {
        var groupedByPencilMarksWithCount = BuildPencilMarksWithCount(row.Cells);
        var pencilMarksWithCountOfOne = groupedByPencilMarksWithCount.Where(x => x.Value == 1);
        foreach (var kvp in pencilMarksWithCountOfOne)
        {
          SolveGroupWithValue(row.Cells, kvp.Key);
        }
      }

      var columns = _GameBoard.GetColumns();
      foreach (var column in columns)
      {
        var groupedByPencilMarksWithCount = BuildPencilMarksWithCount(column.Cells);
        var pencilMarksWithCountOfOne = groupedByPencilMarksWithCount.Where(x => x.Value == 1);
        foreach (var kvp in pencilMarksWithCountOfOne)
        {
          SolveGroupWithValue(column.Cells, kvp.Key);
        }
      }

      return _GameBoard;
    }

    private void SolveGroupWithValue(IEnumerable<GameCell> gameCells, int valueToSolveInGroup)
    {
      foreach (var cell in gameCells)
      {
        foreach (var cellPencilMark in cell.PencilMarks)
        {
          if (cellPencilMark == valueToSolveInGroup)
          {
            cell.Value = cellPencilMark;
          }
        }
      }
    }

    private Dictionary<int, int> _ValuesWithCount = new();
    private Dictionary<int, int> BuildPencilMarksWithCount(IEnumerable<GameCell> gameCells)
    {
      _ValuesWithCount = new Dictionary<int, int>();

      foreach (var cell in gameCells)
      {
        foreach (var pencilMark in cell.PencilMarks)
        {
          if (_ValuesWithCount.ContainsKey(pencilMark))
          {
            _ValuesWithCount[pencilMark]++;
          }
          else
          {
            _ValuesWithCount.Add(pencilMark, 1);
          }
        }
      }
      return _ValuesWithCount;
    }
  }
}
