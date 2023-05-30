namespace Sudoku.GameBoard;

public class GameBoardColumn
{
  public IEnumerable<GameCell> GameCells { get; set; } = new List<GameCell>();

  public GameBoardColumn(IEnumerable<GameCell> inputGameCells)
  {
    GameCells = inputGameCells;
  }

  public string GetAsString()
  {
    var newString = GameCells.Select(x => x.Value).Aggregate("", (current, next) => current + (next.HasValue ? next.ToString() : " "));
    return newString;
  }
}