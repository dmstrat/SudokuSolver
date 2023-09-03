using System.Globalization;
using Microsoft.Extensions.Logging;
using Sudoku.GameBoard.Helpers;

namespace Sudoku.GameBoard
{
  public static class GameBoardFactory
  {
    private static readonly int NumberOfGameCellsInGame = 81;
    private const string EMPTY_VALUE_AS_SPACE = " ";
    private const string EMPTY_VALUE_AS_ZERO = "0";
    private const bool IS_PART_OF_PUZZLE = true;
    private const bool IS_NOT_PART_OF_PUZZLE = false;

    public static GameBoard Create(string gameBoardWithPuzzleNumbers, ILogger logger)
    {
      var gameCells = new List<GameCell>();
      for (int i = 0; i < NumberOfGameCellsInGame; i++)
      {
        var newValue = gameBoardWithPuzzleNumbers[i].ToString();
        var isEmptyCellValue = newValue is EMPTY_VALUE_AS_SPACE or EMPTY_VALUE_AS_ZERO;
        GameCell newCell;
        var columnPosition = GameBoardHelper.GetColumnPosition(i);
        var rowPosition = GameBoardHelper.GetRowPositionBy(i);
        var groupIndex = GameBoardHelper.GetGroupIndexBy(i);
        if (isEmptyCellValue)
        {
          newCell = new GameCell(i, null, IS_NOT_PART_OF_PUZZLE, groupIndex, columnPosition, rowPosition, logger);
        }
        else
        {
          _ = int.TryParse(gameBoardWithPuzzleNumbers[i].ToString(), NumberStyles.Integer, null, out var nextNumber);
          newCell = new GameCell(i, nextNumber, IS_NOT_PART_OF_PUZZLE, groupIndex, columnPosition, rowPosition, logger);
        }

        gameCells.Add(newCell);
      }

      var newBoard = new GameBoard(gameCells, logger);
      newBoard.Validate();
      return newBoard;
    }
  }
}
