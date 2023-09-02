namespace Sudoku.GameBoard;

public interface IGameBoardGroup
{
  public void ClearPencilMark(int? cellValue);
  public IEnumerable<GameCell> GetCells();
  public GameBoardGroupColumn GetColumnCells(ColumnPosition columnPosition);
  public GameBoardGroupRow GetRowCells(RowPosition rowPosition);
  public int GetIndex();
  public void ClearPencilMarksNotIn(GameBoardGroupColumn groupColumn);
  public void ClearPencilMarksNotIn(GameBoardGroupRow groupRow);
}