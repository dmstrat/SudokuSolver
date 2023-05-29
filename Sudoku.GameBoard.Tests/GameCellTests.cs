namespace Sudoku.GameBoard.Tests
{
  public class GameCellTests
  {
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Cycle through changing the valid initial value to ANY VALID VALUE including null/empty
    /// Ensure InvalidOperationException is thrown when initial value is a puzzle piece
    /// NULL Initial value TEST CASE
    /// Ensure null/empty value and isPuzzlePiece is true => invalidOperationException 
    /// </summary>
    /// <param name="ctorValue">The initial Value of the GameCell</param>
    /// <param name="isPuzzlePiece">This is true for ALL cases it indicates NO CHANGES allowed.</param>
    /// <param name="newValue">The new value attempting to change the GameCell</param>
    /// <param name="expectedException">This is InvalidOperationException for ALL cases</param>
    [TestCase(1, true, 2, typeof(InvalidOperationException))] 
    [TestCase(1, true, 3, typeof(InvalidOperationException))]
    [TestCase(1, true, 4, typeof(InvalidOperationException))]
    [TestCase(1, true, 5, typeof(InvalidOperationException))]
    [TestCase(1, true, 6, typeof(InvalidOperationException))]
    [TestCase(1, true, 7, typeof(InvalidOperationException))]
    [TestCase(1, true, 8, typeof(InvalidOperationException))]
    [TestCase(1, true, 9, typeof(InvalidOperationException))]
    [TestCase(1, true, null, typeof(InvalidOperationException))] 
    

    public void GameCellCtorWithValueAndIsPuzzleReturnsInvalidOperation(int? ctorValue, bool isPuzzlePiece, int? newValue, Type expectedException)
    {
      Assert.Throws(expectedException, () => GameCellCtorAndChangeValue(ctorValue, isPuzzlePiece, newValue));
    }

    /// <summary>
    /// Cycles through INVALID ctor combinations
    /// </summary>
    /// <param name="ctorValue">Initial Cell Value</param>
    /// <param name="isPuzzlePiece">Indicates if the GameCell is part of the puzzle</param>
    /// <param name="expectedException">Expected Exception Based on provided values.</param>
    [TestCase(null, true, typeof(InvalidOperationException))]
    [TestCase(10, true, typeof(InvalidOperationException))]
    [TestCase(10, false, typeof(InvalidOperationException))]
    [TestCase(0, true, typeof(InvalidOperationException))]
    [TestCase(0, false, typeof(InvalidOperationException))]
    public void GameCellCtorWithInvalidCtorValueCombinationsReturnsInvalidOperationException(int? ctorValue,
      bool isPuzzlePiece, Type expectedException)
    {
      Assert.Throws(expectedException, () => GameCellCtor(ctorValue, isPuzzlePiece), $" Expected Exception on combo: {ctorValue} | {isPuzzlePiece} | {nameof(expectedException)}");
    }

    /// <summary>
    /// Cycles through VALID ctor combinations
    /// </summary>
    /// <param name="ctorValue">Initial GameCell Value</param>
    /// <param name="isPuzzlePiece">Indicates if the GameCell is part of the puzzle</param>
    [TestCase(null, false)]
    [TestCase(1, false)]
    [TestCase(2, false)]
    [TestCase(3, false)]
    [TestCase(4, false)]
    [TestCase(5, false)]
    [TestCase(6, false)]
    [TestCase(7, false)]
    [TestCase(8, false)]
    [TestCase(9, false)]
    [TestCase(1, true)]
    [TestCase(2, true)]
    [TestCase(3, true)]
    [TestCase(4, true)]
    [TestCase(5, true)]
    [TestCase(6, true)]
    [TestCase(7, true)]
    [TestCase(8, true)]
    [TestCase(9, true)]
    public void GameCellCtorWithValidCtorValueCompletesWithoutError(int? ctorValue, bool isPuzzlePiece)
    {
      Assert.DoesNotThrow(() => GameCellCtor(ctorValue, isPuzzlePiece));
    }

    private GameCell GameCellCtorAndChangeValue(int? ctorValue, bool isPuzzlePiece, int? newValue)
    {
      var newCell = GameCellCtor(ctorValue, isPuzzlePiece);
      newCell.Value = newValue;
      AssertProperties(newCell, newValue, isPuzzlePiece);
      return newCell;
    }

    private GameCell GameCellCtor(int? ctorValue, bool isPuzzlePiece)
    {
      var newCell = new GameCell(ctorValue, isPuzzlePiece);
      Assert.NotNull(newCell, $"Ctor failed on values: {ctorValue} | {isPuzzlePiece}.");
      AssertProperties(newCell, ctorValue, isPuzzlePiece);
      return newCell;
    }

    private void AssertProperties(GameCell cell, int? value, bool isPuzzlePiece)
    {
      Assert.AreEqual(cell.Value, value, $"Cell Property 'Value' does not match: EXPECTED: {value} | ACTUAL: {cell.Value}.");
      Assert.AreEqual(cell.IsPuzzleValue, isPuzzlePiece, $"Cell Property 'IsPuzzlePiece' does not match: EXPECTED: {isPuzzlePiece} | ACTUAL: {cell.IsPuzzleValue}");
    }

  }
}
