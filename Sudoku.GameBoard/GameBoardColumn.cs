namespace Sudoku.GameBoard;

public class GameBoardColumn
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
}