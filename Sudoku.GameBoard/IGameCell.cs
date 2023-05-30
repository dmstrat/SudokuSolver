namespace Sudoku.GameBoard;

public interface IGameCell
{
  public bool IsPuzzleValue { get; }
  public int? Value { get; set; }
}