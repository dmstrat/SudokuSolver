using Sudoku.GameBoard.Constants;

namespace Sudoku.GameBoard.Helpers
{
  internal static class GameBoardHelper
  {

    internal static IEnumerable<int> GetGroupIndexList(int groupNumber)
    {
      var indexList = groupNumber switch
      {
        1 => GameBoardGroupCellNumbers.GroupNumber1,
        2 => GameBoardGroupCellNumbers.GroupNumber2,
        3 => GameBoardGroupCellNumbers.GroupNumber3,
        4 => GameBoardGroupCellNumbers.GroupNumber4,
        5 => GameBoardGroupCellNumbers.GroupNumber5,
        6 => GameBoardGroupCellNumbers.GroupNumber6,
        7 => GameBoardGroupCellNumbers.GroupNumber7,
        8 => GameBoardGroupCellNumbers.GroupNumber8,
        9 => GameBoardGroupCellNumbers.GroupNumber9,
        _ => Array.Empty<int>()
      };
      return indexList;
    }

    internal static IEnumerable<int> GetRowIndexList(int rowNumber)
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

    internal static IEnumerable<int> GetColumnIndexList(int columnNumber)
    {
      var indexList = columnNumber switch
      {
        1 => GameBoardColumnCellNumbers.ColumnNumber1,
        2 => GameBoardColumnCellNumbers.ColumnNumber2,
        3 => GameBoardColumnCellNumbers.ColumnNumber3,
        4 => GameBoardColumnCellNumbers.ColumnNumber4,
        5 => GameBoardColumnCellNumbers.ColumnNumber5,
        6 => GameBoardColumnCellNumbers.ColumnNumber6,
        7 => GameBoardColumnCellNumbers.ColumnNumber7,
        8 => GameBoardColumnCellNumbers.ColumnNumber8,
        9 => GameBoardColumnCellNumbers.ColumnNumber9,
        _ => Array.Empty<int>()
      };
      return indexList;
    }


  }
}
