namespace Sudoku.GameBoard.Exceptions
{
  public class InternalException : Exception
  {
    private const string GameDefaultMessage = "Internal Exception occurred.";
    public InternalException() { }

    public InternalException(string message = GameDefaultMessage) : base(message) { }

    public InternalException(string message, Exception innerException) : base(message, innerException) { }

  }
}
