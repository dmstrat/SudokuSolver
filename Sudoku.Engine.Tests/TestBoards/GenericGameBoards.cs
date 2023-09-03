using Microsoft.Extensions.Logging.Abstractions;
using Sudoku.GameBoard;
using Sudoku.GameBoard.Constants;

namespace Sudoku.Engine.Tests.TestBoards
{
  internal class GenericGameBoards
  {
    internal static IGameBoard EmptyGameBoard
    {
      get
      {
        var nullLogger = new NullLogger<GenericGameBoards>();
        var listof81EmptyGameCells = new List<GameCell>();
        for (int i = 0; i < GameGuides.ValidGameCellCount; i++)
        {
          listof81EmptyGameCells.Add(new GameCell(i, null, nullLogger, false));
        }
        var newGameBoard = new GameBoard.GameBoard(listof81EmptyGameCells);
        return newGameBoard;
      }
    }
  }
}
