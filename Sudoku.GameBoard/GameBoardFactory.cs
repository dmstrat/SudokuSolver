using System.Globalization;

namespace Sudoku.GameBoard
{
  public static class GameBoardFactory
  {
    private static readonly int NumberOfGameCellsInGame = 81;
    private const string _EmptyValueAsSpace = " ";
    private const string _EmptyValueAsZero = "0";
    private const bool _IsPartOfPuzzle = true;
    private const bool _IsNotPartOfPuzzle = false;

    public static GameBoard Create(string gameBoardWithPuzzleNumbers)
    {
      var gameCells = new List<GameCell>();
      for (int i = 0; i < NumberOfGameCellsInGame; i++)
      {
        var newValue = gameBoardWithPuzzleNumbers[i].ToString();
        var isEmptyCellValue = newValue is _EmptyValueAsSpace or _EmptyValueAsZero;
        GameCell newCell;
        if (isEmptyCellValue)
        {
          newCell = new GameCell(null, _IsNotPartOfPuzzle);
        }
        else
        {
          _ = int.TryParse(gameBoardWithPuzzleNumbers[i].ToString(), NumberStyles.Integer, null, out var nextNumber);
          newCell = new GameCell(nextNumber, _IsPartOfPuzzle);
        }
        gameCells.Add(newCell);
      }

      var newBoard = new GameBoard(gameCells);
      newBoard.Validate();
      return newBoard;
    }
  }
}
