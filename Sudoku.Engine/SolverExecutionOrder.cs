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
    public static int HiddenPair = 5;

    /// <summary>
    /// There is a pair of cells in a group, row, or column
    /// with two matching values (with NO OTHER pencil marks)
    /// that only exist in those two cells for that group, row, column.
    /// REMOVE other pencil marks in that row, column, or group.
    /// </summary>
    public static int NakedPair = 6;

    /// <summary>
    /// There is a GroupRow or GroupColumn in a group
    /// that has NO OTHER pencil marks in the overall Row or Column.
    /// REMOVE other pencil marks in the rest of the Row or Column.
    /// </summary>
    public static int LockedCandidate = 7;

    /// <summary>
    /// Due to the alternating strong and weak links between the same candidates within a region
    /// and the different candidates within the same cell, we know that either all of solve 1 or all of solve 2 are correct.
    /// - find a naked pair(cross groups) - then solve both possible values and see
    ///   if there is a common removed pencil mark(s) then remove those pencil marks
    /// Example: Hell Board 01 -
    /// https://sudoku.coach/en/solver/478215936396748251521369487930000600100600590600090700269000874814976325753482169
    /// </summary>
    public static int AlternationInferenceChain = 8;
  }
}
