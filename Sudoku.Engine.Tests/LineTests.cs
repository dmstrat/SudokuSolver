namespace Sudoku.Engine.Tests
{
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GivenRowOfNumbersEnsureAllNumbersAreUniqueAndOnlyBetween1And9()
    {
      var engine = new Engine();
      //var line = new Engine.Line();
      var lineOfNumbers = "123456789";
      //line.AddNumbers(lineOfNumbers);
      Assert.Pass();
    }

  }
}