using Sudoku.GameBoard.Exceptions;
using Sudoku.GameBoard.Tests.Asserts;
using Sudoku.GameBoard.Tests.GameBoards;

namespace Sudoku.GameBoard.Tests
{
  public class GameBoardTests
  {
    public const int NumberOfGameCellsInGameBoard = 81;

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BoardFactoryTest()
    {
      var newBoard = GameBoardFactory.Create(GameBoardInputs.GameBoard01AllCellsFilled);
      Assert.NotNull(newBoard);
    }

    [Test]
    public void UsingFactoryGameBoardHasCorrectNumberOfGameCellsForSudoku()
    {
      var newBoard= GameBoardFactory.Create(GameBoardInputs.GameBoard01AllCellsFilled);
      Assert.NotNull(newBoard);
      var actualString = newBoard.ToString();
      Assert.NotNull(actualString);
      Assert.AreEqual(NumberOfGameCellsInGameBoard, newBoard.Cells.Count(), "Incorrect number of GameCells were created for new GameBoard.");
      var valuesAsString = newBoard.GetValuesAsString();
      Assert.AreEqual(GameBoardInputs.GameBoard01AllCellsFilled, valuesAsString, "GameBoard failed to build string correctly");
    }

    [Test]
    public void UsingFactoryWithZerosGivesGameBoardEmptyOrNullValuesForThoseCells()
    {
      var newBoard = GameBoardFactory.Create(GameBoardInputs.GameBoard02SomeEmptyCellsByZeros);
      Assert.NotNull(newBoard);
      var actualString = newBoard.ToString();
      Assert.NotNull(actualString);
      Assert.AreEqual(NumberOfGameCellsInGameBoard, newBoard.Cells.Count(), "Incorrect number of GameCells were created for new GameBoard with empty cells.");
      var valuesAsString = newBoard.GetValuesAsString();
      Assert.AreEqual(GameBoardInputs.GameBoard02SomeEmptyCellsBySpaces, valuesAsString, "GameBoard failed to build string correctly");
    }

    [Test]
    public void UsingFactoryWithSpacesZerosGivesGameBoardEmptyOrNullValuesForThoseCells()
    {
      var newBoard = GameBoardFactory.Create(GameBoardInputs.GameBoard02SomeEmptyCellsBySpaces);
      Assert.NotNull(newBoard);
      var actualString = newBoard.ToString();
      Assert.NotNull(actualString);
      Assert.AreEqual(NumberOfGameCellsInGameBoard, newBoard.Cells.Count(), "Incorrect number of GameCells were created for new GameBoard with empty cells.");
      var valuesAsString = newBoard.GetValuesAsString();
      Assert.AreEqual(GameBoardInputs.GameBoard02SomeEmptyCellsBySpaces, valuesAsString, "GameBoard failed to build string correctly");
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
      var gameBoard = GameBoardFactory.Create(gameBoardAsString);
      var gameBoardGroup = GameBoardGroupFactory.Create(gameBoard, groupNumber);
      var groupString = gameBoardGroup.GetValuesAsString();
      Assert.AreEqual(groupValuesAsString, groupString);
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
      var gameBoard = GameBoardFactory.Create(gameBoardAsString);
      var gameBoardRow = GameBoardRowFactory.Create(gameBoard, rowNumber);
      var rowString = gameBoardRow.GetAsString();
      Assert.AreEqual(expectedRowValuesAsString, rowString);
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
      var gameBoard = GameBoardFactory.Create(gameBoardAsString);
      var gameBoardColumn = GameBoardColumnFactory.Create(gameBoard, columnNumber);
      var columnString = gameBoardColumn.GetAsString();
      Assert.AreEqual(expectedColumnValuesAsString, columnString);
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

    public void ValidateBoardGroups(string gameBoardAsString, int groupNumber, string groupValuesAsString)
    {
      var gameBoard = GameBoardFactory.Create(gameBoardAsString);

      var actualGroup = gameBoard.GetGroupById(groupNumber);
      GameBoardGroupAsserts.AssertGameBoardGroup(groupValuesAsString, actualGroup);
    }

    [TestCase(GameBoardInputs.GameBoard02InvalidColumn)]
    [TestCase(GameBoardInputs.GameBoard02InvalidRow)]
    [TestCase(GameBoardInputs.GameBoard02InvalidGroup)]
    public void InvalidBoardsThrowInvalidValuesException(string gameBoardAsString)
    {
      Assert.Throws<GameInvalidValuesInBoard>(() => GameBoardFactory.Create(gameBoardAsString));
    }
  }
}