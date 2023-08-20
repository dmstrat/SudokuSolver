namespace Sudoku.GameBoard;

public class GameBoardRow
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
}