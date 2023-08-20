namespace Sudoku.GameBoard.Tests.GameBoards
{
  public static class GameBoardInputs
  {
    public const string GameBoard01AllCellsFilled = "123456789" +
                                                    "456789123" +
                                                    "789123456" +
                                                    "234567891" +
                                                    "567891234" +
                                                    "891234567" +
                                                    "345678912" +
                                                    "678912345" +
                                                    "912345678";

    public const string GameBoard02SomeEmptyCellsByZeros = "123456780" + 
                                                           "456789123" +
                                                           "789123056" +
                                                           "234567891" +
                                                           "567891234" +
                                                           "891204567" +
                                                           "345678912" +
                                                           "678912345" +
                                                           "912045678";

    public const string GameBoard02SomeEmptyCellsBySpaces = "12345678 " +
                                                            "456789123" +
                                                            "789123 56" +
                                                            "234567891" +
                                                            "567891234" +
                                                            "8912 4567" +
                                                            "345678912" +
                                                            "678912345" +
                                                            "912 45678";

    public const string GameBoard02InvalidRow = "12445678 " +
                                                " 56789123" +
                                                "789123 56" +
                                                "23 567891" +
                                                "567891234" +
                                                "8912 4567" +
                                                "345678912" +
                                                "678912345" +
                                                "912 45678";

    public const string GameBoard02InvalidColumn = "12345678 " +
                                                   "456789123" +
                                                   "789123 56" +
                                                   "234567891" +
                                                   "567891234" +
                                                   "8912 4567" +
                                                   "38567 912" +
                                                   "67 912345" +
                                                   "912 45678";

    public const string GameBoard02InvalidGroup = "12345678 " +
                                                  "45 689123" +
                                                  "7 9123 58" +
                                                  "2  567891" +
                                                  "5  891234" +
                                                  "8  2 4567" +
                                                  "3   78912" +
                                                  "6  912345" +
                                                  "9   4567 ";


  }
}
