using Microsoft.Extensions.Logging;
using Sudoku.Engine.Tests.Loggers;
using Sudoku.GameBoard.Helpers;
using Sudoku.GameBoard.Tests.GameBoards;

namespace Sudoku.GameBoard.Tests
{
  internal class GameBoardSerializerTests
  {
    private readonly ILogger _Logger;

    public GameBoardSerializerTests()
    {
      var loggerFactory = LoggerFactory.Create(config =>
      {
        config.AddProvider(new NUnitLoggerProvider())
          .SetMinimumLevel(LogLevel.Trace);
      });
      _Logger = loggerFactory.CreateLogger<GameBoardSerializerTests>();
    }

    [TestCase(GameBoardAsJson.Board01_Input_As_Json, GameBoardAsJson.Board01_Output_As_Json)]
    public void BoardSerializerTest(string inputJson, string compareJson)
    {
      var gameBoard = GameBoardSerializer.FromJson(inputJson);
      var outputGameBoard = GameBoardSerializer.ToJson(gameBoard);
      Assert.That(outputGameBoard, Is.EqualTo(compareJson), "GameBoards as Json strings DO NOT MATCH!!");
    }

  }
}
