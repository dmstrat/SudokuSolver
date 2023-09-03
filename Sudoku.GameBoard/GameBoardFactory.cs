using Microsoft.Extensions.Logging;
using System.Globalization;

namespace Sudoku.GameBoard
{
  public static class GameBoardFactory
  {
    private static readonly int NumberOfGameCellsInGame = 81;
    private const string EMPTY_VALUE_AS_SPACE = " ";
    private const string EMPTY_VALUE_AS_ZERO = "0";
    private const bool IS_NOT_PUZZLE_VALUE = false;
    private const bool IS_PUZZLE_VALUE = true;

    public static GameBoard Create(string gameBoardWithPuzzleNumbers, ILogger logger)
    {
      var gameCells = new List<GameCell>();
      for (int i = 0; i < NumberOfGameCellsInGame; i++)
      {
        var unparsedNextValue = gameBoardWithPuzzleNumbers[i].ToString();
        var isEmptyCellValue = unparsedNextValue is EMPTY_VALUE_AS_SPACE or EMPTY_VALUE_AS_ZERO;

        GameCell newCell;
        if (isEmptyCellValue)
        {
          newCell = GameCellFactory.Create(null, IS_NOT_PUZZLE_VALUE, i, logger);
        }
        else
        {
          _ = int.TryParse(unparsedNextValue, NumberStyles.Integer, null, out var nextNumber);
          newCell = GameCellFactory.Create(nextNumber, IS_PUZZLE_VALUE, i, logger);
        }
        gameCells.Add(newCell);
      }

      var newBoard = new GameBoard(gameCells, logger);
      newBoard.Validate();
      return newBoard;
    }
  }
}
