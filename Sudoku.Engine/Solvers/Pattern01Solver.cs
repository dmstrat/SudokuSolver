using Sudoku.GameBoard;

namespace Sudoku.Engine.Solvers
{
  /// <summary>
  /// This pattern is for removing a group's other pencil marks when a row or column
  ///   is the only possible choices for that entire row or column for that value.
  /// Example: Group 3 has 7 cells that COULD be a '6', but looking across the top row
  ///   you find those '6's are the only place a '6' can be placed for the entire row
  ///   across the board.  You now remove all the other '6' values from that group leaving
  ///   a straight line of pencil marks for that row.
  /// </summary>
  public class Pattern01Solver : ISolver
  {
    public IGameBoard Solve(IGameBoard gameBoard)
    {
      foreach (var group in gameBoard.GetGroups())
      {
        SolveBy(gameBoard, group);
      }
      return gameBoard;
    }

    private void SolveBy(IGameBoard gameBoard, IGameBoardGroup group)
    {
      SolveByColumns(gameBoard, group);
      SolveByRows(gameBoard, group);
    }

    private void SolveByRows(IGameBoard gameBoard, IGameBoardGroup group)
    {
      var topRow = group.GetRowCells(RowPosition.Top);
      var middleRow = group.GetRowCells(RowPosition.Middle);
      var bottomRow = group.GetRowCells(RowPosition.Bottom);

      var distinctNumbersInTopRow = topRow.Cells.SelectMany(x => x.PencilMarks).Distinct();
      var distinctNumbersInMiddleRow = middleRow.Cells.SelectMany(x => x.PencilMarks).Distinct();
      var distinctNumbersInBottomRow = bottomRow.Cells.SelectMany(x => x.PencilMarks).Distinct();

      var emptyCellCountForTopRow = topRow.Cells.Count(x => !x.Value.HasValue);
      var emptyCellCountForMiddleRow = middleRow.Cells.Count(x => !x.Value.HasValue);
      var emptyCellCountForBottomRow = bottomRow.Cells.Count(x => !x.Value.HasValue);

      var clearOtherCellsFromTheseTopNumbers = emptyCellCountForTopRow > 0 && distinctNumbersInTopRow.Count() == emptyCellCountForTopRow;
      var clearOtherCellsFromTheseMiddleNumbers = emptyCellCountForMiddleRow > 0 && distinctNumbersInMiddleRow.Count() == emptyCellCountForMiddleRow;
      var clearOtherCellsFromTheseBottomNumbers = emptyCellCountForBottomRow > 0 && distinctNumbersInBottomRow.Count() == emptyCellCountForBottomRow;

      if (clearOtherCellsFromTheseTopNumbers)
      {
        var row = gameBoard.GetRowBy(topRow.Cells.First());
        row.ClearPencilMarksNotIn(topRow);
        group.ClearPencilMarksNotIn(topRow);
      }

      if (clearOtherCellsFromTheseMiddleNumbers)
      {
        var row = gameBoard.GetRowBy(middleRow.Cells.First());
        row.ClearPencilMarksNotIn(middleRow);
        group.ClearPencilMarksNotIn(middleRow);
      }

      if (clearOtherCellsFromTheseBottomNumbers)
      {
        var row = gameBoard.GetRowBy(bottomRow.Cells.First());
        row.ClearPencilMarksNotIn(bottomRow);
        group.ClearPencilMarksNotIn(bottomRow);
      }
    }

    private void SolveByColumns(IGameBoard gameBoard, IGameBoardGroup group)
    {
      //get left, middle, right columns 

      var leftColumn = group.GetColumnCells(ColumnPosition.Left);
      var middleColumn = group.GetColumnCells(ColumnPosition.Middle);
      var rightColumn = group.GetColumnCells(ColumnPosition.Right);

      var distinctNumbersInLeftColumn = leftColumn.Cells.SelectMany(x => x.PencilMarks).Distinct();
      var distinctNumbersInMiddleColumn = middleColumn.Cells.SelectMany(x => x.PencilMarks).Distinct();
      var distinctNumbersInRightColumn = rightColumn.Cells.SelectMany(x => x.PencilMarks).Distinct();

      var emptyCellCountForLeftColumn = leftColumn.Cells.Count(x => !x.Value.HasValue);
      var emptyCellCountForMiddleColumn = middleColumn.Cells.Count(x => !x.Value.HasValue);
      var emptyCellCountForRightColumn = rightColumn.Cells.Count(x => !x.Value.HasValue);

      var clearOtherCellsFromTheseLeftNumbers = emptyCellCountForLeftColumn > 0 && distinctNumbersInLeftColumn.Count() == emptyCellCountForLeftColumn;
      var clearOtherCellsFromTheseMiddleNumbers = emptyCellCountForMiddleColumn > 0 && distinctNumbersInMiddleColumn.Count() == emptyCellCountForMiddleColumn;
      var clearOtherCellsFromTheseRightNumbers = emptyCellCountForRightColumn > 0 && distinctNumbersInRightColumn.Count() == emptyCellCountForRightColumn;

      if (clearOtherCellsFromTheseLeftNumbers)
      {
        //call clear column and group
        var column = gameBoard.GetColumnBy(leftColumn.Cells.First());
        column.ClearPencilMarksNotIn(leftColumn);
        group.ClearPencilMarksNotIn(leftColumn);
      }

      if (clearOtherCellsFromTheseMiddleNumbers)
      {
        //call clear column and group
        var column = gameBoard.GetColumnBy(middleColumn.Cells.First());
        column.ClearPencilMarksNotIn(middleColumn);
        group.ClearPencilMarksNotIn(middleColumn);
      }

      if (clearOtherCellsFromTheseRightNumbers)
      {
        //call clear column and group
        var column = gameBoard.GetColumnBy(rightColumn.Cells.First());
        column.ClearPencilMarksNotIn(rightColumn);
        group.ClearPencilMarksNotIn(rightColumn);
      }

    }
  }
}
