namespace Sudoku.GameBoard;

public class GameBoardGroupRow
{
  public IEnumerable<GameCell> Cells { get; set; }

  public GameBoardGroupRow(IEnumerable<GameCell> inputGameCells)
  {
    Cells = inputGameCells;
  }

  public IEnumerable<GameCell> GetCells()
  {
    return Cells;
  }

  public string GetValuesAsString()
  {
    var newString = Cells.Select(x => x.Value).Aggregate("", (current, next) => current + (next.HasValue ? next.ToString() : " "));
    return newString;
  }

  public void ClearPencilMarks(int? cellValue)
  {
    var noWorkToDo = !cellValue.HasValue;
    if (noWorkToDo) return;
    foreach (var cell in Cells)
    {
      cell.ClearPencilMark(cellValue!.Value);
    }
  }

  public IEnumerable<int> GetPencilMarks()
  {
    var distinctPencilMarks = Cells.SelectMany(x => x.GetPencilMarks()).Distinct();
    return distinctPencilMarks;
  }
}