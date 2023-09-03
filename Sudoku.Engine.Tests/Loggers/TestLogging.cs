﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
