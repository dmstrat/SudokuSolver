namespace Sudoku.Engine.Tests.TestBoards
{
  public static class GameBoard01
  {
    public const string MissingOneNumberPerRowAndColumn_Input = "12345678 " +
                                                                "4567891 3" +
                                                                "789123 56" +
                                                                "23456 891" +
                                                                "5678 1234" +
                                                                "891 34567" +
                                                                "34 678912" +
                                                                "6 8912345" +
                                                                " 12345678";

    public const string MissingWholeGroup_Input = "123456   " +
                                                  "456789   " +
                                                  "789123   " +
                                                  "234567891" +
                                                  "567891234" +
                                                  "891234567" +
                                                  "345678912" +
                                                  "678912345" +
                                                  "912345678";

    public const string MissingOneValueFromOneGroup_Input = "      78 " +
                                                            "      123" +
                                                            "      456" +
                                                            "234567   " +
                                                            "567891   " +
                                                            "891234   " +
                                                            "345678   " +
                                                            "678912   " +
                                                            "912345   ";

    public const string Solved_Output = "123456789" +
                                        "456789123" +
                                        "789123456" +
                                        "234567891" +
                                        "567891234" +
                                        "891234567" +
                                        "345678912" +
                                        "678912345" +
                                        "912345678";
  }
}
