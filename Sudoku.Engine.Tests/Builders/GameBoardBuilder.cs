using Sudoku.GameBoard;

namespace Sudoku.Engine.Tests.Builders
{
  internal static class GameBoardBuilder
  {
    public static IGameBoard Build(string gameBoardInput)
    {
      var gameBoard = GameBoardFactory.Create(gameBoardInput);
      var pencilMarksGenerator = new PencilMarksGenerator();
      var gameBoardWithPencilMarks = pencilMarksGenerator.GeneratePencilMarks(gameBoard);
      return gameBoardWithPencilMarks;
    }
  }
}
