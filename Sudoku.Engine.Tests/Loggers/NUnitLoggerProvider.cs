using Microsoft.Extensions.Logging;


namespace Sudoku.Engine.Tests.Loggers
{
  public class NUnitLoggerProvider : ILoggerProvider
  {
    private readonly LogLevel _minLevel;
    private readonly DateTimeOffset? _logStart;

    public NUnitLoggerProvider()
        : this(LogLevel.Trace)
    {
    }

    public NUnitLoggerProvider(LogLevel minLevel)
        : this(minLevel, null)
    {
    }

    public NUnitLoggerProvider(LogLevel minLevel, DateTimeOffset? logStart)
    {
      _minLevel = minLevel;
      _logStart = logStart;
    }

    public ILogger CreateLogger(string categoryName)
    {
      return new NUnitLogger(categoryName, _minLevel, _logStart);
    }

    public void Dispose()
    {
    }
  }
}
