namespace Sudoku.GameBoard;

public class GameBoardGroup : IGameBoardGroup
{
  public IEnumerable<GameCell> Cells { get; set; }

  public GameBoardGroup(IEnumerable<GameCell> inputGameCells)
  {
    Cells = inputGameCells;
  }

  public string GetValuesAsString()
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

public interface IGameBoardGroup
{
  public void ClearPencilMark(int? cellValue);

}