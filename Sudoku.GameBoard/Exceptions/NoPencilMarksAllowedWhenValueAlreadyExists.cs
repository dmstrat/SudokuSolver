namespace Sudoku.GameBoard.Exceptions
{
  public class NoPencilMarksAllowedWhenValueAlreadyExists : Exception
  {
    private const string GameDefaultMessage = "GameCell can NOT accept pencil marks once a game value is provided.";
    public NoPencilMarksAllowedWhenValueAlreadyExists() { }

    public NoPencilMarksAllowedWhenValueAlreadyExists(string message = GameDefaultMessage) : base(message) { }

    public NoPencilMarksAllowedWhenValueAlreadyExists(string message, Exception innerException) : base(message, innerException) { }

  }
}
