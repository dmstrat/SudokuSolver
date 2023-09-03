using Microsoft.Extensions.Logging;

namespace Sudoku.Engine.Tests.Loggers
{
  internal static partial class TestLogging
  {
    [LoggerMessage(
      EventId = 1,
      Message = "Board Changed/{boardAsString}/",
      Level = LogLevel.Debug)]
    internal static partial void LogBoardValues(
      this ILogger logger,
      string boardAsString);
  }
}
