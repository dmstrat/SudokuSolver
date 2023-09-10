using Sudoku.GameBoard;

namespace Sudoku.Engine.Solvers
{
  public class LastDigitSolver : ISolver
  {
    private IGameBoard _GameBoard;

    public IGameBoard GetGameBoard()
    {
      return _GameBoard;
    }

    public int Solve(IGameBoard gameBoard)
    {
      _GameBoard = gameBoard;
      foreach (var cell in _GameBoard.Cells)
      {
        var cellDoesNotQualifyForSolver = cell.Value.HasValue || cell.PencilMarks.Count() > 1;

        if (cellDoesNotQualifyForSolver)
        {
          continue;
        }

        cell.Value = cell.PencilMarks.First();
        return SolverReturnCodes.ValueFound;
      }

      return SolverReturnCodes.NoChanges;
    }

    public int GetExecutionOrder()
    {
      return SolverExecutionOrder.LastDigit;
    }
  }
}
