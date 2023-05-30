using Sudoku.GameBoard.Constants;

namespace Sudoku.GameBoard
{
  public static class GameBoardRowFactory
  {
    public static GameBoardRow Create(IGameBoard gameBoard, int rowNumber)
    {
      return GetRowFromGameBoardBy(gameBoard, rowNumber);
    }

    private static GameBoardRow GetRowFromGameBoardBy(IGameBoard gameBoard, int rowNumber)
    {
      int[] rowNumberArray;
      switch (rowNumber)
      {
        case 1:
          rowNumberArray = GameBoardRowCellNumbers.RowNumber1;
          return BuildRowByArrayOfIndexes(gameBoard, rowNumberArray);
        case 2:
          rowNumberArray = GameBoardRowCellNumbers.RowNumber2;
          return BuildRowByArrayOfIndexes(gameBoard, rowNumberArray);
        case 3:
          rowNumberArray = GameBoardRowCellNumbers.RowNumber3;
          return BuildRowByArrayOfIndexes(gameBoard, rowNumberArray);
        case 4:
          rowNumberArray = GameBoardRowCellNumbers.RowNumber4;
          return BuildRowByArrayOfIndexes(gameBoard, rowNumberArray);
        case 5:
          rowNumberArray = GameBoardRowCellNumbers.RowNumber5;
          return BuildRowByArrayOfIndexes(gameBoard, rowNumberArray);
        case 6:
          rowNumberArray = GameBoardRowCellNumbers.RowNumber6;
          return BuildRowByArrayOfIndexes(gameBoard, rowNumberArray);
        case 7:
          rowNumberArray = GameBoardRowCellNumbers.RowNumber7;
          return BuildRowByArrayOfIndexes(gameBoard, rowNumberArray);
        case 8:
          rowNumberArray = GameBoardRowCellNumbers.RowNumber8;
          return BuildRowByArrayOfIndexes(gameBoard, rowNumberArray);
        case 9:
          rowNumberArray = GameBoardRowCellNumbers.RowNumber9;
          return BuildRowByArrayOfIndexes(gameBoard, rowNumberArray);
      }

      return new GameBoardRow(new List<GameCell>());
    }

    private static GameBoardRow BuildRowByArrayOfIndexes(IGameBoard gameBoard, int[] rowNumberArray)
    {
      var newRowOfCells = rowNumberArray.Select(gameBoard.GetCellByIndex).ToList();
      var newGameBoardRow = new GameBoardRow(newRowOfCells);
      return newGameBoardRow;
    }
  }
}
