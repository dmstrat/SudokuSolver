namespace Sudoku.GameBoard.Exceptions
{
  public class InvalidColumnNumber : Exception
  {
    private const string GameDefaultMessage = "GameBoard Group Number is INVALID.";
    public InvalidColumnNumber() { }

    public InvalidColumnNumber(string message = GameDefaultMessage) : base(message) { }

    public InvalidColumnNumber(string message, Exception innerException) : base(message, innerException) { }

  }
}
