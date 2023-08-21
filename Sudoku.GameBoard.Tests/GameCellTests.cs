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
    [TestCase(0, 1, true, 2, typeof(InvalidOperationException))] 
    [TestCase(0, 1, true, 3, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 4, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 5, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 6, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 7, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 8, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 9, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, null, typeof(InvalidOperationException))] 
    

    public void GameCellCtorWithValueAndIsPuzzleReturnsInvalidOperation(int index, int? ctorValue, bool isPuzzlePiece, int? newValue, Type expectedException)
    {
      Assert.Throws(expectedException, () => GameCellCtorAndChangeValue(index, ctorValue, isPuzzlePiece, newValue));
    }

    [TestCase(0, null, false, null)]
    [TestCase(0, null, false, 1)]
    [TestCase(0, null, false, 2)]
    [TestCase(0, null, false, 3)]
    [TestCase(0, null, false, 4)]
    [TestCase(0, null, false, 5)]
    [TestCase(0, null, false, 6)]
    [TestCase(0, null, false, 7)]
    [TestCase(0, null, false, 8)]
    [TestCase(0, null, false, 9)]
    [TestCase(0, 1, false, null)]
    [TestCase(0, 1, false, 1)]
    [TestCase(0, 1,false,2)]
    [TestCase(0, 1, false, 3)]
    [TestCase(0, 1, false, 4)]
    [TestCase(0, 1, false, 5)]
    [TestCase(0, 1, false, 6)]
    [TestCase(0, 1, false, 7)]
    [TestCase(0, 1, false, 8)]
    [TestCase(0, 1, false, 9)]
    [TestCase(0, 2, false, null)]
    [TestCase(0, 2, false, 1)]
    [TestCase(0, 2, false, 2)]
    [TestCase(0, 2, false, 3)]
    [TestCase(0, 2, false, 5)]
    [TestCase(0, 2, false, 5)]
    [TestCase(0, 2, false, 6)]
    [TestCase(0, 2, false, 7)]
    [TestCase(0, 2, false, 8)]
    [TestCase(0, 2, false, 9)]
    [TestCase(0, 3, false, null)]
    [TestCase(0, 3, false, 1)]
    [TestCase(0, 3, false, 2)]
    [TestCase(0, 3, false, 3)]
    [TestCase(0, 3, false, 5)]
    [TestCase(0, 3, false, 5)]
    [TestCase(0, 3, false, 6)]
    [TestCase(0, 3, false, 7)]
    [TestCase(0, 3, false, 8)]
    [TestCase(0, 3, false, 9)]
    [TestCase(0, 4, false, null)]
    [TestCase(0, 4, false, 1)]
    [TestCase(0, 4, false, 2)]
    [TestCase(0, 4, false, 3)]
    [TestCase(0, 4, false, 5)]
    [TestCase(0, 4, false, 5)]
    [TestCase(0, 4, false, 6)]
    [TestCase(0, 4, false, 7)]
    [TestCase(0, 4, false, 8)]
    [TestCase(0, 4, false, 9)]
    [TestCase(0, 5, false, null)]
    [TestCase(0, 5, false, 1)]
    [TestCase(0, 5, false, 2)]
    [TestCase(0, 5, false, 3)]
    [TestCase(0, 5, false, 5)]
    [TestCase(0, 5, false, 5)]
    [TestCase(0, 5, false, 6)]
    [TestCase(0, 5, false, 7)]
    [TestCase(0, 5, false, 8)]
    [TestCase(0, 5, false, 9)]
    [TestCase(0, 6, false, null)]
    [TestCase(0, 6, false, 1)]
    [TestCase(0, 6, false, 2)]
    [TestCase(0, 6, false, 3)]
    [TestCase(0, 6, false, 5)]
    [TestCase(0, 6, false, 5)]
    [TestCase(0, 6, false, 6)]
    [TestCase(0, 6, false, 7)]
    [TestCase(0, 6, false, 8)]
    [TestCase(0, 6, false, 9)]
    [TestCase(0, 7, false, null)]
    [TestCase(0, 7, false, 1)]
    [TestCase(0, 7, false, 2)]
    [TestCase(0, 7, false, 3)]
    [TestCase(0, 7, false, 5)]
    [TestCase(0, 7, false, 5)]
    [TestCase(0, 7, false, 6)]
    [TestCase(0, 7, false, 7)]
    [TestCase(0, 7, false, 8)]
    [TestCase(0, 7, false, 9)]
    [TestCase(0, 8, false, null)]
    [TestCase(0, 8, false, 1)]
    [TestCase(0, 8, false, 2)]
    [TestCase(0, 8, false, 3)]
    [TestCase(0, 8, false, 5)]
    [TestCase(0, 8, false, 5)]
    [TestCase(0, 8, false, 6)]
    [TestCase(0, 8, false, 7)]
    [TestCase(0, 8, false, 8)]
    [TestCase(0, 8, false, 9)]
    [TestCase(0, 9, false, null)]
    [TestCase(0, 9, false, 1)]
    [TestCase(0, 9, false, 2)]
    [TestCase(0, 9, false, 3)]
    [TestCase(0, 9, false, 5)]
    [TestCase(0, 9, false, 5)]
    [TestCase(0, 9, false, 6)]
    [TestCase(0, 9, false, 7)]
    [TestCase(0, 9, false, 8)]
    [TestCase(0, 9, false, 9)]

    public void GameCellCtorWithValidValueAndNotPuzzleThenCellHasNewValue(int index, int? ctorValue, bool isPuzzlePiece, int? newValue)
    {
      Assert.DoesNotThrow(() => GameCellCtorAndChangeValue(index, ctorValue, isPuzzlePiece, newValue));
    }

    /// <summary>
    /// Cycles through INVALID ctor combinations
    /// </summary>
    /// <param name="index">Initial Cell Index in Game Board</param>
    /// <param name="ctorValue">Initial Cell Value</param>
    /// <param name="isPuzzlePiece">Indicates if the GameCell is part of the puzzle</param>
    /// <param name="expectedException">Expected Exception Based on provided values.</param>
    [TestCase(0, null, true, typeof(InvalidOperationException))]
    [TestCase(0, 10, true, typeof(InvalidOperationException))]
    [TestCase(0, 10, false, typeof(InvalidOperationException))]
    [TestCase(0, 0, true, typeof(InvalidOperationException))]
    [TestCase(0, 0, false, typeof(InvalidOperationException))]
    // ReSharper disable once InconsistentNaming
    public void GameCellCtorWithInvalidCtorValueCombinationsReturnsInvalidOperationException(int index, int? ctorValue,
      bool isPuzzlePiece, Type expectedException)
    {
      Assert.Throws(expectedException, () => GameCellCtor(index, ctorValue, isPuzzlePiece), $" Expected Exception on combo: {ctorValue} | {isPuzzlePiece} | {nameof(expectedException)}");
    }

    /// <summary>
    /// Cycles through VALID ctor combinations
    /// </summary>
    /// <param name="index">the Game Cell's index position in GameBoard</param>
    /// <param name="ctorValue">Initial GameCell Value</param>
    /// <param name="isPuzzlePiece">Indicates if the GameCell is part of the puzzle</param>
    [TestCase(0, null, false)]
    [TestCase(0, 1, false)]
    [TestCase(0, 2, false)]
    [TestCase(0, 3, false)]
    [TestCase(0, 4, false)]
    [TestCase(0, 5, false)]
    [TestCase(0, 6, false)]
    [TestCase(0, 7, false)]
    [TestCase(0, 8, false)]
    [TestCase(0, 9, false)]
    [TestCase(0, 1, true)]
    [TestCase(0, 2, true)]
    [TestCase(0, 3, true)]
    [TestCase(0, 4, true)]
    [TestCase(0, 5, true)]
    [TestCase(0, 6, true)]
    [TestCase(0, 7, true)]
    [TestCase(0, 8, true)]
    [TestCase(0, 9, true)]
    // ReSharper disable once InconsistentNaming
    public void GameCellCtorWithValidCtorValueCompletesWithoutError(int index, int? ctorValue, bool isPuzzlePiece)
    {
      Assert.DoesNotThrow(() => GameCellCtor(index, ctorValue, isPuzzlePiece));
    }

    [TestCase(0, null, false, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
    [TestCase(0, null, false, new[] { 1, 2, 3, 3, 3, 4, 4, 4, 5 })]
    public void AddValidPencilMarksToCellWithoutException(int index, int? ctorValue, bool isPuzzleValue, int[] pencilMarks)
    {
      //generate game cell
      //add pencil marks provided (all valid, possible duplicates but that should be allowed as well)
      //no failures/exceptions or otherwise. 
      //verify pencil mark is there
      var newCell = new GameCell(index, ctorValue, isPuzzleValue);
      foreach (var pencilMark in pencilMarks)
      {
        newCell.AddPencilMark(pencilMark);
        Assert.That(newCell.PencilMarks.Where(x=>x == pencilMark), Has.Exactly(1).Items);
      }
    }

    private static GameCell GameCellCtorAndChangeValue(int index, int? ctorValue, bool isPuzzlePiece, int? newValue)
    {
      var newCell = GameCellCtor(index, ctorValue, isPuzzlePiece);
      newCell.Value = newValue;
      AssertProperties(newCell, newValue, isPuzzlePiece);
      return newCell;
    }

    private static GameCell GameCellCtor(int index, int? ctorValue, bool isPuzzlePiece)
    {
      var newCell = new GameCell(index, ctorValue, isPuzzlePiece);
      Assert.That(newCell, Is.Not.Null, $"Ctor failed on values: index={index} | ctorValue={ctorValue} | isPuzzlePiece={isPuzzlePiece}.");
      AssertProperties(newCell, ctorValue, isPuzzlePiece);
      return newCell;
    }

    private static void AssertProperties(GameCell cell, int? expectedValue, bool isPuzzlePiece)
    {
      Assert.Multiple(() =>
      {
        Assert.That(cell.Value, Is.EqualTo(expectedValue), $"Cell Property 'Value' does not match: EXPECTED: {expectedValue} | ACTUAL: {cell.Value}.");
        Assert.That(cell.IsPuzzleValue, Is.EqualTo(isPuzzlePiece), $"Cell Property 'IsPuzzlePiece' does not match: EXPECTED: {isPuzzlePiece} | ACTUAL: {cell.IsPuzzleValue}");
      });
    }

  }
}
