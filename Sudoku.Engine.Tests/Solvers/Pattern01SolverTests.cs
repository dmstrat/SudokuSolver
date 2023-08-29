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

      var actualPencilMarksForGroupRow = result.GetGroups().First(x => x.Index == 0).GetRowCells(RowPosition.Bottom).GetPencilMarks();

      var expectedPencilMarks = new int[] { 1, 2, 3 };
      Assert.That(actualPencilMarksForGroupRow, Is.EqualTo(expectedPencilMarks));

      var actualResults = result.GetValuesAsString();
      //Assert.That(actualResults, Is.EqualTo(solvedGameOutput));
    }

  }


}
