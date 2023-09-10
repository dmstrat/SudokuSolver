using Sudoku.GameBoard;

namespace Sudoku.Engine.Solvers
{
  /// <summary>
  /// NAME: TBD
  /// This pattern is for removing a group's other pencil marks when a row or column
  ///   contains the same number of values as there are empty cells
  /// Example 1: Group 3's top row is completely empty and
  ///   the unique pencil marks for that row are only 3 numbers: let's say 1,2,3
  ///   in any configuration (such as cell1='1,2', cell2='2,3', cell3='1,3')
  ///   We can now remove '1,2,3' from the other cells in this group.
  /// Example 2: Group 3's top row has a value in 1 cell and
  ///   the unique pencil marks for the remaining cells in that row are only 2 numbers:
  ///   let's say 1,2 in any configuration (such as cell1='1,2', cell2='1,2')
  ///   We can now remove '1,2' from the other cells in this group.
  /// </summary>
  public class Pattern02Solver : ISolver
  {
    public IGameBoard GetGameBoard()
    {
      throw new NotImplementedException();
    }

    public int Solve(IGameBoard gameBoard)
    {
      throw new NotImplementedException();
    }

    public int GetExecutionOrder()
    {
      throw new NotImplementedException();
    }
  }
}
