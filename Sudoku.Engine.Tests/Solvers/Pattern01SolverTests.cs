using System.Diagnostics;
using Sudoku.Engine.Solvers;
using Sudoku.Engine.Tests.TestBoards;
using Sudoku.GameBoard;

namespace Sudoku.Engine.Tests.Solvers
{
  internal class Pattern01SolverTests
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

    //[TestCase(GameBoard01.MissingOneNumberPerRowAndColumn_Input, GameBoard01.Solved_Output)]
    [TestCase(GameBoardForStraightLineTests.Game_Input)]
    public void GivenSimpleBoardWithStraightValuesInGroupWillRemovePencilMarksFromRestOfGroup(string gameBoardInput)
    {
      //Build Game Board
      //Instance Engine 
      var gameBoard = GameBoardFactory.Create(gameBoardInput);
      var engine = new Engine(gameBoard);
      var solvers = new List<ISolver> { new Pattern01Solver() };
      engine.RegisterSolvers(solvers);
      //Solve 
      var result = engine.Solve();
      //Verify solve (Pencil Marks as this shouldn't be solving the boards)
      var actualResults = result.GetValuesAsString();
      //Assert.That(actualResults, Is.EqualTo(solvedGameOutput));
    }

    [TestCase(GameBoardForStraightLineRowsTests.Game_Input)]
    public void GivenSimpleBoardWithStraightValuesInGroupWillRemovePencilMarksFromRestOfGroupRowsEdition(string gameBoardInput)
    {
      //Build Game Board
      //Instance Engine 
      var gameBoard = GameBoardFactory.Create(gameBoardInput);
      var engine = new Engine(gameBoard);
      var solvers = new List<ISolver> { new Pattern01Solver() };
      engine.RegisterSolvers(solvers);
      //Solve 
      var result = engine.Solve();
      //Verify solve (Pencil Marks as this shouldn't be solving the boards)
      //get pencil marks and check the values. 

      //group 1, top row should be 4, 5, 6
      var actualPencilMarksForGroupRow = result.GetGroups().First(x => x.Index == 0).GetRowCells(RowPosition.Top).GetPencilMarks().ToList();
      var expectedPencilMarks = new[] { 4, 5, 6 };
      Assert.That(actualPencilMarksForGroupRow, Is.EquivalentTo(expectedPencilMarks));
      //group 1, top row should be 7, 8 9
      actualPencilMarksForGroupRow = result.GetGroups().First(x => x.Index == 1).GetRowCells(RowPosition.Top).GetPencilMarks().ToList();
      expectedPencilMarks = new[] { 7, 8, 9 };
      Assert.That(actualPencilMarksForGroupRow, Is.EquivalentTo(expectedPencilMarks));

      //group 2, top row should be 7, 8, 9
      actualPencilMarksForGroupRow = result.GetGroups().First(x => x.Index == 1).GetRowCells(RowPosition.Top).GetPencilMarks().ToList();
      expectedPencilMarks = new [] { 7, 8, 9 };
      Assert.That(actualPencilMarksForGroupRow, Is.EquivalentTo(expectedPencilMarks));
      //group 2, bottom row should be 1, 2, 3
      actualPencilMarksForGroupRow = result.GetGroups().First(x => x.Index == 1).GetRowCells(RowPosition.Bottom).GetPencilMarks().ToList();
      expectedPencilMarks = new [] { 1, 2, 3 };
      Assert.That(actualPencilMarksForGroupRow, Is.EquivalentTo(expectedPencilMarks));

      //group 3, middle row should be 7, 8, 9
      actualPencilMarksForGroupRow = result.GetGroups().First(x => x.Index == 2).GetRowCells(RowPosition.Middle).GetPencilMarks().ToList();
      expectedPencilMarks = new[] { 7, 8, 9 };
      Assert.That(actualPencilMarksForGroupRow, Is.EquivalentTo(expectedPencilMarks));
      //group 3, bottom row should be 4, 5, 6
      actualPencilMarksForGroupRow = result.GetGroups().First(x => x.Index == 2).GetRowCells(RowPosition.Bottom).GetPencilMarks().ToList();
      expectedPencilMarks = new[] { 4, 5, 6 };
      Assert.That(actualPencilMarksForGroupRow, Is.EquivalentTo(expectedPencilMarks));
    }
  }
}
