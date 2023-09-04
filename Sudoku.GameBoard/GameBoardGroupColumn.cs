using System.Collections;

namespace Sudoku.GameBoard;

public class GameBoardGroupColumn 
{
  public IEnumerable<GameCell> Cells { get; set; }

  public GameBoardGroupColumn(IEnumerable<GameCell> inputGameCells)
  {
    Cells = inputGameCells;
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

  /// <summary>
  /// Get Distinct List of Pencil Marks for this groupColumn cells
  /// </summary>
  /// <returns></returns>
  public IEnumerable<int> GetPencilMarks()
  {
    var distinctPencilMarks = Cells.SelectMany(x => x.PencilMarks).Distinct(); //.Select() Select(x=>x.PencilMarks).Select(y=>y.GetEnumerator().Current).ToList().Distinct();
    return distinctPencilMarks;
  }
}