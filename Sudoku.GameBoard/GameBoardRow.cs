﻿using Sudoku.GameBoard;

namespace Sudoku.GameBoard;

public class GameBoardRow : IGameBoardRow
{
  public IEnumerable<GameCell> Cells { get; set; }

  public GameBoardRow(IEnumerable<GameCell> inputGameCells)
  {
    Cells = inputGameCells;
  }

  public string GetAsString()
  {
    var newString = Cells.Select(x => x.Value).Aggregate("", (current, next) => current + (next.HasValue ? next.ToString() : " "));
    return newString;
  }

  public void ClearPencilMark(int? cellValue)
  {
    var noWorkToDo = !cellValue.HasValue;
    if (noWorkToDo) return;
    foreach (var cell in Cells)
    {
      cell.ClearPencilMark(cellValue!.Value);
    }
  }

  public void ClearPencilMarksNotIn(GameBoardRow groupRow)
  {
    var distinctPencilMarksInGroupColumn = groupRow.Cells.SelectMany(x => x.PencilMarks).Distinct();
    ClearPencilMarksNotIn(groupRow.Cells, distinctPencilMarksInGroupColumn);
  }

  private void ClearPencilMarksNotIn(IEnumerable<GameCell> cells, IEnumerable<int> valuesToClear)
  {
    var cellsNotProvided = Cells.Except(cells);

    foreach (var number in valuesToClear)
    {
      foreach (var cell in cellsNotProvided)
      {
        cell.ClearPencilMark(number);
      }
    }
  }
}