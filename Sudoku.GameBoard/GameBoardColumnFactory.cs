using Sudoku.GameBoard.Constants;

namespace Sudoku.GameBoard
{
  public static class GameBoardColumnFactory
  {
    public static GameBoardColumn Create(IGameBoard gameBoard, int rowNumber)
    {
      return GetRowFromGameBoardBy(gameBoard, rowNumber);
    }

    private static GameBoardColumn GetRowFromGameBoardBy(IGameBoard gameBoard, int columnNumber)
    {
      int[] columnNumberArray;
      switch (columnNumber)
      {
        case 1:
          columnNumberArray = GameBoardColumnCellNumbers.ColumnNumber1;
          return BuildRowByArrayOfIndexes(gameBoard, columnNumberArray);
        case 2:
          columnNumberArray = GameBoardColumnCellNumbers.ColumnNumber2;
          return BuildRowByArrayOfIndexes(gameBoard, columnNumberArray);
        case 3:
          columnNumberArray = GameBoardColumnCellNumbers.ColumnNumber3;
          return BuildRowByArrayOfIndexes(gameBoard, columnNumberArray);
        case 4:
          columnNumberArray = GameBoardColumnCellNumbers.ColumnNumber4;
          return BuildRowByArrayOfIndexes(gameBoard, columnNumberArray);
        case 5:
          columnNumberArray = GameBoardColumnCellNumbers.ColumnNumber5;
          return BuildRowByArrayOfIndexes(gameBoard, columnNumberArray);
        case 6:
          columnNumberArray = GameBoardColumnCellNumbers.ColumnNumber6;
          return BuildRowByArrayOfIndexes(gameBoard, columnNumberArray);
        case 7:
          columnNumberArray = GameBoardColumnCellNumbers.ColumnNumber7;
          return BuildRowByArrayOfIndexes(gameBoard, columnNumberArray);
        case 8:
          columnNumberArray = GameBoardColumnCellNumbers.ColumnNumber8;
          return BuildRowByArrayOfIndexes(gameBoard, columnNumberArray);
        case 9:
          columnNumberArray = GameBoardColumnCellNumbers.ColumnNumber9;
          return BuildRowByArrayOfIndexes(gameBoard, columnNumberArray);
      }

      return new GameBoardColumn(new List<GameCell>());
    }

    private static GameBoardColumn BuildRowByArrayOfIndexes(IGameBoard gameBoard, int[] columnNumberArray)
    {
      var newColumnOfCells = columnNumberArray.Select(gameBoard.GetCellByIndex).ToList();
      var newGameBoardColumn = new GameBoardColumn(newColumnOfCells);
      return newGameBoardColumn;
    }
  }
}
