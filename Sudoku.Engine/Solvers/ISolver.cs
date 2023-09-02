using Sudoku.GameBoard;

namespace Sudoku.Engine.Solvers
{
  public interface ISolver
  {
    public IGameBoard Solve(IGameBoard gameBoard);
  }
}
