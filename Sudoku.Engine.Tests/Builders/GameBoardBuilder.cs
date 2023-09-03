using Microsoft.Extensions.Logging;
using Sudoku.GameBoard;

namespace Sudoku.Engine.Tests.Builders
{
  internal static class GameBoardBuilder
  {
    public static IGameBoard Build(string gameBoardInput, ILogger logger)
    {
      var gameBoard = GameBoardFactory.Create(gameBoardInput);
      var pencilMarksGenerator = new PencilMarksGenerator(logger);
      var gameBoardWithPencilMarks = pencilMarksGenerator.GeneratePencilMarks(gameBoard);
      return gameBoardWithPencilMarks;
    }
  }
}
