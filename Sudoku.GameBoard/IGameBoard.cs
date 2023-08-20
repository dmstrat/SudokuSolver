namespace Sudoku.GameBoard
{
  public interface IGameBoard
  {
    public IEnumerable<GameCell> GetCells();
    public IEnumerable<GameBoardGroup> GetGroups();
    public IEnumerable<GameBoardRow> GetRows();
    public IEnumerable<GameBoardColumn> GetColumns();
    public GameCell GetCellByIndex(int cellIndex);
    public string GetValuesAsString();
    public GameBoardGroup GetGroupByCellIndex(int cellIndex);
    public GameBoardRow GetRowByCellIndex(int cellIndex);
    public GameBoardColumn GetColumnByCellIndex(int cellIndex);
  }
}
