using Microsoft.Extensions.Logging;
using Sudoku.GameBoard;

namespace Sudoku.ConsoleApp
{
  internal class Program
  {
    internal static ILoggerFactory _LoggerFactory;

    static void Main(string[] args)
    {
      _LoggerFactory = CreateLoggerFactory();
      var boardAsString = Boards.EasyBoards.EasyBoard01;
      var gameBoard = GameBoardFactory.Create(boardAsString);
      var engine = new Engine.Engine(gameBoard, _LoggerFactory);
      var result = engine.Solve();
    }

    static ILoggerFactory CreateLoggerFactory()
    {
      var loggerFactory = LoggerFactory.Create(builder =>
      {
        builder.AddConsole()
          .SetMinimumLevel(LogLevel.Trace);
      });
      return loggerFactory;
    }
  }
}