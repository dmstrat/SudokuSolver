// ReSharper disable InconsistentNaming
namespace Sudoku.GameBoard;

public interface IGameCell
{
  public event CellValueUpdated OnChanged;
  public event CellPencilMarksChanged OnPencilMarksChanged;

  public int Index { get; }
  public int? Value { get; set; }
  public bool IsPuzzleValue { get; }
  public int GroupIndex { get; }
  public int RowIndex { get; }
  public int ColumnIndex { get; }
  public IEnumerable<int> PencilMarks { get; }
  public ColumnPosition ColumnPosition { get; }
  public RowPosition RowPosition { get; }
  public void AddPencilMarks(int[] pencilMarks);
  public void AddPencilMark(int pencilMark);
  public void ClearPencilMark(int pencilMark);
  void ClearPencilMarks();
}