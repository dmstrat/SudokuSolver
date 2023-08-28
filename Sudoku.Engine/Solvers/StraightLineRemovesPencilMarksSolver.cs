using System.Data;
using Sudoku.GameBoard;

namespace Sudoku.Engine.Solvers
{
  /// <summary>
  /// This will find a single straight line of pencil marks in one group
  /// then remove pencil marks for that value from the rest of the line (column or row)
  /// </summary>
  public class StraightLineRemovesPencilMarksSolver : ISolver
  {
    private IGameBoard _GameBoard;

    public IGameBoard Solve(IGameBoard gameBoard)
    {
      _GameBoard = gameBoard;
      //var cellsToSolve = _GameBoard.GetCells().Where(x => !x.Value.HasValue);
      foreach (var group in _GameBoard.GetGroups())
      {
        //getLeftColumn, getCenterColumn, getRightColumn
        //topRow, middleRow, bottomRow

        //var cellsThatMightHaveSingleStraightLine = group.Cells.Select()
         /*
        var missingNumbers = group.Cells.GroupBy(x=> x.PencilMarks)
          .Where(theGroup => theGroup.Count() <= 3)
          .Select(groupValue => groupValue.Key).ToList();
           */


        var leftColumnCells = group.GetColumnCells(ColumnPosition.Left);
        var middleColumnCells = group.GetColumnCells(ColumnPosition.Middle);
        var rightColumnCells = group.GetColumnCells(ColumnPosition.Right);

        var leftColumnPencilMarks = leftColumnCells.GetPencilMarks();
        var middleColumnPencilMarks = middleColumnCells.GetPencilMarks();
        var rightColumnPencilMarks = rightColumnCells.GetPencilMarks();



        var noSingleColumn = true; //assume true, unless you find in another column
        var noSingleRow = true; //assume true, unless you find in another row

        var listOfLeftColumnValuesThatAreOnlyInColumn = new List<int>();
        foreach (var leftCellPencilMark in leftColumnPencilMarks)
        {
          //is this value in any other column? 
          var isValuePresentInMiddleColumn = middleColumnPencilMarks.Contains(leftCellPencilMark);
          var isValuePresentInRightColumn = rightColumnPencilMarks.Contains(leftCellPencilMark);
          if (isValuePresentInMiddleColumn && isValuePresentInRightColumn)
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
          if (isValuePresentInLeftColumn && isValuePresentInRightColumn)
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
          if (isValuePresentInMiddleColumn && isValuePresentInLeftColumn)
          {
            continue;
          }
          listOfRightColumnValuesThatAreOnlyInColumn.Add(rightCellPencilMark);
        }


        if (listOfLeftColumnValuesThatAreOnlyInColumn.Any())
        {
          foreach (var value in listOfLeftColumnValuesThatAreOnlyInColumn)
          {
            var firstColumnCellIndex = leftColumnCells.Cells.First().ColumnIndex;
            var gameColumn = _GameBoard.GetColumnBy(leftColumnCells.Cells.First());
            gameColumn.ClearPencilMarksNotIn(group, value);
          }
          //we have columns to clear in other groups
        }

        if (listOfMiddleColumnValuesThatAreOnlyInColumn.Any())
        {
          //we have columns to clear in other groups
          var middle = 3;
        }

        if (listOfRightColumnValuesThatAreOnlyInColumn.Any())
        {
          //we have columns to clear in other groups
          var right = 3;
        }

        /*
        var middleColumnCells = group.GetMiddleColumnCells();
        var rightColumnCells = group.GetRightColumnCells();

        var topRowCells = group.GetTopRowCells();
        var middleRowCells = group.GetMiddleRowCells();
        var bottomRowCells = group.GetBottomRowCells();
          */

        /*
        var onlyOneChoice = group.PencilMarks.Count() == 1;
        if (onlyOneChoice)
        {
          cell.Value = cell.PencilMarks.First();
        } */
      }
      return _GameBoard;
    }
  }
}
