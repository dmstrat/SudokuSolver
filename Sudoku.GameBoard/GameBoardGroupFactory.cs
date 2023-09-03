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
          groupNumberArray = GameBoardGroupCellIndexes.GroupNumber1;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 2:
          groupNumberArray = GameBoardGroupCellIndexes.GroupNumber2;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 3:
          groupNumberArray = GameBoardGroupCellIndexes.GroupNumber3;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 4:
          groupNumberArray = GameBoardGroupCellIndexes.GroupNumber4;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 5:
          groupNumberArray = GameBoardGroupCellIndexes.GroupNumber5;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 6:
          groupNumberArray = GameBoardGroupCellIndexes.GroupNumber6;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 7:
          groupNumberArray = GameBoardGroupCellIndexes.GroupNumber7;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 8:
          groupNumberArray = GameBoardGroupCellIndexes.GroupNumber8;
          return BuildGroupByArrayOfIndexes(gameBoard, groupNumberArray);
        case 9:
          groupNumberArray = GameBoardGroupCellIndexes.GroupNumber9;
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
