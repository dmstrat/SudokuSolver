using Sudoku.GameBoard;

namespace Sudoku.Engine.Solvers
{
  public class AicSolver : ISolver
  {
    private IGameBoard _GameBoard;

    public IGameBoard GetGameBoard()
    {
      return _GameBoard;
    }

    public int Solve(IGameBoard gameBoard)
    {
      _GameBoard = gameBoard;
      return SolverReturnCodes.NoChanges;
    }

    public int GetExecutionOrder()
    {
      return SolverExecutionOrder.LastDigit;
    }
  }
}
