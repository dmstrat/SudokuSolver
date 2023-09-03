using Microsoft.Extensions.Logging;

namespace Sudoku.Engine.Loggers
{
  internal static partial class Logger
  {
    [LoggerMessage(
      EventId = 1,
      Message = "Board Changed/{boardAsString}/",
      Level = LogLevel.Trace)]
    internal static partial void LogBoardValues(
      this ILogger logger,
      string boardAsString);

    [LoggerMessage(
      EventId = 2,
      Message = "{step,4:D3} / {message} /",
      Level = LogLevel.Information)]
    internal static partial void LogStep(
      this ILogger logger,
      int step,
      string message);
  }
}
