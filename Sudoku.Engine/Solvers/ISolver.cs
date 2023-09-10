using Sudoku.GameBoard;

namespace Sudoku.Engine.Solvers
{
  public interface ISolver
  {
    public IGameBoard GetGameBoard();
    public int Solve(IGameBoard gameBoard);
    public int GetExecutionOrder();
  }
}
