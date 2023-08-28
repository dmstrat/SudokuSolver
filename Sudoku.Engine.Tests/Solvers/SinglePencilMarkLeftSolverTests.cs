using System.Diagnostics;
using Sudoku.Engine.Solvers;
using Sudoku.Engine.Tests.TestBoards;
using Sudoku.GameBoard;

namespace Sudoku.Engine.Tests.Solvers
{
  internal class SinglePencilMarkLeftSolverTests
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
    public void GivenBoard01SolveResultsCorrectUsingSoloValueInGroupColumnRowSolver(string gameBoardInput, string solvedGameOutput)
    {
      //Build Game Board
      //Instance Engine 
      var gameBoard = GameBoardFactory.Create(gameBoardInput);
      var engine = new Engine(gameBoard);
      var solvers = new List<ISolver> { new SinglePencilMarkLeftSolver() };
      engine.RegisterSolvers(solvers);
      //Solve 
      var result = engine.Solve();
      //Verify solve 
      var actualResults = result.GetValuesAsString();
      Assert.That(actualResults, Is.EqualTo(solvedGameOutput));
    }
  }

}
