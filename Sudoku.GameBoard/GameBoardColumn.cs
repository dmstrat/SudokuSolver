using System.Data;

namespace Sudoku.GameBoard;

public class GameBoardColumn : IGameBoardColumn
{
  public IEnumerable<GameCell> Cells { get; set; }

  public GameBoardColumn(IEnumerable<GameCell> inputGameCells)
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

  public void ClearPencilMarksNotIn(IGameBoardGroup group, IEnumerable<int> valuesToClear)
  {
    var cellsNotInGroup = Cells.Where(x => x.GroupIndex != group.GetCells().First().GroupIndex);
    ClearPencilMarksIn(cellsNotInGroup, valuesToClear);
  }

  public void ClearPencilMarksNotIn(GameBoardGroupColumn groupColumn)
  {
    var distinctPencilMarksInGroupColumn = groupColumn.Cells.SelectMany(x => x.GetPencilMarks()).Distinct();
    ClearPencilMarksNotIn(groupColumn.Cells, distinctPencilMarksInGroupColumn);
  }

  private void ClearPencilMarksIn(IEnumerable<IGameCell> cells, IEnumerable<int> valuesToClear)
  {
    foreach (var cell in cells)
    {
      foreach (var valueToClear in valuesToClear)
      {
        cell.ClearPencilMark(valueToClear);
      }
    }
  }

  private void ClearPencilMarksNotIn(IEnumerable<IGameCell> cells, IEnumerable<int> valuesToClear)
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