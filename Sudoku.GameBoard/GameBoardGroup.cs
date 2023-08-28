namespace Sudoku.GameBoard;

public class GameBoardGroup : IGameBoardGroup
{
  public IEnumerable<GameCell> Cells { get; set; }

  public int Index
  {
    get
    {
      var firstCelGrouplIndex = Cells.First().GroupIndex;
      return firstCelGrouplIndex;
    }
  }

  public GameBoardGroup(IEnumerable<GameCell> inputGameCells)
  {
    Cells = inputGameCells;
  }

  public IEnumerable<GameCell> GetCells()
  {
    return Cells;
  }

  public string GetValuesAsString()
  {
    var newString = Cells.Select(x => x.Value).Aggregate("", (current, next) => current + (next.HasValue ? next.ToString() : " "));
    return newString;
  }

  public void ClearPencilMark(int? cellValue)
  {
    var noWorkToDo = !cellValue.HasValue;
    if (noWorkToDo) return;
    foreach (var cell in Cells)
    {
      cell.ClearPencilMark(cellValue!.Value);
    }
  }

  public GameBoardGroupColumn GetColumnCells(ColumnPosition columnPosition)
  {
    var cells = Cells.Where(x => x.ColumnPosition == columnPosition);
    var groupColumn = new GameBoardGroupColumn(cells);
    return groupColumn;
  }

  public GameBoardGroupRow GetRowCells(RowPosition rowPosition)
  {
    var cells = Cells.Where(x => x.RowPosition == rowPosition);
    var groupRow = new GameBoardGroupRow(cells);
    return groupRow;
  }
}