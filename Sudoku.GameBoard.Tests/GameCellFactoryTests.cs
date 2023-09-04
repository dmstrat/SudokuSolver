using Microsoft.Extensions.Logging;
using Sudoku.Engine.Tests.Loggers;

namespace Sudoku.GameBoard.Tests
{
  public class GameCellFactoryTests
  {
    private readonly ILogger _Logger;

    public GameCellFactoryTests()
    {
      var loggerFactory = LoggerFactory.Create(config =>
      {
        config.AddProvider(new NUnitLoggerProvider())
          .SetMinimumLevel(LogLevel.Trace);
      });
      _Logger = loggerFactory.CreateLogger<GameBoardTests>();
    }

    //Row Index 0
    [TestCase(null, false, 0, 0, 0, 0)]
    [TestCase(null, false, 1, 0, 0, 1)]
    [TestCase(null, false, 2, 0, 0, 2)]
    [TestCase(null, false, 3, 1, 0, 3)]
    [TestCase(null, false, 4, 1, 0, 4)]
    [TestCase(null, false, 5, 1, 0, 5)]
    [TestCase(null, false, 6, 2, 0, 6)]
    [TestCase(null, false, 7, 2, 0, 7)]
    [TestCase(null, false, 8, 2, 0, 8)]
    //Row Index 1
    [TestCase(null, false, 9, 0, 1, 0)]
    [TestCase(null, false, 10, 0, 1, 1)]
    [TestCase(null, false, 11, 0, 1, 2)]
    [TestCase(null, false, 12, 1, 1, 3)]
    [TestCase(null, false, 13, 1, 1, 4)]
    [TestCase(null, false, 14, 1, 1, 5)]
    [TestCase(null, false, 15, 2, 1, 6)]
    [TestCase(null, false, 16, 2, 1, 7)]
    [TestCase(null, false, 17, 2, 1, 8)]
    //Row Index 2
    [TestCase(null, false, 18, 0, 2, 0)]
    [TestCase(null, false, 19, 0, 2, 1)]
    [TestCase(null, false, 20, 0, 2, 2)]
    [TestCase(null, false, 21, 1, 2, 3)]
    [TestCase(null, false, 22, 1, 2, 4)]
    [TestCase(null, false, 23, 1, 2, 5)]
    [TestCase(null, false, 24, 2, 2, 6)]
    [TestCase(null, false, 25, 2, 2, 7)]
    [TestCase(null, false, 26, 2, 2, 8)]
    //Row Index 3
    [TestCase(null, false, 27, 3, 3, 0)]
    [TestCase(null, false, 28, 3, 3, 1)]
    [TestCase(null, false, 29, 3, 3, 2)]
    [TestCase(null, false, 30, 4, 3, 3)]
    [TestCase(null, false, 31, 4, 3, 4)]
    [TestCase(null, false, 32, 4, 3, 5)]
    [TestCase(null, false, 33, 5, 3, 6)]
    [TestCase(null, false, 34, 5, 3, 7)]
    [TestCase(null, false, 35, 5, 3, 8)]
    //Row Index 4
    [TestCase(null, false, 36, 3, 4, 0)]
    [TestCase(null, false, 37, 3, 4, 1)]
    [TestCase(null, false, 38, 3, 4, 2)]
    [TestCase(null, false, 39, 4, 4, 3)]
    [TestCase(null, false, 40, 4, 4, 4)]
    [TestCase(null, false, 41, 4, 4, 5)]
    [TestCase(null, false, 42, 5, 4, 6)]
    [TestCase(null, false, 43, 5, 4, 7)]
    [TestCase(null, false, 44, 5, 4, 8)]
    //Row Index 5
    [TestCase(null, false, 45, 3, 5, 0)]
    [TestCase(null, false, 46, 3, 5, 1)]
    [TestCase(null, false, 47, 3, 5, 2)]
    [TestCase(null, false, 48, 4, 5, 3)]
    [TestCase(null, false, 49, 4, 5, 4)]
    [TestCase(null, false, 50, 4, 5, 5)]
    [TestCase(null, false, 51, 5, 5, 6)]
    [TestCase(null, false, 52, 5, 5, 7)]
    [TestCase(null, false, 53, 5, 5, 8)]
    //Row Index 6
    [TestCase(null, false, 54, 6, 6, 0)]
    [TestCase(null, false, 55, 6, 6, 1)]
    [TestCase(null, false, 56, 6, 6, 2)]
    [TestCase(null, false, 57, 7, 6, 3)]
    [TestCase(null, false, 58, 7, 6, 4)]
    [TestCase(null, false, 59, 7, 6, 5)]
    [TestCase(null, false, 60, 8, 6, 6)]
    [TestCase(null, false, 61, 8, 6, 7)]
    [TestCase(null, false, 62, 8, 6, 8)]
    //Row Index 7
    [TestCase(null, false, 63, 6, 7, 0)]
    [TestCase(null, false, 64, 6, 7, 1)]
    [TestCase(null, false, 65, 6, 7, 2)]
    [TestCase(null, false, 66, 7, 7, 3)]
    [TestCase(null, false, 67, 7, 7, 4)]
    [TestCase(null, false, 68, 7, 7, 5)]
    [TestCase(null, false, 69, 8, 7, 6)]
    [TestCase(null, false, 70, 8, 7, 7)]
    [TestCase(null, false, 71, 8, 7, 8)]
    //Row Index 8
    [TestCase(null, false, 72, 6, 8, 0)]
    [TestCase(null, false, 73, 6, 8, 1)]
    [TestCase(null, false, 74, 6, 8, 2)]
    [TestCase(null, false, 75, 7, 8, 3)]
    [TestCase(null, false, 76, 7, 8, 4)]
    [TestCase(null, false, 77, 7, 8, 5)]
    [TestCase(null, false, 78, 8, 8, 6)]
    [TestCase(null, false, 79, 8, 8, 7)]
    [TestCase(null, false, 80, 8, 8, 8)]
    public void CellGetGroupColumnRowMethodsReturnCorrectValues(int? ctorValue, bool isPuzzleValue, int cellIndex,
      int expectedGroupIndex, int expectedRowIndex, int expectedColumnIndex)
    {
      var gameCell = GameCellFactory.Create(ctorValue, isPuzzleValue, cellIndex, _Logger);

      var actualGroupIndex = gameCell.GroupIndex;
      var actualRowIndex = gameCell.RowIndex;
      var actualColumnIndex = gameCell.ColumnIndex;

      Assert.Multiple(() =>
      {
        Assert.That(actualGroupIndex, Is.EqualTo(expectedGroupIndex),$"Cell Index:{cellIndex}:Expected Group Index:{expectedGroupIndex}:BUT got:{actualGroupIndex}:");
        Assert.That(actualRowIndex, Is.EqualTo(expectedRowIndex), $"Cell Index:{cellIndex}:Expected Group Index:{expectedRowIndex}:BUT got:{actualRowIndex}:");
        Assert.That(actualColumnIndex, Is.EqualTo(expectedColumnIndex), $"Cell Index:{cellIndex}:Expected Group Index:{expectedColumnIndex}:BUT got:{actualRowIndex}:");
      });
    }
  }
}
