namespace Sudoku.Engine.Exceptions
{
  public class NoGameBoardProvided : Exception
  {
    private const string GameDefaultMessage = "GameBoard Group Number is INVALID.";
    public NoGameBoardProvided() { }

    public NoGameBoardProvided(string message = GameDefaultMessage) : base(message) { }

    public NoGameBoardProvided(string message, Exception innerException) : base(message, innerException) { }

  }
}
