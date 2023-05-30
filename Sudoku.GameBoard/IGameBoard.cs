namespace Sudoku.GameBoard
{
  public interface IGameBoard
  {
    public IEnumerable<GameCell> GetBoardCells();
    public GameCell GetCellByIndex(int cellIndex);
  }
}
