using Microsoft.Extensions.Logging;
using Sudoku.GameBoard.Helpers;
using Sudoku.GameBoard.Loggers;
using Sudoku.GameBoard.Validators;
using System.Text;
using System.Text.Json.Serialization;

// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

#pragma warning disable CS8618

namespace Sudoku.GameBoard
{
  public delegate void GameBoardHadActivity(IGameBoard gameBoard);

  public class GameBoard : IGameBoard
  {
    public event GameBoardHadActivity OnChanged;

    private readonly ILogger _Logger;

    public IList<GameCell> Cells { get; set; }

    [JsonIgnore]
    public IList<GameBoardGroup> Groups
    {
      get
      {
        var groups = new List<GameBoardGroup>();
        for (int groupIndex = 0; groupIndex < 9; groupIndex++)
        {
          var newGroup = GetGroupBy(groupIndex);
          groups.Add(newGroup);
        }
        return groups;
      }
    }

    [JsonIgnore]
    public IList<GameBoardRow> Rows
    {
      get
      {
        var rows = new List<GameBoardRow>();
        for (int rowIndex = 0; rowIndex < 9; rowIndex++)
        {
          var newRow = GetRowBy(rowIndex);
          rows.Add(newRow);
        }
        return rows;
      }
    }

    [JsonIgnore]
    public IList<GameBoardColumn> Columns
    {
      get
      {
        var columns = new List<GameBoardColumn>();
        for (int columnIndex = 0; columnIndex < 9; columnIndex++)
        {
          var newColumn = GetColumnBy(columnIndex);
          columns.Add(newColumn);
        }
        return columns;
      }
    }

    public GameBoard(IList<GameCell> gameCells, ILogger logger)
    {
      _Logger = logger;
      Cells = gameCells;
      RegisterCellEvents();
      logger.LogAction("Board Created", BuildZeroBasedString());
    }

    public string BuildZeroBasedString()
    {
      var boardWithZerosForBlank = string.Join("", Cells.Select(x => x.Value ?? 0));
      return boardWithZerosForBlank;
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

    public GameCell GetCellByIndex(int cellIndex)
    {
      return Cells[cellIndex];
    }

    public GameBoardGroup GetGroupBy(int groupIndex)
    {
      GameBoardValidator.EnsureGroupNumberIsValid(groupIndex);
      var indexList = GameBoardHelper.GetGroupCellIndexesBy(groupIndex);
      var groupCells = indexList!.Select(GetCellByIndex).ToList();
      var returnObject = new GameBoardGroup(groupCells);
      return returnObject;
    }

    public GameBoardRow GetRowBy(int rowIndex)
    {
      GameBoardValidator.EnsureRowNumberIsValid(rowIndex);
      var indexList = GameBoardHelper.GetRowCellIndexesBy(rowIndex);
      var rowCells = indexList!.Select(GetCellByIndex).ToList();
      var returnObject = new GameBoardRow(rowCells);
      return returnObject;
    }

    public GameBoardColumn GetColumnBy(int columnIndex)
    {
      GameBoardValidator.EnsureColumnNumberIsValid(columnIndex);
      var indexList = GameBoardHelper.GetColumnCellIndexesBy(columnIndex);
      var columnCells = indexList!.Select(GetCellByIndex).ToList();
      var returnObject = new GameBoardColumn(columnCells);
      return returnObject;
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

    public void Validate()
    {
      GameBoardValidator.ValidateBoard(this);
    }

    private static StringBuilder GenerateRow(StringBuilder stringBuilder, IList<GameCell> gameCells, int startOffset)
    {
      var cell1 = gameCells[startOffset].Value.ToString();
      var cell1String = cell1 == "" ? " " : cell1;
      var cell2 = gameCells[startOffset + 1].Value.ToString();
      var cell2String = cell2 == "" ? " " : cell2;
      var cell3 = gameCells[startOffset + 2].Value.ToString();
      var cell3String = cell3 == "" ? " " : cell3;
      var cell4 = gameCells[startOffset + 3].Value.ToString();
      var cell4String = cell4 == "" ? " " : cell4;
      var cell5 = gameCells[startOffset + 4].Value.ToString();
      var cell5String = cell5 == "" ? " " : cell5;
      var cell6 = gameCells[startOffset + 5].Value.ToString();
      var cell6String = cell6 == "" ? " " : cell6;
      var cell7 = gameCells[startOffset + 6].Value.ToString();
      var cell7String = cell7 == "" ? " " : cell7;
      var cell8 = gameCells[startOffset + 7].Value.ToString();
      var cell8String = cell8 == "" ? " " : cell8;
      var cell9 = gameCells[startOffset + 8].Value.ToString();
      var cell9String = cell9 == "" ? " " : cell9;

      stringBuilder.Append("| ");
      stringBuilder.Append(cell1String);
      stringBuilder.Append(" | ");
      stringBuilder.Append(cell2String);
      stringBuilder.Append(" | ");
      stringBuilder.Append(cell3String);
      stringBuilder.Append(" || ");
      stringBuilder.Append(cell4String);
      stringBuilder.Append(" | ");
      stringBuilder.Append(cell5String);
      stringBuilder.Append(" | ");
      stringBuilder.Append(cell6String);
      stringBuilder.Append(" || ");
      stringBuilder.Append(cell7String);
      stringBuilder.Append(" | ");
      stringBuilder.Append(cell8String);
      stringBuilder.Append(" | ");
      stringBuilder.Append(cell9String);
      stringBuilder.Append(" ||");

      return stringBuilder;
    }

    private void RegisterCellEvents()
    {
      foreach (var cell in Cells)
      {
        cell.OnChanged += ClearPencilMarksFor;
        cell.OnPencilMarksChanged += PencilMarksChanged;
      }
    }

    private void ReportBoardChanged()
    {
      OnChanged?.Invoke(this);
    }

    private void PencilMarksChanged(IGameCell cell)
    {
      ReportBoardChanged();
    }

    private void ClearPencilMarksFor(IGameCell cell)
    {
      _Logger.LogAction("SOLVED CELL", $"Value:{cell.Value}/group:{cell.GroupIndex}/row:{cell.RowIndex}/column:{cell.ColumnIndex}/");
      var group = GetGroupBy(cell.GroupIndex);
      var row = GetRowBy(cell.RowIndex);
      var column = GetColumnBy(cell.ColumnIndex);
      group.ClearPencilMark(cell.Value);
      row.ClearPencilMark(cell.Value);
      column.ClearPencilMark(cell.Value);
      ReportBoardChanged();
    }
  }
}