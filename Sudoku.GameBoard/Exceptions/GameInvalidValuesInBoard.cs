namespace Sudoku.GameBoard.Exceptions
{
  public class GameInvalidValuesInBoard : Exception
  {
    private const string GameDefaultMessage = "GameBoard provided has invalid values.";
    public GameInvalidValuesInBoard() { }

    public GameInvalidValuesInBoard(string message = GameDefaultMessage) : base(message) { }

    public GameInvalidValuesInBoard(string message, Exception innerException) : base(message, innerException) { }

  }
}
