using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.GameBoard.Tests.GameBoards
{
  internal static class GameBoardInputs
  {
    public static string GameBoardAllCellsFilled = "123456789" +
                                                   "234567891" +
                                                   "345678912" +
                                                   "456789123" +
                                                   "567891234" +
                                                   "678912345" +
                                                   "789123456" +
                                                   "891234567" +
                                                   "912345678";

    public static string GameBoardSomeEmptyCellsByZeros = "123456780" +
                                                   "234567891" +
                                                   "345670912" +
                                                   "456789123" +
                                                   "567891234" +
                                                   "678012345" +
                                                   "789123456" +
                                                   "891234567" +
                                                   "912340678";
    public static string GameBoardSomeEmptyCellsBySpaces = "12345678 " +
                                                           "234567891" +
                                                           "34567 912" +
                                                           "456789123" +
                                                           "567891234" +
                                                           "678 12345" +
                                                           "789123456" +
                                                           "891234567" +
                                                           "91234 678";

  }
}
