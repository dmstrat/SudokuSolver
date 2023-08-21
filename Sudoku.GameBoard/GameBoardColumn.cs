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
}

public interface IGameBoardColumn
{
  public void ClearPencilMark(int? cellValue);
}