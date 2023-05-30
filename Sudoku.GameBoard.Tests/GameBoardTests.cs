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
    public void GameBoardFactoryTest()
    {
      var newBoard = GameBoardFactory.Create(GameBoardInputs.GameBoardAllCellsFilled);
      Assert.NotNull(newBoard);
    }

    [Test]
    public void UsingFactoryGameBoardHasCorrectNumberOfGameCellsForSudoku()
    {
      var newBoard= GameBoardFactory.Create(GameBoardInputs.GameBoardAllCellsFilled);
      Assert.NotNull(newBoard);
      var actualString = newBoard.ToString();
      Assert.NotNull(actualString);
      Assert.AreEqual(NumberOfGameCellsInGameBoard, newBoard.GameCells.Count(), "Incorrect number of GameCells were created for new GameBoard.");
      var valuesAsString = newBoard.GetValuesAsString();
      Assert.AreEqual(GameBoardInputs.GameBoardAllCellsFilled, valuesAsString, "GameBoard failed to build string correctly");
    }

    [Test]
    public void UsingFactoryWithZerosGivesGameBoardEmptyOrNullValuesForThoseCells()
    {
      var newBoard = GameBoardFactory.Create(GameBoardInputs.GameBoardSomeEmptyCellsByZeros);
      Assert.NotNull(newBoard);
      var actualString = newBoard.ToString();
      Assert.NotNull(actualString);
      Assert.AreEqual(NumberOfGameCellsInGameBoard, newBoard.GameCells.Count(), "Incorrect number of GameCells were created for new GameBoard with empty cells.");
      var valuesAsString = newBoard.GetValuesAsString();
      Assert.AreEqual(GameBoardInputs.GameBoardSomeEmptyCellsBySpaces, valuesAsString, "GameBoard failed to build string correctly");
    }

    [Test]
    public void UsingFactoryWithSpacesZerosGivesGameBoardEmptyOrNullValuesForThoseCells()
    {
      var newBoard = GameBoardFactory.Create(GameBoardInputs.GameBoardSomeEmptyCellsBySpaces);
      Assert.NotNull(newBoard);
      var actualString = newBoard.ToString();
      Assert.NotNull(actualString);
      Assert.AreEqual(NumberOfGameCellsInGameBoard, newBoard.GameCells.Count(), "Incorrect number of GameCells were created for new GameBoard with empty cells.");
      var valuesAsString = newBoard.GetValuesAsString();
      Assert.AreEqual(GameBoardInputs.GameBoardSomeEmptyCellsBySpaces, valuesAsString, "GameBoard failed to build string correctly");
    }

  }
}