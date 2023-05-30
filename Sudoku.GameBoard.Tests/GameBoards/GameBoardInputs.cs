using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

  }
}
