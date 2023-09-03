using Microsoft.Extensions.Logging;
using Sudoku.Engine.Tests.Loggers;
using Sudoku.GameBoard.Exceptions;
using Sudoku.GameBoard.Tests.Asserts;
using Sudoku.GameBoard.Tests.GameBoards;

namespace Sudoku.GameBoard.Tests
{
  public class GameBoardTests
  {
    public const int NumberOfGameCellsInGameBoard = 81;
    private readonly ILogger _Logger;

    public GameBoardTests()
    {
      var loggerFactory = LoggerFactory.Create(config =>
      {
        config.AddProvider(new NUnitLoggerProvider())
          .SetMinimumLevel(LogLevel.Trace);
      });
      _Logger = loggerFactory.CreateLogger<GameBoardTests>();
    }

    [Test]
    public void BoardFactoryTest()
    {
      var newBoard = GameBoardFactory.Create(GameBoardInputs.GameBoard01AllCellsFilled, _Logger);
      Assert.That(newBoard, Is.Not.Null);
    }

    [Test]
    public void UsingFactoryGameBoardHasCorrectNumberOfGameCellsForSudoku()
    {
      var newBoard= GameBoardFactory.Create(GameBoardInputs.GameBoard01AllCellsFilled, _Logger);
      Assert.That(newBoard, Is.Not.Null);
      var actualString = newBoard.ToString();
      Assert.Multiple(() =>
      {
        Assert.That(actualString, Is.Not.Null);
        Assert.That(newBoard.Cells, Has.Count.EqualTo(NumberOfGameCellsInGameBoard),
          "Incorrect number of GameCells were created for new GameBoard.");
      });
      var valuesAsString = newBoard.GetValuesAsString();
      Assert.That(valuesAsString, Is.EqualTo(GameBoardInputs.GameBoard01AllCellsFilled), "GameBoard failed to build string correctly");
    }

    [Test]
    public void UsingFactoryWithZerosGivesGameBoardEmptyOrNullValuesForThoseCells()
    {
      var newBoard = GameBoardFactory.Create(GameBoardInputs.GameBoard02SomeEmptyCellsByZeros, _Logger);
      Assert.That(newBoard, Is.Not.Null);
      var actualString = newBoard.ToString();
      Assert.Multiple(() =>
      {
        Assert.That(actualString, Is.Not.Null);
        Assert.That(newBoard.Cells, Has.Count.EqualTo(NumberOfGameCellsInGameBoard), "Incorrect number of GameCells were created for new GameBoard with empty cells.");
      });
      var valuesAsString = newBoard.GetValuesAsString();
      Assert.That(valuesAsString, Is.EqualTo(GameBoardInputs.GameBoard02SomeEmptyCellsBySpaces), "GameBoard failed to build string correctly");
    }

    [Test]
    public void UsingFactoryWithSpacesZerosGivesGameBoardEmptyOrNullValuesForThoseCells()
    {
      var newBoard = GameBoardFactory.Create(GameBoardInputs.GameBoard02SomeEmptyCellsBySpaces, _Logger);
      Assert.That(newBoard, Is.Not.Null);
      var actualString = newBoard.ToString();
      Assert.Multiple(() =>
      {
        Assert.That(actualString, Is.Not.Null);
        Assert.That(newBoard.Cells, Has.Count.EqualTo(NumberOfGameCellsInGameBoard), "Incorrect number of GameCells were created for new GameBoard with empty cells.");
      });
      var valuesAsString = newBoard.GetValuesAsString();
      Assert.That(valuesAsString, Is.EqualTo(GameBoardInputs.GameBoard02SomeEmptyCellsBySpaces), "GameBoard failed to build string correctly");
    }

    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 1, GameBoardOutputs.GameBoard01Group01)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 2, GameBoardOutputs.GameBoard01Group02)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 3, GameBoardOutputs.GameBoard01Group03)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 4, GameBoardOutputs.GameBoard01Group04)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 5, GameBoardOutputs.GameBoard01Group05)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 6, GameBoardOutputs.GameBoard01Group06)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 7, GameBoardOutputs.GameBoard01Group07)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 8, GameBoardOutputs.GameBoard01Group08)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 9, GameBoardOutputs.GameBoard01Group09)]

    public void GetGroupByNumberReturnsCorrectValues(string gameBoardAsString, int groupNumber, string groupValuesAsString)
    {
      var gameBoard = GameBoardFactory.Create(gameBoardAsString, _Logger);
      var gameBoardGroup = GameBoardGroupFactory.Create(gameBoard, groupNumber);
      var groupString = gameBoardGroup.GetValuesAsString();
      Assert.That(groupString, Is.EqualTo(groupValuesAsString));
    }

    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 1, GameBoardOutputs.GameBoard01Row01)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 2, GameBoardOutputs.GameBoard01Row02)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 3, GameBoardOutputs.GameBoard01Row03)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 4, GameBoardOutputs.GameBoard01Row04)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 5, GameBoardOutputs.GameBoard01Row05)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 6, GameBoardOutputs.GameBoard01Row06)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 7, GameBoardOutputs.GameBoard01Row07)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 8, GameBoardOutputs.GameBoard01Row08)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 9, GameBoardOutputs.GameBoard01Row09)]

    public void GetRowByNumberReturnsCorrectValues(string gameBoardAsString, int rowNumber, string expectedRowValuesAsString)
    {
      var gameBoard = GameBoardFactory.Create(gameBoardAsString, _Logger);
      var gameBoardRow = GameBoardRowFactory.Create(gameBoard, rowNumber);
      var rowString = gameBoardRow.GetAsString();
      Assert.That(rowString, Is.EqualTo(expectedRowValuesAsString));
    }

    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 1, GameBoardOutputs.GameBoard01Column01)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 2, GameBoardOutputs.GameBoard01Column02)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 3, GameBoardOutputs.GameBoard01Column03)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 4, GameBoardOutputs.GameBoard01Column04)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 5, GameBoardOutputs.GameBoard01Column05)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 6, GameBoardOutputs.GameBoard01Column06)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 7, GameBoardOutputs.GameBoard01Column07)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 8, GameBoardOutputs.GameBoard01Column08)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 9, GameBoardOutputs.GameBoard01Column09)]

    public void GetColumnByNumberReturnsCorrectValues(string gameBoardAsString, int columnNumber, string expectedColumnValuesAsString)
    {
      var gameBoard = GameBoardFactory.Create(gameBoardAsString, _Logger);
      var gameBoardColumn = GameBoardColumnFactory.Create(gameBoard, columnNumber);
      var columnString = gameBoardColumn.GetAsString();
      Assert.That(columnString, Is.EqualTo(expectedColumnValuesAsString));
    }

    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 0, GameBoardOutputs.GameBoard01Group01)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 1, GameBoardOutputs.GameBoard01Group02)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 2, GameBoardOutputs.GameBoard01Group03)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 3, GameBoardOutputs.GameBoard01Group04)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 4, GameBoardOutputs.GameBoard01Group05)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 5, GameBoardOutputs.GameBoard01Group06)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 6, GameBoardOutputs.GameBoard01Group07)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 7, GameBoardOutputs.GameBoard01Group08)]
    [TestCase(GameBoardInputs.GameBoard01AllCellsFilled, 8, GameBoardOutputs.GameBoard01Group09)]

    public void ValidateBoardGroups(string gameBoardAsString, int groupNumber, string groupValuesAsString)
    {
      var gameBoard = GameBoardFactory.Create(gameBoardAsString, _Logger);

      var actualGroup = gameBoard.GetGroupById(groupNumber);
      GameBoardGroupAsserts.AssertGameBoardGroup(groupValuesAsString, actualGroup);
    }

    [TestCase(GameBoardInputs.GameBoard02InvalidColumn)]
    [TestCase(GameBoardInputs.GameBoard02InvalidRow)]
    [TestCase(GameBoardInputs.GameBoard02InvalidGroup)]
    public void InvalidBoardsThrowInvalidValuesException(string gameBoardAsString)
    {
      Assert.Throws<GameInvalidValuesInBoard>(() => GameBoardFactory.Create(gameBoardAsString, _Logger));
    }
  }
}