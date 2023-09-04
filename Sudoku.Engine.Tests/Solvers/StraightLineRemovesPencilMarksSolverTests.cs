using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Sudoku.Engine.Solvers;
using Sudoku.Engine.Tests.Builders;
using Sudoku.Engine.Tests.Loggers;
using Sudoku.Engine.Tests.TestBoards;
using Sudoku.GameBoard;
using System.Diagnostics;

namespace Sudoku.Engine.Tests.Solvers
{
  internal class StraightLineRemovesPencilMarksSolverTests
  {
    private ConsoleTraceListener _Listener;
    private readonly ILoggerFactory _LoggerFactory;
    private ILogger _Logger;

    public StraightLineRemovesPencilMarksSolverTests()
    {
      _LoggerFactory = new NullLoggerFactory();
      _Logger = _LoggerFactory.CreateLogger<StraightLineRemovesPencilMarksSolverTests>();
    }

    [SetUp]
    public void Setup()
    {
      _Listener = new ConsoleTraceListener();
      Trace.Listeners.Add(_Listener);
    }

    [TearDown]
    public void Teardown()
    {
      Trace.Listeners.Remove(_Listener);
    }

    [TestCase(GameBoardForStraightLineTests.Game_Input, GameBoardForStraightLineTests.Game_Output)]
    public void GivenBoard01SolveResultsCorrectHavingSingleStraightLineValueInGroupColumnSolver(string gameBoardInput, string solvedGameOutput)
    {
      _Logger.LogBoardValues(gameBoardInput);
      //Build Game Board
      //Instance Engine 
      var gameBoard = GameBoardFactory.Create(gameBoardInput, _Logger);
      var engine = new Engine(gameBoard, _LoggerFactory);
      var solvers = new List<ISolver> { new StraightLineRemovesPencilMarksSolver() };
      engine.RegisterSolvers(solvers);
      //Solve 
      var result = engine.Solve();
      //Verify solve 

      //group 0, left column should be 7,8,9 -> actual work here as initial pencil marks were 4,5,6,7,8,9
      //group 0, right column should be 4,5,6,7,8,9
      //group 3, left column should be 1,2,3,7,8,9
      //group 3, right column should be 7,8,9
      //group 6, left column should be 4,5,6,7,8,9
      //group 6, middle column should be 7,8,9

      var group0LeftColumnPencilMarks = result.GetGroupBy(result.Cells.First(x => x.Index == 0)).GetColumnCells(ColumnPosition.Left).GetPencilMarks();
      var expectedPencilMarksGroup0LeftColumn = new List<int>() { 7, 8, 9 };
      Assert.That(group0LeftColumnPencilMarks, Is.EquivalentTo(expectedPencilMarksGroup0LeftColumn));

      var group0RightColumnPencilMarks = result.GetGroupBy(result.Cells.First(x => x.Index == 0)).GetColumnCells(ColumnPosition.Right).GetPencilMarks();
      var expectedPencilMarksGroup0RightColumn = new List<int>() { 4, 5, 6, 7, 8, 9 };
      Assert.That(group0RightColumnPencilMarks, Is.EquivalentTo(expectedPencilMarksGroup0RightColumn));

      var group3LeftColumnPencilMarks = result.GetGroupBy(result.Cells.First(x => x.Index == 27)).GetColumnCells(ColumnPosition.Left).GetPencilMarks();
      var expectedPencilMarksGroup3LeftColumn = new List<int>() { 1, 2, 3, 7, 8, 9 };
      Assert.That(group3LeftColumnPencilMarks, Is.EquivalentTo(expectedPencilMarksGroup3LeftColumn));

      var group3RightColumnPencilMarks = result.GetGroupBy(result.Cells.First(x => x.Index == 27)).GetColumnCells(ColumnPosition.Right).GetPencilMarks();
      var expectedPencilMarksGroup3RightColumn = new List<int>() { 7, 8, 9 };
      Assert.That(group3RightColumnPencilMarks, Is.EquivalentTo(expectedPencilMarksGroup3RightColumn));

      var group6LeftColumnPencilMarks = result.GetGroupBy(result.Cells.First(x => x.Index == 54)).GetColumnCells(ColumnPosition.Left).GetPencilMarks();
      var expectedPencilMarksGroup6LeftColumn = new List<int>() { 4, 5, 6, 7, 8, 9 };
      Assert.That(group6LeftColumnPencilMarks, Is.EquivalentTo(expectedPencilMarksGroup6LeftColumn));

      var group6MiddleColumnPencilMarks = result.GetGroupBy(result.Cells.First(x => x.Index == 54)).GetColumnCells(ColumnPosition.Middle).GetPencilMarks();
      var expectedPencilMarksGroup6MiddleColumn = new List<int>() { 7, 8, 9 };
      Assert.That(group6MiddleColumnPencilMarks, Is.EquivalentTo(expectedPencilMarksGroup6MiddleColumn));

    }

    [TestCase(GameBoardForStraightLineRowsTests.Game_Input, GameBoardForStraightLineRowsTests.Game_Output)]
    public void GivenBoard01SolveResultsCorrectHavingSingleStraightLineValueInGroupRowSolver(string gameBoardInput, string solvedGameOutput)
    {
      _Logger.LogBoardValues(gameBoardInput);
      //Build Game Board
      //Instance Engine 
      var gameBoard = GameBoardFactory.Create(gameBoardInput, _Logger);
      var engine = new Engine(gameBoard, _LoggerFactory);
      var solvers = new List<ISolver> { new StraightLineRemovesPencilMarksSolver() };
      engine.RegisterSolvers(solvers);
      //Solve 
      var result = engine.Solve();
      //Verify solve 

      //group 0, top row should be 4,5,6,7,8,9 
      //group 0, bottom row should be 7,8,9 -> actual work here: original pencil marks are 4,5,6,7,8,9
      //group 1, top row should be 7,8,9
      //group 1, bottom row should be 1,2,3,7,8,9
      //group 2, middle row should be 7,8,9
      //group 2, bottom row should be 4,5,6,7,8,9

      var group0TopRowPencilMarks = result.GetGroupBy(result.Cells.First(x => x.Index == 0)).GetRowCells(RowPosition.Top).GetPencilMarks();
      var expectedPencilMarksGroup0TopRow = new List<int>() { 4, 5, 6, 7, 8, 9 };
      Assert.That(group0TopRowPencilMarks, Is.EquivalentTo(expectedPencilMarksGroup0TopRow));

      var group0BottomRow = result.GetGroupBy(result.Cells.First(x => x.Index == 0)).GetRowCells(RowPosition.Bottom).GetPencilMarks();
      var expectedGroup0BottomRow = new List<int>() { 7, 8, 9 };
      Assert.That(group0BottomRow, Is.EquivalentTo(expectedGroup0BottomRow));

      var group1TopRow = result.GetGroupBy(result.Cells.First(x => x.Index == 3)).GetRowCells(RowPosition.Top).GetPencilMarks();
      var expectedGroup1TopRow = new List<int>() { 7, 8, 9 };
      Assert.That(group1TopRow, Is.EquivalentTo(expectedGroup1TopRow));

      var group1BottomRow = result.GetGroupBy(result.Cells.First(x => x.Index == 3)).GetRowCells(RowPosition.Bottom).GetPencilMarks();
      var expectedGroup1BottomRow = new List<int>() { 1, 2, 3, 7, 8, 9 };
      Assert.That(group1BottomRow, Is.EquivalentTo(expectedGroup1BottomRow));

      var group2MiddleRow = result.GetGroupBy(result.Cells.First(x => x.Index == 6)).GetRowCells(RowPosition.Middle).GetPencilMarks();
      var expectedGroup2MiddleRow = new List<int>() { 7, 8, 9 };
      Assert.That(group2MiddleRow, Is.EquivalentTo(expectedGroup2MiddleRow));

      var group2BottomRow = result.GetGroupBy(result.Cells.First(x => x.Index == 6)).GetRowCells(RowPosition.Bottom).GetPencilMarks();
      var expectedGroup2BottomRow = new List<int>() { 4, 5, 6, 7, 8, 9 };
      Assert.That(group2BottomRow, Is.EquivalentTo(expectedGroup2BottomRow));

    }

    [TestCase(GameBoard01.MissingOneValueFromOneGroup_Input, 5, 8, 3, new[] { 1, 8, 9 }, new[] { 1, 8 })]
    [TestCase(GameBoard01.MissingOneValueFromOneGroup_Input, 8, 8, 6, new[] { 1, 2, 9 }, new[] { 1, 2 })]
    public void GivenBoardDetermineStraightLinesOfValuesInGroupsAndRemovePencilMarksFromOtherCells(string gameBoardInput,
      int groupIndex, int cellColumnIndex, int cellRowIndex, int[] startingPencilMarks, int[] expectedPencilMarks)
    {
      //Build Game Board WITH PencilMarks
      //solve for columns with single value for group
      var gameBoard = GameBoardBuilder.Build(gameBoardInput, _Logger);
      var solver = new StraightLineRemovesPencilMarksSolver();

      var cellAtRow4Column9OriginalPencilMarks = gameBoard.Groups.First(x => x.Index == groupIndex).Cells
        .First(x => x.ColumnIndex == cellColumnIndex && x.RowIndex == cellRowIndex).GetPencilMarks();
      Assert.That(cellAtRow4Column9OriginalPencilMarks, Is.EqualTo(startingPencilMarks));

      var group3 = gameBoard.Groups.First(x => x.Index == 2);
      solver.SolveBy(gameBoard, group3);

      //assert cell at given column and row index has the provided pencils marks EXACTLY
      var cellAtRow4Column9PencilMarks = gameBoard.Groups.First(x => x.Index == groupIndex).Cells
        .First(x => x.ColumnIndex == cellColumnIndex && x.RowIndex == cellRowIndex).GetPencilMarks();

      Assert.That(cellAtRow4Column9PencilMarks, Is.EqualTo(expectedPencilMarks));
    }
  }
}
