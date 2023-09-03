using Microsoft.Extensions.Logging;
using Sudoku.GameBoard;

namespace Sudoku.ConsoleApp
{
  internal class Program
  {
#pragma warning disable CS8618
    internal static ILoggerFactory LoggerFactory;
#pragma warning restore CS8618

    static void Main(string[] args)
    {
      LoggerFactory = CreateLoggerFactory();
      var logger = LoggerFactory.CreateLogger<Program>();
      var boardAsString = Boards.EasyBoards.EasyBoard01;
      var gameBoard = GameBoardFactory.Create(boardAsString, logger);
      var engine = new Engine.Engine(gameBoard, LoggerFactory);
      var result = engine.Solve();
    }

    private static ILoggerFactory CreateLoggerFactory()
    {
      var loggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
      {
        builder.AddConsole()
          .SetMinimumLevel(LogLevel.Trace);
      });
      return loggerFactory;
    }
  }
}