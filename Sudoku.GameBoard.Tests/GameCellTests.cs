using Microsoft.Extensions.Logging;
using Sudoku.Engine.Tests.Loggers;
using Sudoku.GameBoard.Exceptions;

namespace Sudoku.GameBoard.Tests
{
  public class GameCellTests
  {
    private readonly ILogger _Logger;

    public GameCellTests()
    {
      var loggerFactory = LoggerFactory.Create(config =>
      {
        config.AddProvider(new NUnitLoggerProvider())
          .SetMinimumLevel(LogLevel.Trace);
      });
      _Logger = loggerFactory.CreateLogger<GameBoardTests>();
    }

    /// <summary>
    /// Cycle through changing the valid initial value to ANY VALID VALUE including null/empty
    /// Ensure InvalidOperationException is thrown when initial value is a puzzle piece
    /// NULL Initial value TEST CASE
    /// Ensure null/empty value and isPuzzlePiece is true => invalidOperationException 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="ctorValue">The initial Value of the GameCell</param>
    /// <param name="isPuzzlePiece">This is true for ALL cases it indicates NO CHANGES allowed.</param>
    /// <param name="groupIndex">Group Index relative to entire board [top left, read right, to bottom right]</param>
    /// <param name="rowIndex">Row Index relative to the entire board [top to bottom]</param>
    /// <param name="columnIndex">Column Index relative to the entire board [left to right]</param>
    /// <param name="columnPosition">Column position relative to the group it is located.[Left, Middle, Right]</param>
    /// <param name="rowPosition">Column position relative to the group it is located.[Top, Middle, Bottom]</param>
    /// <param name="newValue">The new value attempting to change the GameCell</param>
    /// <param name="expectedException">This is InvalidOperationException for ALL cases</param>
    [TestCase(0, 1, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 2, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 3, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 4, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 6, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 7, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 8, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 9, typeof(InvalidOperationException))]
    [TestCase(0, 1, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, null, typeof(InvalidOperationException))]
    [TestCase(0, 1, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, null, typeof(GameInvalidValuesInBoard))]
    [TestCase(0, 2, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, null, typeof(GameInvalidValuesInBoard))]
    [TestCase(0, 3, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, null, typeof(GameInvalidValuesInBoard))]
    [TestCase(0, 4, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, null, typeof(GameInvalidValuesInBoard))]
    [TestCase(0, 5, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, null, typeof(GameInvalidValuesInBoard))]
    [TestCase(0, 6, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, null, typeof(GameInvalidValuesInBoard))]
    [TestCase(0, 7, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, null, typeof(GameInvalidValuesInBoard))]
    [TestCase(0, 8, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, null, typeof(GameInvalidValuesInBoard))]
    [TestCase(0, 9, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, null, typeof(GameInvalidValuesInBoard))]
    [TestCase(0, null, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, null, typeof(GameInvalidValuesInBoard))]
    public void GameCellCtorWithValueAndIsPuzzleReturnsInvalidOperation(int index, int? ctorValue, bool isPuzzlePiece, 
      int groupIndex, int rowIndex, int columnIndex,
      GroupColumnPosition columnPosition, GroupRowPosition rowPosition,
      int? newValue, Type expectedException)
    {
      Assert.Throws(expectedException, () => GameCellCtorAndChangeValue(ctorValue, index, isPuzzlePiece, 
        groupIndex, rowIndex, columnIndex,
        columnPosition, rowPosition,
        newValue, _Logger));
    }

    [TestCase(0, null, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 1)]
    [TestCase(0, null, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 2)]
    [TestCase(0, null, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 3)]
    [TestCase(0, null, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 4)]
    [TestCase(0, null, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, null, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 6)]
    [TestCase(0, null, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 7)]
    [TestCase(0, null, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 8)]
    [TestCase(0, null, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 9)]
    [TestCase(0, 1, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 1)]
    [TestCase(0, 1, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 2)]
    [TestCase(0, 1, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 3)]
    [TestCase(0, 1, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 4)]
    [TestCase(0, 1, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 1, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 6)]
    [TestCase(0, 1, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 7)]
    [TestCase(0, 1, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 8)]
    [TestCase(0, 1, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 9)]
    [TestCase(0, 2, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 1)]
    [TestCase(0, 2, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 2)]
    [TestCase(0, 2, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 3)]
    [TestCase(0, 2, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 2, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 2, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 6)]
    [TestCase(0, 2, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 7)]
    [TestCase(0, 2, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 8)]
    [TestCase(0, 2, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 9)]
    [TestCase(0, 3, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 1)]
    [TestCase(0, 3, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 2)]
    [TestCase(0, 3, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 3)]
    [TestCase(0, 3, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 3, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 3, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 6)]
    [TestCase(0, 3, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 7)]
    [TestCase(0, 3, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 8)]
    [TestCase(0, 3, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 9)]
    [TestCase(0, 4, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 1)]
    [TestCase(0, 4, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 2)]
    [TestCase(0, 4, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 3)]
    [TestCase(0, 4, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 4, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 4, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 6)]
    [TestCase(0, 4, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 7)]
    [TestCase(0, 4, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 8)]
    [TestCase(0, 4, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 9)]
    [TestCase(0, 5, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 1)]
    [TestCase(0, 5, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 2)]
    [TestCase(0, 5, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 3)]
    [TestCase(0, 5, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 5, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 5, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 6)]
    [TestCase(0, 5, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 7)]
    [TestCase(0, 5, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 8)]
    [TestCase(0, 5, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 9)]
    [TestCase(0, 6, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 1)]
    [TestCase(0, 6, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 2)]
    [TestCase(0, 6, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 3)]
    [TestCase(0, 6, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 6, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 6, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 6)]
    [TestCase(0, 6, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 7)]
    [TestCase(0, 6, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 8)]
    [TestCase(0, 6, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 9)]
    [TestCase(0, 7, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 1)]
    [TestCase(0, 7, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 2)]
    [TestCase(0, 7, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 3)]
    [TestCase(0, 7, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 7, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 7, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 6)]
    [TestCase(0, 7, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 7)]
    [TestCase(0, 7, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 8)]
    [TestCase(0, 7, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 9)]
    [TestCase(0, 8, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 1)]
    [TestCase(0, 8, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 2)]
    [TestCase(0, 8, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 3)]
    [TestCase(0, 8, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 8, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 8, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 6)]
    [TestCase(0, 8, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 7)]
    [TestCase(0, 8, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 8)]
    [TestCase(0, 8, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 9)]
    [TestCase(0, 9, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 1)]
    [TestCase(0, 9, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 2)]
    [TestCase(0, 9, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 3)]
    [TestCase(0, 9, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 9, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 5)]
    [TestCase(0, 9, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 6)]
    [TestCase(0, 9, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 7)]
    [TestCase(0, 9, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 8)]
    [TestCase(0, 9, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, 9)]
    public void GameCellCtorWithValidValueAndNotPuzzleThenCellHasNewValue(int index, int? ctorValue, bool isPuzzlePiece,
      int groupIndex, int rowIndex, int columnIndex,
      GroupColumnPosition columnPosition, GroupRowPosition rowPosition,
      int? newValue)
    {
      Assert.DoesNotThrow(() => GameCellCtorAndChangeValue(ctorValue, index, isPuzzlePiece, 
        groupIndex, rowIndex, columnIndex,
        columnPosition, rowPosition,
        newValue, _Logger));
    }

    /// <summary>
    /// Cycles through INVALID ctor combinations
    /// </summary>
    /// <param name="index">Initial Cell Index in Game Board</param>
    /// <param name="ctorValue">Initial Cell Value</param>
    /// <param name="isPuzzlePiece">Indicates if the GameCell is part of the puzzle</param>
    /// <param name="groupIndex">Group Index relative to entire board [top left, read right, to bottom right]</param>
    /// <param name="rowIndex">Row Index relative to the entire board [top to bottom]</param>
    /// <param name="columnIndex">Column Index relative to the entire board [left to right]</param>
    /// <param name="columnPosition">Column position relative to the group it is located.[Left, Middle, Right]</param>
    /// <param name="rowPosition">Column position relative to the group it is located.[Top, Middle, Bottom]</param>
    /// <param name="expectedException">Expected Exception Based on provided values.</param>
    [TestCase(0, null, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, typeof(InvalidOperationException))]
    [TestCase(0, 10, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, typeof(InvalidOperationException))]
    [TestCase(0, 10, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, typeof(InvalidOperationException))]
    [TestCase(0, 0, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, typeof(InvalidOperationException))]
    [TestCase(0, 0, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top, typeof(InvalidOperationException))]
    // ReSharper disable once InconsistentNaming
    public void GameCellCtorWithInvalidCtorValueCombinationsReturnsInvalidOperationException(int index, int? ctorValue, bool isPuzzlePiece, 
      int groupIndex, int rowIndex, int columnIndex,
      GroupColumnPosition columnPosition, GroupRowPosition rowPosition,
      Type expectedException)
    {
      Assert.Throws(expectedException, () => GameCellCtor(ctorValue, index, isPuzzlePiece,
        groupIndex, rowIndex, columnIndex, columnPosition, rowPosition,
        _Logger), $" Expected Exception : {ctorValue} | {isPuzzlePiece} | {nameof(expectedException)}");
    }

    /// <summary>
    /// Cycles through VALID ctor combinations
    /// </summary>
    /// <param name="index">the Game Cell's index position in GameBoard</param>
    /// <param name="ctorValue">Initial GameCell Value</param>
    /// <param name="isPuzzlePiece">Indicates if the GameCell is part of the puzzle</param>
    /// <param name="groupIndex"></param>
    /// <param name="rowIndex"></param>
    /// <param name="columnIndex"></param>
    /// <param name="columnPosition"></param>
    /// <param name="rowPosition"></param>
    [TestCase( null,0, false, 0,0,0,GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 1,0, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 2,0, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 3,0, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 4,0, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 5,0, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 6,0, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 7,0, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 8,0, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 9,0, false, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 1,0, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 2,0, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 3,0, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 4,0, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 5,0, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 6,0, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 7,0, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 8,0, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    [TestCase( 9, 0, true, 0, 0, 0, GroupColumnPosition.Left, GroupRowPosition.Top)]
    // ReSharper disable once InconsistentNaming
    public void GameCellCtorWithValidCtorValueCompletesWithoutError(int? ctorValue, int index, bool isPuzzlePiece,
      int groupIndex, int rowIndex, int columnIndex,
      GroupColumnPosition columnPosition, GroupRowPosition rowPosition)
    {
      Assert.DoesNotThrow(() => GameCellCtor(ctorValue, index, isPuzzlePiece,
        groupIndex, rowIndex, columnIndex,
        columnPosition, rowPosition, _Logger));
    }

    [TestCase(0, null, false, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
    [TestCase(0, null, false, new[] { 1, 2, 3, 3, 3, 4, 4, 4, 5 })]
    public void AddValidAndPossiblyDuplicatePencilMarksToCellWithoutException(int index, int? ctorValue, 
      bool isPuzzleValue, int[] pencilMarks)
    {
      //generate game cell
      var newCell = GameCellFactory.Create(ctorValue, isPuzzleValue, index, _Logger);

      //add pencil marks provided (all valid, possible duplicates
      // but that should be allowed as well)
      newCell.AddPencilMarks(pencilMarks);

      //verify pencil mark is there
      foreach (var pencilMark in pencilMarks)
      {
        Assert.That(newCell.PencilMarks.Where(x => x == pencilMark), Has.Exactly(1).Items);
      }
    }

    private static GameCell GameCellCtorAndChangeValue(int? ctorValue, int index, bool isPuzzlePiece,
      int groupIndex, int rowIndex, int columnIndex,
      GroupColumnPosition columnPosition, GroupRowPosition rowPosition,
      int? newValue, ILogger logger)
    {
      var newCell = GameCellCtor(ctorValue, index, isPuzzlePiece, 
        groupIndex, rowIndex, columnIndex, 
        columnPosition, rowPosition, logger);
      newCell.SetValue(newValue);
      AssertProperties(newCell, newValue, isPuzzlePiece,
        groupIndex, rowIndex, columnIndex,
        columnPosition, rowPosition);
      return newCell;
    }

    private static GameCell GameCellCtor(int? ctorValue, int index,  bool isPuzzlePiece,
      int groupIndex, int rowIndex, int columnIndex,
      GroupColumnPosition columnPosition, GroupRowPosition rowPosition, ILogger logger)
    {
      var newCell = GameCellFactory.Create(ctorValue, isPuzzlePiece, index, logger);
      Assert.That(newCell, Is.Not.Null, $"Ctor failed on values: index={index} | ctorValue={ctorValue} | isPuzzlePiece={isPuzzlePiece}.");
      AssertProperties(newCell, ctorValue, isPuzzlePiece, groupIndex, rowIndex, columnIndex, columnPosition, rowPosition);
      return newCell;
    }

    private static void AssertProperties(IGameCell cell, int? expectedValue, bool isPuzzlePiece,
      int groupIndex, int rowIndex, int columnIndex,
      GroupColumnPosition columnPosition, GroupRowPosition rowPosition)
    {
      Assert.Multiple(() =>
      {
        Assert.That(cell.Value, Is.EqualTo(expectedValue), $"Cell Property 'Value' does not match: EXPECTED: {expectedValue} | ACTUAL: {cell.Value}.");
        Assert.That(cell.IsPuzzleValue, Is.EqualTo(isPuzzlePiece), $"Cell Property 'IsPuzzlePiece' does not match: EXPECTED: {isPuzzlePiece} | ACTUAL: {cell.IsPuzzleValue}");
        Assert.That(cell.GroupIndex, Is.EqualTo(groupIndex));
        Assert.That(cell.RowIndex, Is.EqualTo(rowIndex));
        Assert.That(cell.ColumnIndex, Is.EqualTo(columnIndex));
        Assert.That(cell.GroupColumnPosition, Is.EqualTo(columnPosition));
        Assert.That(cell.GroupRowPosition, Is.EqualTo(rowPosition));
      });
    }
  }
}
