using Sudoku.GameBoard;

namespace Sudoku.Engine
{
  internal interface IPencilMarkGenerator
  {
    public IGameBoard GeneratePencilMarks(IGameBoard board);
  }
}
