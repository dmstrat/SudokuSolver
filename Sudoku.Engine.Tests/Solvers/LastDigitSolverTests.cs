using Microsoft.Extensions.Logging;
using Sudoku.Engine.Solvers;
using Sudoku.Engine.Tests.Loggers;
using Sudoku.Engine.Tests.TestBoards;
using Sudoku.GameBoard;
using System.Diagnostics;

namespace Sudoku.Engine.Tests.Solvers
{
  internal class LastDigitSolverTests
  {
    private ConsoleTraceListener _Listener;
    private readonly ILoggerFactory _LoggerFactory;
    private ILogger _Logger;

    public LastDigitSolverTests()
    {
      _LoggerFactory = new LoggerFactory();
    }

    [SetUp]
    public void Setup()
    {
      _Logger = _LoggerFactory.CreateLogger<SinglePencilMarkLeftSolverTests>();
      _Listener = new ConsoleTraceListener();
      Trace.Listeners.Add(_Listener);
    }

    [TearDown]
    public void Teardown()
    {
      Trace.Listeners.Remove(_Listener);
    }

    [TestCase(GameBoard01.MissingOneNumberPerRowAndColumn_Input, GameBoard01.Solved_Output)]
    [TestCase(GameBoardMedium01.Game_Input_Phase_2, GameBoardMedium01.Game_Output)]
    public void GivenBoard01SolveResultsCorrectUsingSoloPencilMarkInACell(string gameBoardInput, string solvedGameOutput)
    {
      _Logger.LogBoardValues(gameBoardInput);
      //Build Game Board
      //Instance Engine 
      var gameBoard = GameBoardFactory.Create(gameBoardInput, _Logger);
      var engine = new Engine(gameBoard, _LoggerFactory);
      var solvers = new List<ISolver> { new LastDigitSolver() };
      engine.RegisterSolvers(solvers);
      //Solve 
      var result = engine.Solve();
      //Verify solve 
      var actualResults = result.GetValuesAsString();
      Assert.That(actualResults, Is.EqualTo(solvedGameOutput));
    }
  }
}
