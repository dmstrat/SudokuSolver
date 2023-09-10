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

    internal static IEnumerable<int> GetGroupCellIndexesBy(int groupIndex)
    {
      var indexList = groupIndex switch
      {
        0 => GameBoardGroupCellIndexes.GroupNumber1,
        1 => GameBoardGroupCellIndexes.GroupNumber2,
        2 => GameBoardGroupCellIndexes.GroupNumber3,
        3 => GameBoardGroupCellIndexes.GroupNumber4,
        4 => GameBoardGroupCellIndexes.GroupNumber5,
        5 => GameBoardGroupCellIndexes.GroupNumber6,
        6 => GameBoardGroupCellIndexes.GroupNumber7,
        7 => GameBoardGroupCellIndexes.GroupNumber8,
        8 => GameBoardGroupCellIndexes.GroupNumber9,
        _ => Array.Empty<int>()
      };
      return indexList;
    }

    internal static IEnumerable<int> GetRowCellIndexesBy(int rowIndex)
    {
      var indexList = rowIndex switch
      {
        0 => GameBoardRowCellNumbers.RowNumber1,
        1 => GameBoardRowCellNumbers.RowNumber2,
        2=> GameBoardRowCellNumbers.RowNumber3,
        3 => GameBoardRowCellNumbers.RowNumber4,
        4 => GameBoardRowCellNumbers.RowNumber5,
        5 => GameBoardRowCellNumbers.RowNumber6,
        6 => GameBoardRowCellNumbers.RowNumber7,
        7 => GameBoardRowCellNumbers.RowNumber8,
        8 => GameBoardRowCellNumbers.RowNumber9,
        _ => Array.Empty<int>()
      };
      return indexList;
    }

    internal static IEnumerable<int> GetColumnCellIndexesBy(int columnIndex)
    {
      var indexList = columnIndex switch
      {
        0 => GameBoardColumnCellIndexes.ColumnNumber1,
        1 => GameBoardColumnCellIndexes.ColumnNumber2,
        2 => GameBoardColumnCellIndexes.ColumnNumber3,
        3 => GameBoardColumnCellIndexes.ColumnNumber4,
        4 => GameBoardColumnCellIndexes.ColumnNumber5,
        5 => GameBoardColumnCellIndexes.ColumnNumber6,
        6 => GameBoardColumnCellIndexes.ColumnNumber7,
        7 => GameBoardColumnCellIndexes.ColumnNumber8,
        8 => GameBoardColumnCellIndexes.ColumnNumber9,
        _ => Array.Empty<int>()
      };
      return indexList;
    }

    internal static GroupColumnPosition GetColumnPosition(int cellIndex)
    {
      var modulus = cellIndex % 9;
      var columnPosition = modulus switch
      {
        0 => GroupColumnPosition.Left,
        1 => GroupColumnPosition.Middle,
        2 => GroupColumnPosition.Right,
        3 => GroupColumnPosition.Left,
        4 => GroupColumnPosition.Middle,
        5 => GroupColumnPosition.Right,
        6 => GroupColumnPosition.Left,
        7 => GroupColumnPosition.Middle,
        8 => GroupColumnPosition.Right,
        _ => ThrowInvalidColumnIndexException()
      };
      return columnPosition;
    }

    private static GroupColumnPosition ThrowInvalidColumnIndexException()
    {
      throw new InternalException("Invalid column index for some reason, this shouldn't get out in the wild.");
    }

    internal static GroupRowPosition GetRowPositionBy(int cellIndex)
    {
      var isTopRow = GameBoardRowGroupPositionCellNumbers.Top.Contains(cellIndex);

      if (isTopRow)
      {
        return GroupRowPosition.Top;
      }

      var isMiddleRow = GameBoardRowGroupPositionCellNumbers.Middle.Contains(cellIndex);
      if (isMiddleRow)
      {
        return GroupRowPosition.Middle;
      }

      return GroupRowPosition.Bottom;
    }

    private static GroupRowPosition ThrowInvalidRowIndexException()
    {
      throw new InternalException("Invalid row index for some reason, this shouldn't get out in the wild.");
    }

  }
}
