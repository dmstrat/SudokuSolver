using Sudoku.GameBoard.Constants;
using Sudoku.GameBoard.Exceptions;

namespace Sudoku.GameBoard.Helpers
{
    internal static class GameBoardHelper
  {

    internal static int GetGroupIndexBy(int cellIndex)
    {
      var foundGroupIndex = GameBoardGroupCellIndexes.GroupIndexes.FirstOrDefault(x => x.Value.Contains(cellIndex)).Key;// !=null ? true : false;
      return foundGroupIndex;
    }

    internal static IEnumerable<int> GetGroupCellIndexesBy(int groupNumber)
    {
      var indexList = groupNumber switch
      {
        1 => GameBoardGroupCellIndexes.GroupNumber1,
        2 => GameBoardGroupCellIndexes.GroupNumber2,
        3 => GameBoardGroupCellIndexes.GroupNumber3,
        4 => GameBoardGroupCellIndexes.GroupNumber4,
        5 => GameBoardGroupCellIndexes.GroupNumber5,
        6 => GameBoardGroupCellIndexes.GroupNumber6,
        7 => GameBoardGroupCellIndexes.GroupNumber7,
        8 => GameBoardGroupCellIndexes.GroupNumber8,
        9 => GameBoardGroupCellIndexes.GroupNumber9,
        _ => Array.Empty<int>()
      };
      return indexList;
    }

    internal static IEnumerable<int> GetRowCellIndexesBy(int rowNumber)
    {
      var indexList = rowNumber switch
      {
        1 => GameBoardRowCellNumbers.RowNumber1,
        2 => GameBoardRowCellNumbers.RowNumber2,
        3 => GameBoardRowCellNumbers.RowNumber3,
        4 => GameBoardRowCellNumbers.RowNumber4,
        5 => GameBoardRowCellNumbers.RowNumber5,
        6 => GameBoardRowCellNumbers.RowNumber6,
        7 => GameBoardRowCellNumbers.RowNumber7,
        8 => GameBoardRowCellNumbers.RowNumber8,
        9 => GameBoardRowCellNumbers.RowNumber9,
        _ => Array.Empty<int>()
      };
      return indexList;
    }

    internal static IEnumerable<int> GetColumnCellIndexesBy(int columnNumber)
    {
      var indexList = columnNumber switch
      {
        1 => GameBoardColumnCellIndexes.ColumnNumber1,
        2 => GameBoardColumnCellIndexes.ColumnNumber2,
        3 => GameBoardColumnCellIndexes.ColumnNumber3,
        4 => GameBoardColumnCellIndexes.ColumnNumber4,
        5 => GameBoardColumnCellIndexes.ColumnNumber5,
        6 => GameBoardColumnCellIndexes.ColumnNumber6,
        7 => GameBoardColumnCellIndexes.ColumnNumber7,
        8 => GameBoardColumnCellIndexes.ColumnNumber8,
        9 => GameBoardColumnCellIndexes.ColumnNumber9,
        _ => Array.Empty<int>()
      };
      return indexList;
    }

    internal static ColumnPosition GetColumnPosition(int cellIndex)
    {
      var modulus = cellIndex % 9;
      var columnPosition = modulus switch
      {
        0 => ColumnPosition.Left,
        1 => ColumnPosition.Middle,
        2 => ColumnPosition.Right,
        3 => ColumnPosition.Left,
        4 => ColumnPosition.Middle,
        5 => ColumnPosition.Right,
        6 => ColumnPosition.Left,
        7 => ColumnPosition.Middle,
        8 => ColumnPosition.Right,
        _ => ThrowInvalidColumnIndexException()
      };

      return columnPosition;
    }

    private static ColumnPosition ThrowInvalidColumnIndexException()
    {
      throw new InternalException("Invalid column index for some reason, this shouldn't get out in the wild.");
    }

    internal static RowPosition GetRowPositionBy(int cellIndex)
    {
      var isTopRow = GameBoardRowGroupPositionCellNumbers.Top.Contains(cellIndex);

      if (isTopRow)
      {
        return RowPosition.Top;
      }

      var isMiddleRow = GameBoardRowGroupPositionCellNumbers.Middle.Contains(cellIndex);
      if (isMiddleRow)
      {
        return RowPosition.Middle;
      }

      return RowPosition.Bottom;
    }

    private static RowPosition ThrowInvalidRowIndexException()
    {
      throw new InternalException("Invalid row index for some reason, this shouldn't get out in the wild.");
    }

  }
}
