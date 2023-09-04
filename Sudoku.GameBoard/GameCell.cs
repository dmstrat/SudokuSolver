using Microsoft.Extensions.Logging;
using Sudoku.GameBoard.Exceptions;
using Sudoku.GameBoard.Loggers;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

#pragma warning disable CS8618

namespace Sudoku.GameBoard;

// ReSharper disable InconsistentNaming
public delegate void CellValueUpdated(IGameCell cell);
public delegate void CellPencilMarksChanged(IGameCell cell);

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public class GameCell : IGameCell
{
  public event CellValueUpdated OnChanged;
  public event CellPencilMarksChanged OnPencilMarksChanged;

  private const string _EmptyValueAsString = " ";
  private IEnumerable<int> _PencilMarks = new List<int>();
  private int? _Value;
  private readonly ILogger _Logger;

  /// <summary>
  /// The individual cell that holds a single number for the game.
  /// </summary>
  /// <param name="initialValue">The initial value for the cell.  Blank/Empty/Null/0 means Empty Cell [1-9]</param>
  /// <param name="isPuzzleValue">If set to true, is considered part of the puzzle and can not change.</param>
  /// <param name="index">Game Cell's index in Game Board [0-80]</param>
  /// <param name="groupIndex">The index value for the group the cell is located [0-8]</param>
  /// <param name="rowIndex">Row Index for the position of the cell in the game relative to the gameBoard [0-8]</param>
  /// <param name="columnIndex">Column Index for the position of the cell in the game relative to the gameBoard</param>
  /// <param name="columnPosition">Column position relative to the group the cell is located [Left, Middle, Right]</param>
  /// <param name="rowPosition">The row position relative to the Group the cell is located [Top, Middle, Bottom]</param>
  /// <param name="logger">logger to be used by this class</param>
  public GameCell(int? initialValue, bool isPuzzleValue, int index,
    int groupIndex, int rowIndex, int columnIndex,
    ColumnPosition columnPosition, RowPosition rowPosition, ILogger logger)
  {
    _Value = initialValue;
    IsPuzzleValue = isPuzzleValue;
    Index = index;
    GroupIndex = groupIndex;
    RowIndex = rowIndex;
    ColumnIndex = columnIndex;
    ColumnPosition = columnPosition;
    RowPosition = rowPosition;
    _Logger = logger;
    ValidateInput();
  }

  /// <summary>
  ///   Represents the cell's index in an array of all game cells in game board (zero-based)
  ///   from left to right, top to bottom (0-80)
  /// </summary>
  [Required(ErrorMessage = "Cell's Index MUST be provided.")]
  [Range(0, 80, ErrorMessage = "Value for {0} MUST be between {1} and {2} inclusively.")]
  public int Index { get; }

  /// <summary>
  ///   This value indicates if this GameCell Value is part of the original puzzle values
  ///   This will indicate that the value can NOT be changed.
  /// </summary>
  public bool IsPuzzleValue { get; }

  /// <summary>
  ///   The solve or puzzle value of the cell
  /// </summary>
  [Range(1, 9, ErrorMessage = "Value for {0} MUST be between {1} and {2} inclusively.")]
  public int? Value
  {
    get => _Value;
    set
    {
      if (IsPuzzleValue)
      {
        throw new InvalidOperationException("Cannot change a puzzle value.");
      }

      _Value = value;
      if (value == null)
      {
        return;
      }

      ClearPencilMarks();
      OnChanged?.Invoke(this);
    }
  }

  /// <summary>
  /// Represents the group the cell belongs index (zero-based) from left to right, top to bottom (0-8)
  /// </summary>
  [Required(ErrorMessage = "GroupIndex MUST be supplied.")]
  [Range(0, 8, ErrorMessage = "Value for {0} MUST be between {1} and {2} inclusively.")]
  public int GroupIndex { get; private set; }

  /// <summary>
  ///   Represents the row index (zero-based) from top to bottom (0-8)
  /// </summary>
  [Required(ErrorMessage = "RowIndex MUST be supplied.")]
  [Range(0, 8, ErrorMessage = "Value for {0} MUST be between {1} and {2} inclusively.")]
  public int RowIndex { get; private set; }

  /// <summary>
  /// Represents the column index (zero-based) from left to right (0-8)
  /// </summary>
  [Required(ErrorMessage = "ColumnIndex MUST be supplied.")]
  [Range(0, 8, ErrorMessage = "Value for {0} MUST be between {1} and {2} inclusively.")]
  public int ColumnIndex { get; private set; }

  /// <summary>
  /// Represents the column position in the group it resides.
  ///   Possible Values: Left, Middle, Right
  /// </summary>
  [Required(ErrorMessage = "ColumnPosition MUST be supplied.")]
  public ColumnPosition ColumnPosition { get; private set; }

  /// <summary>
  /// Represents the row position in the group it resides.
  ///   Possible Values: Top, Middle, Bottom
  /// </summary>
  [Required(ErrorMessage = "RowPosition MUST be supplied.")]
  public RowPosition RowPosition { get; private set; }

  /// <summary>
  /// Represents the POSSIBLE values for this cell
  /// </summary>
  public IEnumerable<int> PencilMarks
  {
    get => _PencilMarks;
    set
    {
      var noWork = PencilMarksAreNotDifferent(_PencilMarks, value);
      if (noWork)
      {
        return;
      }
      _Logger.LogAction("CELL Pencil Marks - BEFORE", DebuggerDisplay);
      _PencilMarks = value;
      OnPencilMarksChanged?.Invoke(this);
      _Logger.LogAction("CELL Pencil Marks - AFTER", DebuggerDisplay);
    }
  }

  /// <summary>
  /// Removes provided value from Pencil Marks
  /// </summary>
  /// <param name="pencilMark"></param>
  public void ClearPencilMark(int pencilMark)
  {
    var newPencilMarks = PencilMarks.Select(x => x).Except(new List<int> { pencilMark });
    PencilMarks = newPencilMarks;
    CheckCell();
  }

  /// <summary>
  /// Removes provided values from Pencil Marks
  /// </summary>
  public void ClearPencilMarks()
  {
    PencilMarks = new List<int>();
    CheckCell();
  }

  /// <summary>
  /// Adds provided values to Pencil Marks
  /// </summary>
  /// <param name="pencilMarks"></param>
  public void AddPencilMarks(int[] pencilMarks)
  {
    foreach (var pencilMark in pencilMarks)
    {
      AddPencilMark(pencilMark);
    }
  }

  /// <summary>
  /// Adds provided value to Pencil Marks
  /// </summary>
  /// <param name="pencilMark"></param>
  public void AddPencilMark(int pencilMark)
  {
    var doNotAddPencilMarksToSolvedCells = _Value.HasValue;

    if (doNotAddPencilMarksToSolvedCells)
    {
      return;
    }

    var needToAddPencilMark = !PencilMarks.Contains(pencilMark);
    if (needToAddPencilMark)
    {
      _PencilMarks = PencilMarks.Concat(new List<int> { pencilMark });
    }
  }

  public override string ToString()
  {
    var valueAsString = Convert.ToString(Value) ?? _EmptyValueAsString;
    var returnValue = valueAsString.Length == 0 ? _EmptyValueAsString : valueAsString;
    return returnValue;
  }

  private void ValidateInput()
  {
    var cannotInitializeNullOrEmptyValueAndBeAPuzzlePiece = IsPuzzleValue && _Value == null;
    if (cannotInitializeNullOrEmptyValueAndBeAPuzzlePiece)
    {
      throw new InvalidOperationException("Can NOT construct GameCell as PuzzlePiece and a null/empty value.");
    }

    var invalidValuesAreNotAllowed = _Value is < 1 or > 9;
    if (invalidValuesAreNotAllowed)
    {
      throw new InvalidOperationException(
        "Invalid Value provided.  Valid Values are 1-9(always) or null(when not a puzzle piece)");
    }
  }

  private void CheckCell()
  {
    var hasNoValueOrPencilMarks = !PencilMarks.Any() & !Value.HasValue;
    if (hasNoValueOrPencilMarks)
    {
      throw new GameInvalidValuesInBoard("Can not have empty PencilMarks AND no Value for cell");
    }
  }

  private static bool PencilMarksAreNotDifferent(IEnumerable<int> existingPencilMarks, IEnumerable<int> newPencilMarks)
  {
    return existingPencilMarks.OrderBy(x => x).SequenceEqual(newPencilMarks.OrderBy(x => x));
  }

  private string DebuggerDisplay
  {
    get
    {
      var cellValue = Value.HasValue ? Value.Value.ToString() : _EmptyValueAsString;
      var debuggerString =
        $"<{Index}>[{cellValue}]: {string.Join(",", PencilMarks)} / group: {GroupIndex} / row: {RowIndex} / column: {ColumnIndex} /";
      return debuggerString;
    }
  }
}