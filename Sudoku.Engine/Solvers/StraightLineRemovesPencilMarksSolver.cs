using Sudoku.GameBoard;

namespace Sudoku.Engine.Solvers
{
  /// <summary>
  /// This will find a single straight line of pencil marks in one group
  /// then remove pencil marks for that value from the rest of the line (column or row)
  /// </summary>
  public class StraightLineRemovesPencilMarksSolver : ISolver
  {
    public IGameBoard Solve(IGameBoard gameBoard)
    {
      foreach (var group in gameBoard.GetGroups())
      {
        SolveBy(gameBoard, group);
      }
      return gameBoard;
    }

    public void SolveBy(IGameBoard gameBoard, GameBoardGroup group)
    {
      SolveByGroupColumns(gameBoard, group);
      SolveByGroupRows(gameBoard, group);
    }

    public void SolveByGroupColumns(IGameBoard gameBoard, IGameBoardGroup group)
    {
      var leftColumnCells = group.GetColumnCells(ColumnPosition.Left);
      var middleColumnCells = group.GetColumnCells(ColumnPosition.Middle);
      var rightColumnCells = group.GetColumnCells(ColumnPosition.Right);

      var leftColumnPencilMarks = leftColumnCells.GetPencilMarks();
      var middleColumnPencilMarks = middleColumnCells.GetPencilMarks();
      var rightColumnPencilMarks = rightColumnCells.GetPencilMarks();

      var listOfLeftColumnValuesThatAreOnlyInColumn = new List<int>();
      foreach (var leftCellPencilMark in leftColumnPencilMarks)
      {
        //is this value in any other column? 
        var isValuePresentInMiddleColumn = middleColumnPencilMarks.Contains(leftCellPencilMark);
        var isValuePresentInRightColumn = rightColumnPencilMarks.Contains(leftCellPencilMark);
        if (isValuePresentInMiddleColumn || isValuePresentInRightColumn)
        {
          continue;
        }

        listOfLeftColumnValuesThatAreOnlyInColumn.Add(leftCellPencilMark);
      }

      var listOfMiddleColumnValuesThatAreOnlyInColumn = new List<int>();
      foreach (var middleCellPencilMark in middleColumnPencilMarks)
      {
        //is this value in any other column? 
        var isValuePresentInLeftColumn = leftColumnPencilMarks.Contains(middleCellPencilMark);
        var isValuePresentInRightColumn = rightColumnPencilMarks.Contains(middleCellPencilMark);
        if (isValuePresentInLeftColumn || isValuePresentInRightColumn)
        {
          continue;
        }

        listOfMiddleColumnValuesThatAreOnlyInColumn.Add(middleCellPencilMark);
      }

      var listOfRightColumnValuesThatAreOnlyInColumn = new List<int>();
      foreach (var rightCellPencilMark in rightColumnPencilMarks)
      {
        //is this value in any other column? 
        var isValuePresentInMiddleColumn = middleColumnPencilMarks.Contains(rightCellPencilMark);
        var isValuePresentInLeftColumn = leftColumnPencilMarks.Contains(rightCellPencilMark);
        if (isValuePresentInMiddleColumn || isValuePresentInLeftColumn)
        {
          continue;
        }

        listOfRightColumnValuesThatAreOnlyInColumn.Add(rightCellPencilMark);
      }


      if (listOfLeftColumnValuesThatAreOnlyInColumn.Any())
      {
        foreach (var value in listOfLeftColumnValuesThatAreOnlyInColumn)
        {
          var gameColumn = gameBoard.GetColumnBy(leftColumnCells.Cells.First());
          gameColumn.ClearPencilMarksNotIn(group, value);
        }
        //we have columns to clear in other groups
      }

      if (listOfMiddleColumnValuesThatAreOnlyInColumn.Any())
      {
        //we have columns to clear in other groups
        foreach (var value in listOfMiddleColumnValuesThatAreOnlyInColumn)
        {
          var gameColumn = gameBoard.GetColumnBy(middleColumnCells.Cells.First());
          gameColumn.ClearPencilMarksNotIn(group, value);
        }
      }

      if (listOfRightColumnValuesThatAreOnlyInColumn.Any())
      {
        //we have columns to clear in other groups
        foreach (var value in listOfRightColumnValuesThatAreOnlyInColumn)
        {
          var gameColumn = gameBoard.GetColumnBy(rightColumnCells.Cells.First());
          gameColumn.ClearPencilMarksNotIn(group, value);
        }
      }
    }

    public void SolveByGroupRows(IGameBoard gameBoard, IGameBoardGroup group)
    {
      var topRowCells = group.GetRowCells(RowPosition.Top);
      var middleRowCells = group.GetRowCells(RowPosition.Middle);
      var bottomRowCells = group.GetRowCells(RowPosition.Bottom);

      var topRowPencilMarks = topRowCells.GetPencilMarks();
      var middleRowPencilMarks = middleRowCells.GetPencilMarks();
      var bottomRowPencilMarks = bottomRowCells.GetPencilMarks();

      var listOfTopRowValuesThatAreOnlyInColumn = new List<int>();
      foreach (var topCellPencilMark in topRowPencilMarks)
      {
        //is this value in any other row? 
        var isValuePresentInMiddleRow = middleRowPencilMarks.Contains(topCellPencilMark);
        var isValuePresentInBottomRow = bottomRowPencilMarks.Contains(topCellPencilMark);
        if (isValuePresentInMiddleRow || isValuePresentInBottomRow)
        {
          continue;
        }

        listOfTopRowValuesThatAreOnlyInColumn.Add(topCellPencilMark);
      }

      var listOfMiddleRowValuesThatAreOnlyInColumn = new List<int>();
      foreach (var middleCellPencilMark in middleRowPencilMarks)
      {
        //is this value in any other row? 
        var isValuePresentInTopRow = topRowPencilMarks.Contains(middleCellPencilMark);
        var isValuePresentInBottomRow = bottomRowPencilMarks.Contains(middleCellPencilMark);
        if (isValuePresentInTopRow || isValuePresentInBottomRow)
        {
          continue;
        }

        listOfMiddleRowValuesThatAreOnlyInColumn.Add(middleCellPencilMark);
      }

      var listOfBottomRowValuesThatAreOnlyInColumn = new List<int>();
      foreach (var bottomCellPencilMark in bottomRowPencilMarks)
      {
        //is this value in any other row? 
        var isValuePresentInMiddleRow = middleRowPencilMarks.Contains(bottomCellPencilMark);
        var isValuePresentInTopRow = topRowPencilMarks.Contains(bottomCellPencilMark);
        if (isValuePresentInMiddleRow || isValuePresentInTopRow)
        {
          continue;
        }

        listOfBottomRowValuesThatAreOnlyInColumn.Add(bottomCellPencilMark);
      }


      if (listOfTopRowValuesThatAreOnlyInColumn.Any())
      {
        foreach (var value in listOfTopRowValuesThatAreOnlyInColumn)
        {
          var gameColumn = gameBoard.GetColumnBy(topRowCells.Cells.First());
          gameColumn.ClearPencilMarksNotIn(group, value);
        }
        //we have row to clear in other groups
      }

      if (listOfMiddleRowValuesThatAreOnlyInColumn.Any())
      {
        //we have row to clear in other groups
        foreach (var value in listOfMiddleRowValuesThatAreOnlyInColumn)
        {
          var gameColumn = gameBoard.GetColumnBy(middleRowCells.Cells.First());
          gameColumn.ClearPencilMarksNotIn(group, value);
        }
      }

      if (listOfBottomRowValuesThatAreOnlyInColumn.Any())
      {
        //we have rows to clear in other groups
        foreach (var value in listOfBottomRowValuesThatAreOnlyInColumn)
        {
          var gameColumn = gameBoard.GetColumnBy(bottomRowCells.Cells.First());
          gameColumn.ClearPencilMarksNotIn(group, value);
        }
      }
    }
  }
}
