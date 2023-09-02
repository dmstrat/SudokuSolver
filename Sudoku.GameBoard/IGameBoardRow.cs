namespace Sudoku.GameBoard;

public interface IGameBoardRow
{
  public void ClearPencilMark(int? cellValue);
  public void ClearPencilMarksNotIn(GameBoardGroupRow row);
  public void ClearPencilMarksNotIn(IGameBoardGroup group, IEnumerable<int> valueToClear);
}