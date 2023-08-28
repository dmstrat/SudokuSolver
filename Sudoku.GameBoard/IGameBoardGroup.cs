namespace Sudoku.GameBoard;

public interface IGameBoardGroup
{
  public void ClearPencilMark(int? cellValue);
  public IEnumerable<GameCell> GetCells();
  public GameBoardGroupColumn GetColumnCells(ColumnPosition columnPosition);
  public GameBoardGroupRow GetRowCells(RowPosition rowPosition);
}