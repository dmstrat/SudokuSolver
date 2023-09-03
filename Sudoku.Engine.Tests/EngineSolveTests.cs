using Sudoku.Engine.Tests.TestBoards;
using Sudoku.GameBoard;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Sudoku.Engine.Tests.Loggers;

namespace Sudoku.Engine.Tests
{
  internal class EngineSolverTests
  {
    private ConsoleTraceListener _Listener;
    private readonly ILoggerFactory _LoggerFactory;
    private ILogger _Logger;

    public EngineSolverTests()
    {
      _Listener = new ConsoleTraceListener();
      _LoggerFactory = LoggerFactory.Create(config =>
      {
        config.AddProvider(new NUnitLoggerProvider())
          .SetMinimumLevel(LogLevel.Trace);
      });
      _Logger = _LoggerFactory.CreateLogger<EngineSolverTests>();
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

    [TestCase(GameBoard01.MissingOneNumberPerRowAndColumn_Input, GameBoard01.Solved_Output)]
    [TestCase(GameBoardMedium01.Game_Input, GameBoardMedium01.Game_Output)]
    [TestCase(GameBoardMedium01.Game_Input_Phase_2, GameBoardMedium01.Game_Output)]
    [TestCase(GameBoardMedium02.Game_Input, GameBoardMedium02.Game_Output)]
    [TestCase(GameBoardModerate01.Game_Input, GameBoardModerate01.Game_Output)]
    [TestCase(GameBoardHard01.Game_Input, GameBoardHard01.Game_Output)]
    
    public void GivenBoardSolvesToExpectation(string gameBoardInput, string solvedGameOutput)
    {
      _Logger.LogBoardValues(gameBoardInput);
      //Build Game Board
      //Instance Engine 
      var gameBoard = GameBoardFactory.Create(gameBoardInput);
      var engine = new Engine(gameBoard, _LoggerFactory);
      //Solve 
      var result = engine.Solve();
      //Verify solve 
      var actualResults = result.GetValuesAsString();
      Assert.That(actualResults, Is.EqualTo(solvedGameOutput));
    }
  }
}
