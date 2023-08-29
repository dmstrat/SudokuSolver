using System.Diagnostics;
using Sudoku.Engine.Solvers;
using Sudoku.Engine.Tests.Builders;
using Sudoku.Engine.Tests.TestBoards;
using Sudoku.GameBoard;

namespace Sudoku.Engine.Tests.Solvers
{
  internal class StraightLineRemovesPencilMarksSolverTests
  {
    private ConsoleTraceListener _Listener;

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

    [TestCase(GameBoard01.MissingOneNumberPerRowAndColumn_Input, GameBoard01.Solved_Output)]
    [TestCase(GameBoard01.MissingOneValueFromOneGroup_Input, GameBoard01.Solved_Output)]
    [TestCase(GameBoardMedium01.Game_Input, GameBoardMedium01.Game_Output)]
    [TestCase(GameBoardForStraightLineTests.Game_Input, GameBoardForStraightLineTests.Game_Output)]
    public void GivenBoard01SolveResultsCorrectHavingSingleStraightLineValueInGroupColumnRowSolver(string gameBoardInput, string solvedGameOutput)
    {
      //Build Game Board
      //Instance Engine 
      var gameBoard = GameBoardFactory.Create(gameBoardInput);
      var engine = new Engine(gameBoard);
      var solvers = new List<ISolver> { new StraightLineRemovesPencilMarksSolver() };
      engine.RegisterSolvers(solvers);
      //Solve 
      var result = engine.Solve();
      //Verify solve 
      var actualResults = result.GetValuesAsString();
      Assert.That(actualResults, Is.EqualTo(solvedGameOutput));
    }

    [TestCase(GameBoard01.MissingOneValueFromOneGroup_Input, 5,8,3, new []{1,8,9}, new []{1,8})]
    [TestCase(GameBoard01.MissingOneValueFromOneGroup_Input, 8, 8, 6, new [] {1,2,9}, new[] { 1, 2 })]
    public void GivenBoardDetermineStraightLinesOfValuesInGroupsAndRemovePencilMarksFromOtherCells(string gameBoardInput, 
      int groupIndex, int cellColumnIndex, int cellRowIndex, int[] startingPencilMarks, int[] expectedPencilMarks)
    {
      //Build Game Board WITH PencilMarks
      //solve for columns with single value for group
      var gameBoard = GameBoardBuilder.Build(gameBoardInput);
      var solver = new StraightLineRemovesPencilMarksSolver();

      var cellAtRow4Column9OriginalPencilMarks = gameBoard.GetGroups().First(x => x.Index == groupIndex).Cells
        .First(x => x.ColumnIndex == cellColumnIndex && x.RowIndex == cellRowIndex).PencilMarks;
      Assert.That(cellAtRow4Column9OriginalPencilMarks, Is.EqualTo(startingPencilMarks));

      var group3 = gameBoard.GetGroups().First(x=>x.Index == 2);
      solver.SolveBy(gameBoard, group3);

      //assert cell at given column and row index has the provided pencils marks EXACTLY
      var cellAtRow4Column9PencilMarks = gameBoard.GetGroups().First(x => x.Index == groupIndex).Cells
        .First(x => x.ColumnIndex == cellColumnIndex && x.RowIndex == cellRowIndex).PencilMarks;

      Assert.That(cellAtRow4Column9PencilMarks, Is.EqualTo(expectedPencilMarks));
    }
  }
}
