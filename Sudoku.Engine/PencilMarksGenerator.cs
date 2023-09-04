using Sudoku.GameBoard;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Sudoku.Engine.Loggers;
#pragma warning disable CS8629 // Nullable value type may be null.
namespace Sudoku.Engine
{
  
  public class PencilMarksGenerator
  {
    public static readonly int[] ValidGameNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private readonly ILogger _Logger;

    public PencilMarksGenerator(ILogger logger)
    {
      _Logger = logger;
    }
    public IGameBoard GeneratePencilMarks(IGameBoard gameBoard)
    {
      using (_Logger.BeginScope("Generating Pencil Marks"))
      {
        _Logger.LogStep(1,$"Generate Pencil Marks - Start {DateTime.UtcNow:O}");
        foreach (var cell in gameBoard.Cells)
        {
          ComputePencilMarksForCell(gameBoard, cell);
        }
        _Logger.LogStep(3, $"Generate Pencil Marks - Finish {DateTime.UtcNow:O}");
        return gameBoard;
      }
    }

    private void ComputePencilMarksForCell(IGameBoard gameBoard, GameCell cell)
    {
      var numberOfListsJoined = 3;
      var haveWorkToDo = !cell.Value.HasValue;
      if (haveWorkToDo)
      {
        //get group, row, and column
        var group = gameBoard.GetGroupBy(cell);
        var row = gameBoard.GetRowBy(cell);
        var column = gameBoard.GetColumnBy(cell);
        //determine possible pencil marks 
        //what are the missing numbers from group?
        var actualNumbersFromGroup = group.Cells.Where(x => x.Value.HasValue).Select(y=>y.Value.Value).ToList();
        var missingNumbersFromGroup = ValidGameNumbers.Except(actualNumbersFromGroup);
        //missing numbers from column?
        var actualNumbersFromRow = row.Cells.Where(x => x.Value.HasValue).Select(y=>y.Value.Value).ToList();
        var missingNumbersFromRow = ValidGameNumbers.Except(actualNumbersFromRow);
        //missing numbers from row?
        var actualNumbersFromColumn = column.Cells.Where(x => x.Value.HasValue).Select(y=>y.Value.Value).ToList();
        var missingNumbersFromColumn = ValidGameNumbers.Except(actualNumbersFromColumn);
        //merge missing numbers from all lists
        var missingNumbersFromGroupAndColumnAndRow = missingNumbersFromGroup
          .Concat(missingNumbersFromRow.Concat(missingNumbersFromColumn));
        //build list of numbers that are missing in EVERY list
        var actualMissingNumbersForThisCell = missingNumbersFromGroupAndColumnAndRow.GroupBy(val => val)
          .Where(numGroup => numGroup.Count() == numberOfListsJoined)
          .Select(groupValue => groupValue.Key).ToArray();

        _Logger.LogStep(2, $"Cell Index: {cell.Index} => Pencil Marks: {string.Join(",", actualMissingNumbersForThisCell)}");
          cell.AddPencilMarks(actualMissingNumbersForThisCell);
      }
    }
  }
}
