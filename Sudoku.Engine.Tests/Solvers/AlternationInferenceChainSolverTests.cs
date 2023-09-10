using Microsoft.Extensions.Logging;
using Sudoku.Engine.Solvers;
using Sudoku.Engine.Tests.Loggers;
using Sudoku.Engine.Tests.TestBoards;
using Sudoku.GameBoard;
using System.Diagnostics;
using Sudoku.GameBoard.Helpers;

namespace Sudoku.Engine.Tests.Solvers
{
  internal class AlternationInferenceChainSolverTests
  {
    private ConsoleTraceListener _Listener;
    private readonly ILoggerFactory _LoggerFactory;
    private ILogger _Logger;

    public AlternationInferenceChainSolverTests()
    {
      _LoggerFactory = new LoggerFactory();
    }

    [SetUp]
    public void Setup()
    {
      _Logger = _LoggerFactory.CreateLogger<AlternationInferenceChainSolverTests>();
      _Listener = new ConsoleTraceListener();
      Trace.Listeners.Add(_Listener);
    }

    [TearDown]
    public void Teardown()
    {
      Trace.Listeners.Remove(_Listener);
    }

    [TestCase(AicGameBoard01.Board_Input_Json, AicGameBoard01.Solved_Output_Json)]
    public void GivenBoard01SolveResultsCorrectUsingSoloPencilMarkInACell(string gameBoardInputAsJson, string solvedGameOutputAsJson)
    {
      _Logger.LogBoardValues(gameBoardInputAsJson);
      //Build Game Board
      //Instance Engine 
      var gameBoard = GameBoardSerializer.FromJson(gameBoardInputAsJson);
      //var gameBoard = GameBoardFactory.Create(gameBoardInput, _Logger);
      var engine = new Engine(gameBoard, _LoggerFactory);
      var solvers = new List<ISolver> { new AicSolver() };
      engine.RegisterSolvers(solvers);
      //Solve 
      var actualResult = engine.Solve();
      //Verify solve 
      var actualResultAsJson = GameBoardSerializer.ToJson(actualResult);
      var actualResultAsZeroString = actualResult.BuildZeroBasedString();
      var expectedGameBoard = GameBoardSerializer.FromJson(solvedGameOutputAsJson);
      Assert.That(actualResult, Is.EqualTo(expectedGameBoard));
    }
  }
}
