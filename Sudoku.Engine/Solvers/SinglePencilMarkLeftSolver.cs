using Sudoku.GameBoard;

namespace Sudoku.Engine.Solvers
{
  public class SinglePencilMarkLeftSolver : ISolver
  {
    public IGameBoard Solve(IGameBoard gameBoard)
    {
      var cellsToSolve = gameBoard.Cells.Where(x => !x.Value.HasValue);
      bool didWork;
      do
      {
        didWork = false;
        foreach (var cell in cellsToSolve)
        {
          //solve cell if there is only one pencil mark
          var onlyOneChoice = cell.PencilMarks.Count() == 1;
          if (onlyOneChoice)
          {
            cell.Value = cell.PencilMarks.First();
            didWork = true;
          }
        }
      } while (didWork);

      return gameBoard;
    }
  }
}
