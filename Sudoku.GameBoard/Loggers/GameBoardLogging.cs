using Microsoft.Extensions.Logging;

namespace Sudoku.GameBoard.Loggers
{
  internal static partial class GameBoardLogging
  {
    [LoggerMessage(
      EventId = 3,
      Message = "{action} / {message} /",
      Level = LogLevel.Debug)]
    internal static partial void LogAction(
      this ILogger logger,
      string action,
      string message);
  }
}
