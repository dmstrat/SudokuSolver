namespace Sudoku.GameBoard;

public interface IGameCell
{
  public event CellValueUpdated OnChanged;
  public event CellPencilMarksChanged OnPencilMarksChanged;

  public bool IsPuzzleValue { get; }
  public int? Value { get; set; }
  public ColumnPosition ColumnPosition { get; }
  public RowPosition RowPosition { get; }
  public int GetGroupIndex();
  public int GetRowIndex();
  public int GetColumnIndex();
  public void ClearPencilMark(int cellValue);
  void ClearPencilMarks();
  public IEnumerable<int> GetPencilMarks();
}