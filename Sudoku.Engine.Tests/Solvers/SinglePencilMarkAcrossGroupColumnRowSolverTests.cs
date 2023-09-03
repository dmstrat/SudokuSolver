using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Sudoku.Engine.Solvers;
using Sudoku.Engine.Tests.Loggers;
using Sudoku.Engine.Tests.TestBoards;
using Sudoku.GameBoard;
using System.Diagnostics;

namespace Sudoku.Engine.Tests.Solvers
{
  internal class SinglePencilMarkAcrossGroupColumnRowSolverTests
  {
    private ConsoleTraceListener _Listener;
    private readonly ILoggerFactory _LoggerFactory;
    private ILogger _Logger;

    public SinglePencilMarkAcrossGroupColumnRowSolverTests()
    {
      _LoggerFactory = new NullLoggerFactory();
    }

    [SetUp]
    public void Setup()
    {
      _Logger = _LoggerFactory.CreateLogger<SinglePencilMarkAcrossGroupColumnRowSolverTests>();
      _Listener = new ConsoleTraceListener();
      Trace.Listeners.Add(_Listener);
    }

    [TearDown]
    public void Teardown()
    {
      Trace.Listeners.Remove(_Listener);
    }

    [TestCase(GameBoard01.MissingOneNumberPerRowAndColumn_Input, GameBoard01.Solved_Output)]
    [TestCase(GameBoardMedium01.Game_Input, GameBoardMedium01.Game_Output)]
    public void GivenBoard01SolveResultsCorrectUsingSoloValueInGroupColumnRowSolver(string gameBoardInput, string solvedGameOutput)
    {
      _Logger.LogBoardValues(gameBoardInput);
      //Build Game Board
      //Instance Engine 
      var gameBoard = GameBoardFactory.Create(gameBoardInput);
      var engine = new Engine(gameBoard, _LoggerFactory);
      var solvers = new List<ISolver> { new SinglePencilMarkAcrossGroupColumnRowSolver() };
      engine.RegisterSolvers(solvers);
      //Solve 
      var result = engine.Solve();
      //Verify solve 
      var actualResults = result.GetValuesAsString();
      Assert.That(actualResults, Is.EqualTo(solvedGameOutput));
    }
  }

}
