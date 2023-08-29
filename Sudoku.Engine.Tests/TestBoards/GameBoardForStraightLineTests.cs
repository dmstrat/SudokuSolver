namespace Sudoku.Engine.Tests.TestBoards
{
  public static class GameBoardForStraightLineTests
  {
    public const string Game_Input = " 1       " +
                                     " 2       " +
                                     " 3       " +
                                     " 4       " +
                                     " 5       " +
                                     " 6       " +
                                     "  1      " +
                                     "  2      " +
                                     "  3      ";

    public const string Game_Input_Phase_2 = " 84 761 2" +
                                             " 91  867 " +
                                             " 67  1   " +
                                             " 5     16" +
                                             "67 31    " +
                                             " 4 6    7" +
                                             "  6  2 59" +
                                             "4 9 6   1" +
                                             "7 5193 6 ";


    public const string Game_Output = "384576192" +
                                      "591428673" +
                                      "267931548" +
                                      "953287416" +
                                      "672314985" +
                                      "148659237" +
                                      "816742359" +
                                      "439865721" +
                                      "725193864";
  }
}
