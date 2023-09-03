using Microsoft.Extensions.Logging;
using Sudoku.GameBoard.Constants;
using Sudoku.GameBoard.Helpers;

namespace Sudoku.GameBoard
{
  public static class GameCellFactory
  {
    public static GameCell Create(int? value, bool isPuzzleValue, int cellIndex, ILogger logger)
    {
      var groupIndex = CellIndexToGroupRowColumnValues.CellIndexes[cellIndex, GameGuides.GROUP_ARRAY_INDEX_VALUE];
      var rowIndex = CellIndexToGroupRowColumnValues.CellIndexes[cellIndex, GameGuides.ROW_ARRAY_INDEX_VALUE];
      var columnIndex = CellIndexToGroupRowColumnValues.CellIndexes[cellIndex, GameGuides.COLUMN_ARRAY_INDEX_VALUE];
      var rowPosition = GameBoardHelper.GetRowPositionBy(cellIndex);
      var columnPosition = GameBoardHelper.GetColumnPosition(cellIndex);

      var newCell = new GameCell(value, isPuzzleValue, cellIndex,
                                 groupIndex, rowIndex, columnIndex,
                                 columnPosition, rowPosition, 
                                 logger);

      return newCell;
    }
  }
}
