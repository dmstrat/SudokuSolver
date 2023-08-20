namespace Sudoku.GameBoard.Tests.Asserts
{
  internal static class GameBoardGroupAsserts
  {
    public static void AssertGameBoardGroup(string expectedGroupAsString, GameBoardGroup actualGroup)
    {
      var actualGroupAsString = actualGroup.GetValuesAsString();
      Assert.That(actualGroupAsString, Is.EqualTo(expectedGroupAsString));
    }
  }
}
