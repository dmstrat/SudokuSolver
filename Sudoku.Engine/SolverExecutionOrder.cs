namespace Sudoku.Engine
{
  internal static class SolverExecutionOrder
  {
    /// <summary>
    /// Removes any pencil marks that do not belong
    /// based on a cell having a solved value in the group, column, or row.
    /// Used at beginning of game
    /// REMOVE those invalid pencil marks
    /// </summary>
    public static int EliminateCandidates = 0;

    /// <summary>
    /// When there is only one pencil mark for the cell being examined.
    /// SOLVE the cell with that pencil mark.
    /// </summary>
    public static int LastDigit = 1;

    /// <summary>
    /// The cell being examined has a pencil mark that does not exist
    /// in any other cell for that group.
    /// SOLVE that cell to that pencil mark.
    /// </summary>
    public static int HiddenSingleGroup = 2;

    /// <summary>
    /// The cell being examined has a pencil mark that does not exist
    /// in any other cell for that row.
    /// SOLVE that cell to that pencil mark.
    /// </summary>
    public static int HiddenSingleRow = 3;

    /// <summary>
    /// The cell being examined has a pencil mark that does not exist
    /// in any other cell for that column.
    /// SOLVE that cell to that pencil mark.
    /// </summary>
    public static int HiddenSingleColumn = 4;

    /// <summary>
    /// There is a pair of cells in a group, row, or column
    /// with two matching values (with other pencil marks)
    /// that only exist in those two cells for that group, row, column.
    /// REMOVE other pencil marks 
    /// </summary>
    public static int HiddenPair = 3;

    /// <summary>
    /// There is a pair of cells in a group, row, or column
    /// with two matching values (with NO OTHER pencil marks)
    /// that only exist in those two cells for that group, row, column.
    /// REMOVE other pencil marks in that row, column, or group.
    /// </summary>
    public static int NakedPair = 4;

    /// <summary>
    /// There is a GroupRow or GroupColumn in a group
    /// that has NO OTHER pencil marks in the overall Row or Column.
    /// REMOVE other pencil marks in the rest of the Row or Column.
    /// </summary>
    public static int LockedCandidate = 5;
  }
}
