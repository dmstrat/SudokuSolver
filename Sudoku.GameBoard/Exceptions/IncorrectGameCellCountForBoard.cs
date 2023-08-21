namespace Sudoku.GameBoard.Exceptions
{
  public class IncorrectGameCellCountForBoard : Exception
  {
    private const string GameDefaultMessage = "GameBoard Group Number is INVALID.";
    public IncorrectGameCellCountForBoard() { }

    public IncorrectGameCellCountForBoard(string message = GameDefaultMessage) : base(message) { }

    public IncorrectGameCellCountForBoard(string message, Exception innerException) : base(message, innerException) { }

  }
}
