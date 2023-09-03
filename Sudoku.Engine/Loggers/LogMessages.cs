using Microsoft.Extensions.Logging;

namespace Sudoku.Engine.Loggers
{
  internal static partial class LogMessages
  {
    [LoggerMessage(
      EventId = 1,
      Message = "Board Changed/{boardAsString}/",
      Level = LogLevel.Trace)]
    internal static partial void LogBoardValues(
      this ILogger logger,
      string boardAsString);
  }
}
