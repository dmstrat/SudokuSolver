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

      var leftColumnPencilMarks = leftColumnCells.GetPencilMarks().ToArray();
      var middleColumnPencilMarks = middleColumnCells.GetPencilMarks().ToArray();
      var rightColumnPencilMarks = rightColumnCells.GetPencilMarks().ToArray();

      var numbersOnlyInLeftColumnOfGroup = GenerateListOfUniquePencilMarksFor(leftColumnPencilMarks,
        middleColumnPencilMarks, rightColumnPencilMarks);

      var numbersOnlyInMiddleColumnOfGroup = GenerateListOfUniquePencilMarksFor(middleColumnPencilMarks,
        leftColumnPencilMarks, rightColumnPencilMarks);

      var numbersOnlyInRightColumnOfGroup = GenerateListOfUniquePencilMarksFor(rightColumnPencilMarks,
        middleColumnPencilMarks, leftColumnPencilMarks);

      if (numbersOnlyInLeftColumnOfGroup.Any())
      {
        var gameColumn = gameBoard.GetColumnBy(leftColumnCells.Cells.First());
        gameColumn.ClearPencilMarksNotIn(group, numbersOnlyInLeftColumnOfGroup);
      }

      if (numbersOnlyInMiddleColumnOfGroup.Any())
      {
        var gameColumn = gameBoard.GetColumnBy(middleColumnCells.Cells.First());
        gameColumn.ClearPencilMarksNotIn(group, numbersOnlyInMiddleColumnOfGroup);
      }

      if (numbersOnlyInRightColumnOfGroup.Any())
      {
        var gameColumn = gameBoard.GetColumnBy(rightColumnCells.Cells.First());
        gameColumn.ClearPencilMarksNotIn(group, numbersOnlyInRightColumnOfGroup);
      }
    }

    public void SolveByGroupRows(IGameBoard gameBoard, IGameBoardGroup group)
    {
      var topRowCells = group.GetRowCells(RowPosition.Top);
      var middleRowCells = group.GetRowCells(RowPosition.Middle);
      var bottomRowCells = group.GetRowCells(RowPosition.Bottom);

      var topRowPencilMarks = topRowCells.GetPencilMarks().ToArray();
      var middleRowPencilMarks = middleRowCells.GetPencilMarks().ToArray();
      var bottomRowPencilMarks = bottomRowCells.GetPencilMarks().ToArray();

      var numbersOnlyInTopRowOfGroup =
        GenerateListOfUniquePencilMarksFor(topRowPencilMarks, middleRowPencilMarks, bottomRowPencilMarks);

      var numbersOnlyInMiddleRowOfGroup =
        GenerateListOfUniquePencilMarksFor(middleRowPencilMarks, topRowPencilMarks, bottomRowPencilMarks);

      var numbersOnlyInBottomRowOfGroup =
        GenerateListOfUniquePencilMarksFor(bottomRowPencilMarks, middleRowPencilMarks, topRowPencilMarks);

      if (numbersOnlyInTopRowOfGroup.Any())
      {
        var gameRow = gameBoard.GetRowBy(topRowCells.Cells.First());
        gameRow.ClearPencilMarksNotIn(group, numbersOnlyInTopRowOfGroup);
      }

      if (numbersOnlyInMiddleRowOfGroup.Any())
      {
        var gameRow = gameBoard.GetRowBy(middleRowCells.Cells.First());
        gameRow.ClearPencilMarksNotIn(group, numbersOnlyInMiddleRowOfGroup);
      }

      if (numbersOnlyInBottomRowOfGroup.Any())
      {
        var gameRow = gameBoard.GetRowBy(bottomRowCells.Cells.First());
        gameRow.ClearPencilMarksNotIn(group, numbersOnlyInBottomRowOfGroup);
      }
    }

    private static List<int> GenerateListOfUniquePencilMarksFor(int[] sourceList, int[] otherCollection1,
      int[] otherCollection2)
    {
      var listOfValuesRemaining = new List<int>();
      foreach (var sourceListPencilMark in sourceList)
      {
        var isValuePresentInCollection1 = otherCollection1.Contains(sourceListPencilMark);
        var isValuePresentInCollection2 = otherCollection2.Contains(sourceListPencilMark);
        if (isValuePresentInCollection1 || isValuePresentInCollection2)
        {
          continue;
        }
        listOfValuesRemaining.Add(sourceListPencilMark);
      }
      return listOfValuesRemaining;
    }
  }
}
