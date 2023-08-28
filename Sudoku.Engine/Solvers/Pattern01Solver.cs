using Sudoku.GameBoard;

namespace Sudoku.Engine.Solvers
{
  /// <summary>
  /// This pattern is for removing a group's other pencil marks when a row or column
  ///   is the only possible choices for that entire row or column for that value.
  /// Example: Group 3 has 7 cells that COULD be a '6', but looking across the top row
  ///   you find those '6's are the only place a '6' can be placed for the entire row
  ///   across the board.  You now remove all the other '6' values from that group leaving
  ///   a straight line of pencil marks for that row.
  /// </summary>
  public class Pattern01Solver : ISolver
  {
    public IGameBoard Solve(IGameBoard gameBoard)
    {
      return gameBoard;
    }
  }
}
