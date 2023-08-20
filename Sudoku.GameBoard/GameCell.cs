using Sudoku.GameBoard.Constants;
using Sudoku.GameBoard.Exceptions;

namespace Sudoku.GameBoard
{
  public class GameCell : IGameCell 
  {
    private static readonly string _EmptyValueAsString = " ";

    public int Index { get; set; }
    public int GroupIndex { get; set; }
    public int RowIndex { get; set; }
    public int ColumnIndex { get; set; }

    /// <summary>
    /// This value indicates if this GameCell Value is part of the original puzzle values
    /// </summary>
    public bool IsPuzzleValue { get; }

    /// <summary>
    /// A list of 'pencil marks' that indicate possible values for the solve.
    /// </summary>
    public int?[]? PossibleValues { get; set; }
    
    /// <summary>
    /// The solve or puzzle value of the cell
    /// </summary>
    public int? Value {
      get => _CellValue;
      set
      {
        if (IsPuzzleValue)
        {
          throw new InvalidOperationException("Cannot change a puzzle value.");
        }

        _CellValue = value;

        ClearGroupRowColumnOfPencilMark(value);
      }
    }

    private void ClearGroupRowColumnOfPencilMark(int? pencilMarkToRemove)
    {

    }

    public IEnumerable<int> PencilMarks { get; set; } = Enumerable.Empty<int>();

    private int? _CellValue = null;

    /// <summary>
    /// The individual cell holding a single number for the solve or part of the puzzle.
    /// </summary>
    /// <param name="index">Game Cell's index in Game Board</param>
    /// <param name="initialCellValue"></param>
    /// <param name="isPuzzleValue"></param>
    public GameCell(int index, int? initialCellValue, bool isPuzzleValue = false)
    {
      Index = index;
      GenerateGroupRowColumnIndexes(index);
      _CellValue = initialCellValue;
      IsPuzzleValue = isPuzzleValue;
      ValidateInput();
      Index = index;
    }

    private void GenerateGroupRowColumnIndexes(int index)
    {
      GroupIndex = CellIndexToGroupRowColumnValues.CellIndexes[index, GameGuides.GROUP_ARRAY_INDEX_VALUE];
      RowIndex = CellIndexToGroupRowColumnValues.CellIndexes[index, GameGuides.ROW_ARRAY_INDEX_VALUE];
      ColumnIndex = CellIndexToGroupRowColumnValues.CellIndexes[index, GameGuides.COLUMN_ARRAY_INDEX_VALUE];
    }

    public override string ToString()
    {
      var valueAsString = Convert.ToString(Value);
      return valueAsString ?? _EmptyValueAsString;
    }

    private void ValidateInput()
    {
      var cannotInitializeNullOrEmptyValueAndBeAPuzzlePiece = IsPuzzleValue && _CellValue == null;
      if (cannotInitializeNullOrEmptyValueAndBeAPuzzlePiece)
      {
        throw new InvalidOperationException("Can NOT construct GameCell as PuzzlePiece and a null/empty value.");
      }

      var invalidValuesAreNotAllowed = _CellValue is < 1 or > 9;
      if (invalidValuesAreNotAllowed)
      {
        throw new InvalidOperationException("Invalid Value provided.  Valid Values are 1-9(always) or null(when not a puzzle piece)");
      } 
    }

    public void AddPencilMark(int pencilMark)
    {
      //EnsureGameCellHasNoGameValueAlready();
      var needToAddPencilMark = !PencilMarks.Contains(pencilMark);
      if (needToAddPencilMark)
      {
        PencilMarks = PencilMarks.Concat(new List<int>() { pencilMark });
      }
    }

    private void EnsureGameCellHasNoGameValueAlready()
    {
      if (Value.HasValue)
      {
        throw new NoPencilMarksAllowedWhenValueAlreadyExists();
      }
    }
  }
}
