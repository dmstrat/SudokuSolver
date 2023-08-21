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
}

public interface IGameBoardRow
{
  public void ClearPencilMark(int? cellValue);
}