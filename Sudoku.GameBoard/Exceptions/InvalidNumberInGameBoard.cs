namespace Sudoku.GameBoard.Exceptions
{
  public class InvalidNumberInGameBoard : Exception
  {
    private const string GameDefaultMessage = "GameBoard provided has invalid values.";
    public InvalidNumberInGameBoard() { }

    public InvalidNumberInGameBoard(string message = GameDefaultMessage) : base(message) { }

    public InvalidNumberInGameBoard(string message, Exception innerException) : base(message, innerException) { }

  }
}
