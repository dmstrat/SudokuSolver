using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Sudoku.GameBoard.Constants;
using Sudoku.GameBoard.Exceptions;
using Sudoku.GameBoard.Loggers;
using System.Diagnostics;

namespace Sudoku.GameBoard;

// ReSharper disable InconsistentNaming
public delegate void CellValueUpdated(IGameCell cell);
public delegate void CellPencilMarksUpdated(IGameCell cell);

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public class GameCell : IGameCell
{
  private const string _EmptyValueAsString = " ";
  private IEnumerable<int> _PencilMarks = new List<int>();
  private int? _Value;
  private readonly ILogger _Logger;

  /// <summary>
  /// The individual cell that holds a single number for the game.
  /// </summary>
  /// <param name="index">Game Cell's index in Game Board</param>
  /// <param name="initialValue">The initial value for the cell.  Blank/Empty/Null/0 means Empty Cell</param>
  /// <param name="logger">logger to be used by this class</param>
  /// <param name="rowPosition">The row position relative to the Group the cell is in</param>
  /// <param name="isPuzzleValue">If set to true, is considered part of the puzzle and can not change.</param>
  /// <param name="groupIndex">The index value for the group the cell is located</param>
  /// <param name="columnPosition">The column position relative to the group the cell is located</param>
  public GameCell(int index, int? initialValue, bool isPuzzleValue, int groupIndex, ColumnPosition columnPosition, RowPosition rowPosition, ILogger logger)
  {
    _Logger = logger;
    Index = index;
    GenerateGroupRowColumnIndexes(index);
    _Value = initialValue;
    IsPuzzleValue = isPuzzleValue;
    ValidateInput();
    Index = index;
    ColumnPosition = columnPosition;
    RowPosition = rowPosition;
    CellValueUpdated += NoOpGameCellUpdateMethod;
    CellPencilMarksUpdated += NoOpGameCellUpdateMethod;
  }

  /// <summary>
  ///   Represents the cell's index in an array of all game cells in game board (zero-based)
  ///   from left to right, top to bottom (0-80)
  /// </summary>
  [Required, Range(0,81)]
  public int Index { get; private set; }

  /// <summary>
  ///   Represents the group the cell belongs index (zero-based) from left to right, top to bottom (0-8)
  /// </summary>
  [Required, Range(0,8)]
  public int GroupIndex { get; private set; }

  /// <summary>
  ///   Represents the row index (zero-based) from top to bottom (0-8)
  /// </summary>
  [Required, Range(0, 8)]
  public int RowIndex { get; private set; }

  /// <summary>
  ///   Represents the column index (zero-based) from left to right (0-8)
  /// </summary>
  [Required, Range(0, 8)]
  public int ColumnIndex { get; private set; }

  /// <summary>
  ///   Represents the column position in the group it resides.
  ///   Possible Values: Left, Middle, Right
  /// </summary>
  [Required]
  public ColumnPosition ColumnPosition { get; private set; }

  /// <summary>
  ///   Represents the row position in the group it resides.
  ///   Possible Values: Top, Middle, Bottom
  /// </summary>
  [Required]
  public RowPosition RowPosition { get; private set; }

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

  /// <summary>
  ///   Represents the POSSIBLE values for this cell
  /// </summary>
  private IEnumerable<int> PencilMarks
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
      CellPencilMarksUpdated(this);
      _Logger.LogAction("CELL Pencil Marks - AFTER", DebuggerDisplay);
    }
  }

  private bool PencilMarksAreNotDifferent(IEnumerable<int> existingPencilMarks, IEnumerable<int> newPencilMarks)
  {
    return existingPencilMarks.OrderBy(x => x).SequenceEqual(newPencilMarks.OrderBy(x => x));
  }

  /// <summary>
  ///   This value indicates if this GameCell Value is part of the original puzzle values
  ///   This will indicate that the value can NOT be changed.
  /// </summary>
  public bool IsPuzzleValue { get; }

  /// <summary>
  ///   The solve or puzzle value of the cell
  /// </summary>
  [Range(1,9)]
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
      CellValueUpdated(this);
    }
  }

  public int GetGroupIndex()
  {
    return GroupIndex;
  }

  public int GetRowIndex()
  {
    return RowIndex;
  }

  public int GetColumnIndex()
  {
    return ColumnIndex;
  }

  public IEnumerable<int> GetPencilMarks()
  {
    return PencilMarks;
  }

  public void ClearPencilMark(int cellValue)
  {
    var newPencilMarks = PencilMarks.Select(x => x).Except(new List<int> { cellValue });
    PencilMarks = newPencilMarks;
    CheckCell();
  }

  public void ClearPencilMarks()
  {
    PencilMarks = new List<int>();
    CheckCell();
  }

  public event CellValueUpdated CellValueUpdated;
  public event CellPencilMarksUpdated CellPencilMarksUpdated;

  public override string ToString()
  {
    var valueAsString = Convert.ToString(Value) ?? _EmptyValueAsString;
    var returnValue = valueAsString.Length == 0 ? _EmptyValueAsString : valueAsString;
    return returnValue;
  }

  public void AddPencilMarks(int[] pencilMarks)
  {
    foreach (var pencilMark in pencilMarks)
    {
      AddPencilMark(pencilMark);
    }
  }

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

  private static void NoOpGameCellUpdateMethod(IGameCell cell)
  {
    //intentionally no-op method
  }

  private void GenerateGroupRowColumnIndexes(int index)
  {
    GroupIndex = CellIndexToGroupRowColumnValues.CellIndexes[index, GameGuides.GROUP_ARRAY_INDEX_VALUE];
    RowIndex = CellIndexToGroupRowColumnValues.CellIndexes[index, GameGuides.ROW_ARRAY_INDEX_VALUE];
    ColumnIndex = CellIndexToGroupRowColumnValues.CellIndexes[index, GameGuides.COLUMN_ARRAY_INDEX_VALUE];
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
}