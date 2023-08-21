namespace Sudoku.GameBoard;

public interface IGameCell
{
  public bool IsPuzzleValue { get; }
  public int? Value { get; set; }
  public IEnumerable<int> PencilMarks { get; set; }
  public int GetGroupIndex();
  public int GetRowIndex();
  public int GetColumnIndex();
  public void ClearPencilMark(int cellValue);
}