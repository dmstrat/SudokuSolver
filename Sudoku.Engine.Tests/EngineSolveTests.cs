using Sudoku.Engine.Tests.TestBoards;
using Sudoku.GameBoard;

namespace Sudoku.Engine.Tests
{
  internal class EngineSolveTests
  {
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void GivenBoard01SolveResultsCorrect()
    {
      //build gameboard
      //instance engine 
      var gameBoard = GameBoardFactory.Create(GameBoard01.MissingOneNumberPerRowAndColumn_Input);
      var engine = new Engine(gameBoard);
      //call solve 
      var result = engine.Solve();
      //verify solve 
      var actualResults = result.GetValuesAsString();
      Assert.That(actualResults, Is.EqualTo(GameBoard01.MissingOneNumberPerRowAndColumn_Output));
    }
  }
}
