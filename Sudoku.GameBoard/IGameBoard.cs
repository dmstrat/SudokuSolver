namespace Sudoku.GameBoard
{
  public interface IGameBoard
  {
    public event GameBoardHadActivity OnChanged;
    public IList<GameCell> Cells { get; }
    public IList<GameBoardGroup> Groups { get; }
    public IList<GameBoardRow> Rows { get; }
    public IList<GameBoardColumn> Columns { get; }
    public GameCell GetCellByIndex(int cellIndex);
    public string GetValuesAsString();
    public GameBoardGroup GetGroupBy(GameCell cell);
    public GameBoardRow GetRowBy(GameCell cell);
    public GameBoardColumn GetColumnBy(GameCell cell);
    public string BuildZeroBasedString();
    public GameBoardGroup GetGroupBy(int groupIndex);
    public GameBoardRow GetRowBy(int rowIndex);
    public GameBoardColumn GetColumnBy(int columnIndex);
  }
}
