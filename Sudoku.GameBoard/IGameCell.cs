namespace Sudoku.GameBoard;

public interface IGameCell
{
  public bool IsPuzzleValue { get; }
  public int? Value { get; set; }
  public IEnumerable<int> PencilMarks { get; set; }
}