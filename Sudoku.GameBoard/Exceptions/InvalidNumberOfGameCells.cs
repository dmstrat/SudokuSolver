namespace Sudoku.GameBoard.Exceptions
{
  public class InvalidNumberOfGameCells : Exception
  {
    private const string GameDefaultMessage = "GameBoard provided has invalid values.";
    public InvalidNumberOfGameCells() { }

    public InvalidNumberOfGameCells(string message = GameDefaultMessage) : base(message) { }

    public InvalidNumberOfGameCells(string message, Exception innerException) : base(message, innerException) { }

  }
}
