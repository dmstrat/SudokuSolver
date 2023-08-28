using Sudoku.GameBoard;
using System.Diagnostics;

namespace Sudoku.Engine
{
    internal class PencilMarksGenerator : IPencilMarkGenerator
    {
        private IGameBoard _GameBoard;

        public IGameBoard GeneratePencilMarks(IGameBoard gameBoard)
        {
            _GameBoard = gameBoard;
            Trace.WriteLine("Computing Pencil Marks for all cells");
            Trace.Indent();
            foreach (var cell in _GameBoard.GetCells())
            {
                ComputePencilMarksForCell(cell);
            }
            Trace.Unindent();
            Trace.WriteLine("Pencil Marks Complete!");
            return _GameBoard;
        }

        private void ComputePencilMarksForCell(GameCell cell)
        {
            var numberOfListsJoined = 3;
            var haveWorkToDo = !cell.Value.HasValue;
            if (haveWorkToDo)
            {
                var validGameNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                //get group, row, and column
                var group = _GameBoard.GetGroupBy(cell);
                var row = _GameBoard.GetRowBy(cell);
                var column = _GameBoard.GetColumnBy(cell);
                //determine possible pencil marks 
                //what are the missing numbers from group?
                var actualNumberListFromGroup = group.Cells.Select(x => x.Value ?? 0).Except(new List<int>() { 0 }).ToList();
                var missingNumbersListFromGroup = validGameNumbers.Except(actualNumberListFromGroup);
                //missing numbers from column?
                var actualNumberListFromRow = row.Cells.Select(x => x.Value ?? 0).Except(new List<int>() { 0 }).ToList();
                var missingNumbersListFromRow = validGameNumbers.Except(actualNumberListFromRow);
                //missing numbers from row?
                var actualNumberListFromColumn = column.Cells.Select(x => x.Value ?? 0).Except(new List<int>() { 0 }).ToList();
                var missingNumbersListFromColumn = validGameNumbers.Except(actualNumberListFromColumn);
                //merge missing numbers from all lists
                var allMissingNumbersJoinedTogether = missingNumbersListFromGroup
                  .Concat(missingNumbersListFromRow.Concat(missingNumbersListFromColumn));//.Distinct();
                                                                                          //build list of numbers that are in every list
                var missingNumbers = allMissingNumbersJoinedTogether.GroupBy(val => val)
                  .Where(group => group.Count() == numberOfListsJoined)
                  .Select(groupValue => groupValue.Key).ToList();

                Trace.WriteLine($"Cell Index: {cell.Index} => Pencil Marks: {string.Join(",", missingNumbers)}");//add missing numbers as pencil marks to cell 
                foreach (var missingNumber in missingNumbers)
                {
                    cell.AddPencilMark(missingNumber);
                }
            }
        }
    }
}
