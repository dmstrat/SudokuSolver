namespace Sudoku.GameBoard
{
  public class GameCell : IGameCell 
  {
    private static readonly string _EmptyValueAsString = " ";

    /// <summary>
    /// This value indicates if this GameCell Value is part of the original puzzle values
    /// </summary>
    public bool IsPuzzleValue { get; }

    /// <summary>
    /// A list of 'pencil marks' that indicate possible values for the solve.
    /// </summary>
    public int?[] PossibleValues { get; set; }
    
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
      }
    }

    private int? _CellValue = null;

    /// <summary>
    /// The individual cell holding a single number for the solve or part of the puzzle.
    /// </summary>
    /// <param name="initialCellValue"></param>
    /// <param name="isPuzzleValue"></param>
    public GameCell(int? initialCellValue, bool isPuzzleValue = false)
    {

      _CellValue = initialCellValue;
      IsPuzzleValue = isPuzzleValue;
      ValidateInput();
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
  }
}
