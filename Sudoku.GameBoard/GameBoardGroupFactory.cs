using Sudoku.GameBoard.Constants;

namespace Sudoku.GameBoard
{
  public static class GameBoardGroupFactory
  {
    public static GameBoardGroup Create(IGameBoard gameBoard, int groupNumber)
    {
      return GetGroupFromGameBoardBy(gameBoard, groupNumber);
    }

    private static GameBoardGroup GetGroupFromGameBoardBy(IGameBoard gameBoard, int groupNumber)
    {
      int[] groupNumberArray;
      switch (groupNumber)
      {
        case 1:
          groupNumberArray = GameBoardGroupCellNumbers.GroupNumber1;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 2:
          groupNumberArray = GameBoardGroupCellNumbers.GroupNumber2;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 3:
          groupNumberArray = GameBoardGroupCellNumbers.GroupNumber3;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 4:
          groupNumberArray = GameBoardGroupCellNumbers.GroupNumber4;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 5:
          groupNumberArray = GameBoardGroupCellNumbers.GroupNumber5;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 6:
          groupNumberArray = GameBoardGroupCellNumbers.GroupNumber6;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 7:
          groupNumberArray = GameBoardGroupCellNumbers.GroupNumber7;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 8:
          groupNumberArray = GameBoardGroupCellNumbers.GroupNumber8;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 9:
          groupNumberArray = GameBoardGroupCellNumbers.GroupNumber9;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
      }

      return new GameBoardGroup(new List<GameCell>());
    }

    private static GameBoardGroup BuildGroupByArrayOfIndexes(IGameBoard gameBoard, int[] groupNumberArray)
    {
      var newGroupOfCells = groupNumberArray.Select(gameBoard.GetCellByIndex).ToList();
      var newGameBoardGroup = new GameBoardGroup(newGroupOfCells);
      return newGameBoardGroup;
    }
  }
}
