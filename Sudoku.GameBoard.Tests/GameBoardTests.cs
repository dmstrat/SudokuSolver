namespace Sudoku.GameBoard.Tests
{
  public class GameBoardTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GameBoardCtor()
    {
      var board = new GameBoard();
      Assert.NotNull(board);
    }
  }
}