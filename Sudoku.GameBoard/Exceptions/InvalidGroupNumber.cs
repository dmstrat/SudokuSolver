namespace Sudoku.GameBoard.Exceptions
{
  public class InvalidGroupNumber : Exception
  {
    private const string GameDefaultMessage = "GameBoard Group Number is INVALID.";
    public InvalidGroupNumber() { }

    public InvalidGroupNumber(string message = GameDefaultMessage) : base(message) { }

    public InvalidGroupNumber(string message, Exception innerException) : base(message, innerException) { }

  }
}
