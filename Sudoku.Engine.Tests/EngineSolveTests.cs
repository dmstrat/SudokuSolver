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

    [TestCase(GameBoard01.MissingOneNumberPerRowAndColumn_Input, GameBoard01.Solved_Output)]
    [TestCase(GameBoardMedium01.Game_Input, GameBoardMedium01.Game_Output)]
    [TestCase(GameBoardMedium02.Game_Input, GameBoardMedium02.Game_Output)]
    public void GivenBoard01SolveResultsCorrect(string gameBoardInput, string solvedGameOutput)
    {
      //Build Game Board
      //Instance Engine 
      var gameBoard = GameBoardFactory.Create(gameBoardInput);
      var engine = new Engine(gameBoard);
      //Solve 
      var result = engine.Solve();
      //Verify solve 
      var actualResults = result.GetValuesAsString();
      Assert.That(actualResults, Is.EqualTo(solvedGameOutput));
    }
  }
}
