using Sudoku.GameBoard.Helpers;
using Sudoku.GameBoard.Validators;
using System.Text;

namespace Sudoku.GameBoard
{
  public class GameBoard : IGameBoard
  {
    public IList<GameCell> Cells { get; }

    public IList<GameBoardGroup> Groups
    {
      get
      {
        var groups = new List<GameBoardGroup>();
        for (int i = 1; i < 10; i++)
        {
          var newGroup = GetGroupById(i);
          groups.Add(newGroup);
        }
        return groups;
      }
    }

    public IList<GameBoardRow> Rows
    {
      get
      {
        var rows = new List<GameBoardRow>();
        for (int i = 1; i < 10; i++)
        {
          var newRow = GetRowById(i);
          rows.Add(newRow);
        }
        return rows;
      }
    }

    public IList<GameBoardColumn> Columns
    {
      get
      {
        var columns = new List<GameBoardColumn>();
        for (int i = 1; i < 10; i++)
        {
          var newColumn = GetColumnById(i);
          columns.Add(newColumn);
        }
        return columns;
      }
    }

    public GameBoard(IList<GameCell> gameCells)
    {
      Cells = gameCells;
      RegisterCellEvents();
    }

    private void RegisterCellEvents()
    {
      foreach (var cell in Cells)
      {
        cell.CellValueUpdated += ClearPencilMarksFor;
      }
    }

    private void ClearPencilMarksFor(IGameCell cell)
    {
      var group = GetGroupById(cell.GetGroupIndex()+1);
      var row = GetRowById(cell.GetRowIndex()+1);
      var column = GetColumnById(cell.GetColumnIndex()+1);
      group.ClearPencilMark(cell.Value);
      row.ClearPencilMark(cell.Value);
      column.ClearPencilMark(cell.Value);
    }

    public IEnumerable<GameBoardGroup> GetGroups()
    {
      return Groups;
    }

    public IEnumerable<GameBoardRow> GetRows()
    {
      return Rows;
    }

    public IEnumerable<GameBoardColumn> GetColumns()
    {
      return Columns;
    }

    public override string ToString()
    {
      var rowSeparator = "----------------------------------------";
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, Cells, 0);
      stringBuilder.AppendLine();
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, Cells, 0 + 9);
      stringBuilder.AppendLine();
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, Cells, 0 + 9 + 9);
      stringBuilder.AppendLine();
      stringBuilder.AppendLine(rowSeparator);
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, Cells, 0 + 9 + 9 + 9);
      stringBuilder.AppendLine();
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, Cells, 0 + 9 + 9 + 9 + 9);
      stringBuilder.AppendLine();
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, Cells, 0 + 9 + 9 + 9 + 9 + 9);
      stringBuilder.AppendLine();
      stringBuilder.AppendLine(rowSeparator);
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, Cells, 0 + 9 + 9 + 9 + 9 + 9 + 9);
      stringBuilder.AppendLine();
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, Cells, 0 + 9 + 9 + 9 + 9 + 9 + 9 + 9);
      stringBuilder.AppendLine();
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, Cells, 0 + 9 + 9 + 9 + 9 + 9 + 9 + 9 + 9);
      stringBuilder.AppendLine();
      stringBuilder.AppendLine(rowSeparator);
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      var newString = stringBuilder.ToString();
      return newString;
    }

    private static StringBuilder GenerateRow(StringBuilder stringBuilder, IList<GameCell> gameCells, int startOffset)
    {
      stringBuilder.Append("| ");
      stringBuilder.Append(gameCells[startOffset].Value.ToString());
      stringBuilder.Append(" | ");
      stringBuilder.Append(gameCells[startOffset + 1].Value.ToString());
      stringBuilder.Append(" | ");
      stringBuilder.Append(gameCells[startOffset + 2].Value.ToString());
      stringBuilder.Append(" || ");
      stringBuilder.Append(gameCells[startOffset + 3].Value.ToString());
      stringBuilder.Append(" | ");
      stringBuilder.Append(gameCells[startOffset + 4].Value.ToString());
      stringBuilder.Append(" | ");
      stringBuilder.Append(gameCells[startOffset + 5].Value.ToString());
      stringBuilder.Append(" || ");
      stringBuilder.Append(gameCells[startOffset + 6].Value.ToString());
      stringBuilder.Append(" | ");
      stringBuilder.Append(gameCells[startOffset + 7].Value.ToString());
      stringBuilder.Append(" | ");
      stringBuilder.Append(gameCells[startOffset + 8].Value.ToString());
      stringBuilder.Append(" ||");

      return stringBuilder;
    }

    public string GetValuesAsString()
    {
      var newString = Cells.Select(x => x.Value).Aggregate("", (current, next) => current + (next.HasValue ? next.ToString() : " "));
      return newString;
    }
    
    public GameBoardGroup GetGroupBy(GameCell cell)
    {
      var group = Groups[cell.GroupIndex];
      return group;
    }
    public GameBoardRow GetRowBy(GameCell cell)
    {
      var row = Rows[cell.RowIndex];
      return row;
    }
    public GameBoardColumn GetColumnBy(GameCell cell)
    {
      var column = Columns[cell.ColumnIndex];
      return column;
    }

    public IEnumerable<GameCell> GetCells()
    {
      return Cells;
    }

    public GameCell GetCellByIndex(int cellIndex)
    {
      return Cells[cellIndex];
    }

    public void Validate()
    {
      GameBoardValidator.ValidateBoard(this);
    }

    public GameBoardGroup GetGroupById(int groupNumber)
    {
      GameBoardValidator.EnsureGroupNumberIsValid(groupNumber);
      var indexList = GameBoardHelper.GetGroupIndexList(groupNumber);
      var groupCells = indexList!.Select(GetCellByIndex).ToList();
      var returnObject = new GameBoardGroup(groupCells);
      return returnObject;
    }

    public GameBoardRow GetRowById(int rowNumber)
    {
      GameBoardValidator.EnsureRowNumberIsValid(rowNumber);
      var indexList = GameBoardHelper.GetRowIndexList(rowNumber);
      var rowCells = indexList!.Select(GetCellByIndex).ToList();
      var returnObject = new GameBoardRow(rowCells);
      return returnObject;
    }

    public GameBoardColumn GetColumnById(int columnNumber)
    {
      GameBoardValidator.EnsureColumnNumberIsValid(columnNumber);
      var indexList = GameBoardHelper.GetColumnIndexList(columnNumber);
      var columnCells = indexList!.Select(GetCellByIndex).ToList();
      var returnObject = new GameBoardColumn(columnCells);
      return returnObject;
    }
  }
}