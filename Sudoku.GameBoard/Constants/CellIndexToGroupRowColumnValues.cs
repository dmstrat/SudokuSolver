namespace Sudoku.GameBoard.Constants
{
  internal static class CellIndexToGroupRowColumnValues
  {
    //GroupIndex, RowIndex, ColumnIndex
    public static int[,] CellIndexes
    {
      get
      {
        var indexValues = new int[,]
        {
          //row 1
          { 0, 0, 0 },
          { 0, 0, 1 },
          { 0, 0, 2 },
          { 1, 0, 3 },
          { 1, 0, 4 },
          { 1, 0, 5 },
          { 2, 0, 6 },
          { 2, 0, 7 },
          { 2, 0, 8 },
          //row 2
          { 0, 1, 0 },
          { 0, 1, 1 },
          { 0, 1, 2 },
          { 1, 1, 3 },
          { 1, 1, 4 },
          { 1, 1, 5 },
          { 2, 1, 6 },
          { 2, 1, 7 },
          { 2, 1, 8 },
          //row 3
          { 0, 2, 0 },
          { 0, 2, 1 },
          { 0, 2, 2 },
          { 1, 2, 3 },
          { 1, 2, 4 },
          { 1, 2, 5 },
          { 2, 2, 6 },
          { 2, 2, 7 },
          { 2, 2, 8 },
          //row 4
          { 3, 3, 0 },
          { 3, 3, 1 },
          { 3, 3, 2 },
          { 4, 3, 3 },
          { 4, 3, 4 },
          { 4, 3, 5 },
          { 5, 3, 6 },
          { 5, 3, 7 },
          { 5, 3, 8 },
          //row 5
          { 3, 4, 0 },
          { 3, 4, 1 },
          { 3, 4, 2 },
          { 4, 4, 3 },
          { 4, 4, 4 },
          { 4, 4, 5 },
          { 5, 4, 6 },
          { 5, 4, 7 },
          { 5, 4, 8 },
          //row 6
          { 3, 5, 0 },
          { 3, 5, 1 },
          { 3, 5, 2 },
          { 4, 5, 3 },
          { 4, 5, 4 },
          { 4, 5, 5 },
          { 5, 5, 6 },
          { 5, 5, 7 },
          { 5, 5, 8 },
          //row 7
          { 6, 6, 0 },
          { 6, 6, 1 },
          { 6, 6, 2 },
          { 7, 6, 3 },
          { 7, 6, 4 },
          { 7, 6, 5 },
          { 8, 6, 6 },
          { 8, 6, 7 },
          { 8, 6, 8 },
          //row 8
          { 6, 7, 0 },
          { 6, 7, 1 },
          { 6, 7, 2 },
          { 7, 7, 3 },
          { 7, 7, 4 },
          { 7, 7, 5 },
          { 8, 7, 6 },
          { 8, 7, 7 },
          { 8, 7, 8 },
          //row 9
          { 6, 8, 0 },
          { 6, 8, 1 },
          { 6, 8, 2 },
          { 7, 8, 3 },
          { 7, 8, 4 },
          { 7, 8, 5 },
          { 8, 8, 6 },
          { 8, 8, 7 },
          { 8, 8, 8 },
        };

        return indexValues;
      }
    }
  }


  //Row 1
  //cell index 0 -> groupindex = 0, row index = 0, column index = 0
  //cell index 1 -> groupindex = 0, row index = 0, column index = 1
  //cell index 2 -> groupindex = 0, row index = 0, column index = 2
  //cell index 3 -> groupindex = 1, row index = 0, column index = 3
  //cell index 4 -> groupindex = 1, row index = 0, column index = 4
  //cell index 5 -> groupindex = 1, row index = 0, column index = 5
  //cell index 6 -> groupindex = 2, row index = 0, column index = 6
  //cell index 7 -> groupindex = 2, row index = 0, column index = 7
  //cell index 8 -> groupindex = 2, row index = 0, column index = 8



  //Row 2
  //cell index 9  -> groupindex = 0, row index = 1, column index = 0
  //cell index 10 -> groupindex = 0, row index = 1, column index = 1
  //cell index 11 -> groupindex = 0, row index = 1, column index = 2
  //cell index 12 -> groupindex = 1, row index = 1, column index = 3
  //cell index 13 -> groupindex = 1, row index = 1, column index = 4
  //cell index 14 -> groupindex = 1, row index = 1, column index = 5
  //cell index 15 -> groupindex = 2, row index = 1, column index = 6
  //cell index 16 -> groupindex = 2, row index = 1, column index = 7
  //cell index 17 -> groupindex = 2, row index = 1, column index = 8

  //Row 3
  //cell index 18 -> groupindex = 0, row index = 2, column index = 0
  //cell index 19 -> groupindex = 0, row index = 2, column index = 1
  //cell index 20 -> groupindex = 0, row index = 2, column index = 2
  //cell index 21 -> groupindex = 1, row index = 2, column index = 3
  //cell index 22 -> groupindex = 1, row index = 2, column index = 4
  //cell index 23 -> groupindex = 1, row index = 2, column index = 5
  //cell index 24 -> groupindex = 2, row index = 2, column index = 6
  //cell index 25 -> groupindex = 2, row index = 2, column index = 7
  //cell index 26 -> groupindex = 2, row index = 2, column index = 8

  //Row 4
  //cell index 27 -> groupindex = 3, row index = 3, column index = 0
  //cell index 28 -> groupindex = 3, row index = 3, column index = 1
  //cell index 29 -> groupindex = 3, row index = 3, column index = 2
  //cell index 30 -> groupindex = 4, row index = 3, column index = 3
  //cell index 31 -> groupindex = 4, row index = 3, column index = 4
  //cell index 32 -> groupindex = 4, row index = 3, column index = 5
  //cell index 33 -> groupindex = 5, row index = 3, column index = 6
  //cell index 34 -> groupindex = 5, row index = 3, column index = 7
  //cell index 35 -> groupindex = 5, row index = 3, column index = 8

  //Row 5
  //cell index 36 -> groupindex = 3, row index = 4, column index = 0
  //cell index 37 -> groupindex = 3, row index = 4, column index = 1
  //cell index 38 -> groupindex = 3, row index = 4, column index = 2
  //cell index 39 -> groupindex = 4, row index = 4, column index = 3
  //cell index 40 -> groupindex = 4, row index = 4, column index = 4
  //cell index 41 -> groupindex = 4, row index = 4, column index = 5
  //cell index 42 -> groupindex = 5, row index = 4, column index = 6
  //cell index 43 -> groupindex = 5, row index = 4, column index = 7
  //cell index 44 -> groupindex = 5, row index = 4, column index = 8

  //Row 6
  //cell index 45 -> groupindex = 3, row index = 5, column index = 0
  //cell index 46 -> groupindex = 3, row index = 5, column index = 1
  //cell index 47 -> groupindex = 3, row index = 5, column index = 2
  //cell index 48 -> groupindex = 4, row index = 5, column index = 3
  //cell index 49 -> groupindex = 4, row index = 5, column index = 4
  //cell index 50 -> groupindex = 4, row index = 5, column index = 5
  //cell index 51 -> groupindex = 5, row index = 5, column index = 6
  //cell index 52 -> groupindex = 5, row index = 5, column index = 7
  //cell index 53 -> groupindex = 5, row index = 5, column index = 8

  //Row 7
  //cell index 54 -> groupindex = 6, row index = 6, column index = 0
  //cell index 55 -> groupindex = 6, row index = 6, column index = 1
  //cell index 56 -> groupindex = 6, row index = 6, column index = 2
  //cell index 57 -> groupindex = 7, row index = 6, column index = 3
  //cell index 58 -> groupindex = 7, row index = 6, column index = 4
  //cell index 59 -> groupindex = 7, row index = 6, column index = 5
  //cell index 60 -> groupindex = 8, row index = 6, column index = 6
  //cell index 61 -> groupindex = 8, row index = 6, column index = 7
  //cell index 62 -> groupindex = 8, row index = 6, column index = 8

  //Row 8
  //cell index 63 -> groupindex = 6, row index = 7, column index = 0
  //cell index 64 -> groupindex = 6, row index = 7, column index = 1
  //cell index 65 -> groupindex = 6, row index = 7, column index = 2
  //cell index 66 -> groupindex = 7, row index = 7, column index = 3
  //cell index 67 -> groupindex = 7, row index = 7, column index = 4
  //cell index 68 -> groupindex = 7, row index = 7, column index = 5
  //cell index 69 -> groupindex = 8, row index = 7, column index = 6
  //cell index 70 -> groupindex = 8, row index = 7, column index = 7
  //cell index 71 -> groupindex = 8, row index = 7, column index = 8

  //Row 9
  //cell index 72 -> groupindex = 6, row index = 8, column index = 0
  //cell index 73 -> groupindex = 6, row index = 8, column index = 1
  //cell index 74 -> groupindex = 6, row index = 8, column index = 2
  //cell index 75 -> groupindex = 7, row index = 8, column index = 3
  //cell index 76 -> groupindex = 7, row index = 8, column index = 4
  //cell index 77 -> groupindex = 7, row index = 8, column index = 5
  //cell index 78 -> groupindex = 8, row index = 8, column index = 6
  //cell index 79 -> groupindex = 8, row index = 8, column index = 7
  //cell index 80 -> groupindex = 8, row index = 8, column index = 8
}

