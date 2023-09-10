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

  public int GetIndex()
  {
    return Index;
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

  public void ClearPencilMarksNotIn(GameBoardGroupColumn groupColumn)
  {
    var distinctPencilMarksInGroupColumn = groupColumn.Cells.SelectMany(x => x.PencilMarks).Distinct();
    ClearPencilMarksNotIn(groupColumn.Cells, distinctPencilMarksInGroupColumn);
  }

  public void ClearPencilMarksNotIn(GameBoardGroupRow groupRow)
  {
    var distinctPencilMarksInGroupColumn = groupRow.Cells.SelectMany(x => x.PencilMarks).Distinct();
    ClearPencilMarksNotIn(groupRow.Cells, distinctPencilMarksInGroupColumn);
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

  private void ClearPencilMarksNotIn(IEnumerable<GameCell> cells, IEnumerable<int> valuesToClear)
  {
    var cellsNotProvided = Cells.Except(cells);

    foreach (var number in valuesToClear)
    {
      foreach (var cell in cellsNotProvided)
      {
        cell.ClearPencilMark(number);
      }
    }

  }

  public GameBoardGroupColumn GetColumnCells(GroupColumnPosition columnPosition)
  {
    var cells = Cells.Where(x => x.GroupColumnPosition == columnPosition);
    var groupColumn = new GameBoardGroupColumn(cells);
    return groupColumn;
  }

  public GameBoardGroupRow GetRowCells(GroupRowPosition rowPosition)
  {
    var cells = Cells.Where(x => x.GroupRowPosition == rowPosition);
    var groupRow = new GameBoardGroupRow(cells);
    return groupRow;
  }
}