namespace Sudoku.GameBoard.Exceptions
{
  public class InvalidRowNumber : Exception
  {
    private const string GameDefaultMessage = "GameBoard Group Number is INVALID.";
    public InvalidRowNumber() { }

    public InvalidRowNumber(string message = GameDefaultMessage) : base(message) { }

    public InvalidRowNumber(string message, Exception innerException) : base(message, innerException) { }

  }
}
