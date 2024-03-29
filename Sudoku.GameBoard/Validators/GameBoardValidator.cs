﻿using Sudoku.GameBoard.Constants;
using Sudoku.GameBoard.Exceptions;

namespace Sudoku.GameBoard.Validators
{
  internal static class GameBoardValidator
  {
    // ReSharper disable once InconsistentNaming
    internal static readonly int[] ValidGameNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    public static void ValidateBoard(IGameBoard board)
    {
      ValidateGameCellCount(board);
      ValidateGroups(board);
      ValidateRows(board);
      ValidateColumns(board);
    }

    internal static void ValidateGameCellCount(IGameBoard board)
    {
      var incorrectCellCount = board.Cells.Count() != GameGuides.ValidGameCellCount;
      if (incorrectCellCount)
      {
        throw new IncorrectGameCellCountForBoard();
      }
    }

    internal static void ValidateCells(IEnumerable<GameCell> listOfGameCells)
    {
      //ensure game cells provided contain empty or only one instance of each number 1-9
      var gameCellsAsArray = listOfGameCells as GameCell[] ?? listOfGameCells.ToArray();
      ValidateAllCellsAreEmptyOrBetweenOneAndNine(gameCellsAsArray);
      var hasMoreThanOneOfSomeNumberInList = ValidGameNumbers.Select(x => gameCellsAsArray.Count(y => (y.Value ?? 0) == x)).Any(z => z > 1);
      if (hasMoreThanOneOfSomeNumberInList)
      {
        throw new GameInvalidValuesInBoard("Game has at least two of the same number in a group, row, or column.");
      }
    }

    internal static void ValidateCorrectLengthOfGameCells(IEnumerable<GameCell> listOfNineGameCells, int numberOfGameCellsExpected)
    {
      var countOfProvidedCells = listOfNineGameCells.Count();
      var invalidNumberOfGameCells = countOfProvidedCells != numberOfGameCellsExpected;
      if (invalidNumberOfGameCells)
      {
        throw new InvalidNumberOfGameCells();
      }
    }

    internal static void EnsureGroupNumberIsValid(int groupIndex)
    {
      var groupNumberIsOutsideValidRange = groupIndex is < 0 or > 8;
      if (groupNumberIsOutsideValidRange)
      {
        throw new InvalidGroupNumber();
      }
    }

    internal static void EnsureRowNumberIsValid(int rowIndex)
    {
      var rowNumberIsOutsideValidRange = rowIndex is < 0 or > 8;
      if (rowNumberIsOutsideValidRange)
      {
        throw new InvalidRowNumber();
      }
    }

    internal static void EnsureColumnNumberIsValid(int columnNumber)
    {
      var columnNumberIsOutsideValidRange = columnNumber is < 0 or > 8;
      if (columnNumberIsOutsideValidRange)
      {
        throw new InvalidColumnNumber();
      }
    }

    private static void ValidateGroups(IGameBoard board)
    {
      foreach (var group in board.Groups)
      {
        ValidateGameBoardGroup(group);
      }
    }

    private static void ValidateColumns(IGameBoard board)
    {
      foreach (var column in board.Columns)
      {
        ValidateGameBoardColumn(column);
      }
    }

    private static void ValidateRows(IGameBoard board)
    {
      foreach (var row in board.Rows)
      {
        ValidateGameBoardRow(row);
      }
    }

    private static void ValidateGameBoardGroup(GameBoardGroup group)
    {
      ValidateCorrectLengthOfGameCells(group.Cells, 9);
      ValidateCells(group.Cells);
    }

    private static void ValidateGameBoardRow(GameBoardRow row)
    {
      ValidateCorrectLengthOfGameCells(row.Cells, 9);
      ValidateCells(row.Cells);
    }

    private static void ValidateGameBoardColumn(GameBoardColumn column)
    {
      ValidateCorrectLengthOfGameCells(column.Cells, 9);
      ValidateCells(column.Cells);
    }

    private static void ValidateAllCellsAreEmptyOrBetweenOneAndNine(IEnumerable<GameCell> listOfGameCells)
    {
      var hasInvalidNumber = listOfGameCells.Any(x => x.Value is < 1 or > 9);
      if (hasInvalidNumber)
      {
        throw new InvalidNumberInGameBoard();
      }
    }
  }
}
