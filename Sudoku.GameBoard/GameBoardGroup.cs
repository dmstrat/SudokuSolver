namespace Sudoku.GameBoard;

public class GameBoardGroup
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
}