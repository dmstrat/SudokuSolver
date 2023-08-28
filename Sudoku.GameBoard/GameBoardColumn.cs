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

  public void ClearPencilMarksNotIn(GameBoardGroup group, int valueToClear)
  {
    var cellsNotInGroup = Cells.Where(x => x.GroupIndex != group.Cells.First().GroupIndex);

    foreach (var cell in cellsNotInGroup)
    {
      cell.ClearPencilMark(valueToClear);
    }
  }
}

public interface IGameBoardColumn
{
  public void ClearPencilMark(int? cellValue);
}