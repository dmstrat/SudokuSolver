namespace Sudoku.GameBoard;

public class GameBoardGroup
{
  public IEnumerable<GameCell> GameCells { get; set; } = new List<GameCell>();

  public GameBoardGroup(IEnumerable<GameCell> inputGameCells)
  {
    GameCells = inputGameCells;
  }

  public string GetAsString()
  {
    var newString = GameCells.Select(x => x.Value).Aggregate("", (current, next) => current + (next.HasValue ? next.ToString() : " "));
    return newString;
  }
}