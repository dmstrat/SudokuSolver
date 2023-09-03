using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Sudoku.Engine.Solvers;
using Sudoku.Engine.Tests.Loggers;
using Sudoku.Engine.Tests.TestBoards;
using Sudoku.GameBoard;
using System.Diagnostics;

namespace Sudoku.Engine.Tests.Solvers
{
  internal class Pattern01SolverTests
  {
    private ConsoleTraceListener _Listener;
    private readonly ILoggerFactory _LoggerFactory;
    private ILogger _Logger;

    public Pattern01SolverTests()
    {
      _LoggerFactory =
        new NullLoggerFactory(); //LoggerFactory.Create(c=>c.AddProvider(new NUnitLoggingProvider() ))  new NullLoggerFactory();
    }

    [SetUp]
    public void Setup()
    {
      _Logger = _LoggerFactory.CreateLogger<Pattern01SolverTests>();
      _Listener = new ConsoleTraceListener();
      Trace.Listeners.Add(_Listener);
    }

    [TearDown]
    public void Teardown()
    {
      Trace.Listeners.Remove(_Listener);
    }

    [TestCase(GameBoardForStraightLineTests.Game_Input)]
    public void GivenSimpleBoardWithStraightValuesInGroupWillRemovePencilMarksFromRestOfGroup(string gameBoardInput)
    {
      //TODO: finish writing test
      _Logger.LogBoardValues(gameBoardInput);
      //Build Game Board
      //Instance Engine 
      var gameBoard = GameBoardFactory.Create(gameBoardInput);
      var engine = new Engine(gameBoard, _LoggerFactory);
      var solvers = new List<ISolver> { new Pattern01Solver() };
      engine.RegisterSolvers(solvers);
      //Solve 
      var result = engine.Solve();
      //Verify solve (Pencil Marks as this shouldn't be solving the boards)
      var actualResults = result.GetValuesAsString();
      //Assert.That(actualResults, Is.EqualTo(solvedGameOutput));
    }

    [TestCase(GameBoardForStraightLineRowsTests.Game_Input)]
    public void GivenSimpleBoardWithStraightValuesInGroupWillRemovePencilMarksFromRestOfGroupRowsEdition(string gameBoardInput)
    {
      _Logger.LogBoardValues(gameBoardInput);
      //Build Game Board
      //Instance Engine 
      var gameBoard = GameBoardFactory.Create(gameBoardInput);
      var engine = new Engine(gameBoard, _LoggerFactory);
      var solvers = new List<ISolver> { new Pattern01Solver() };
      engine.RegisterSolvers(solvers);
      //Solve 
      var result = engine.Solve();
      //Verify solve (Pencil Marks as this shouldn't be solving the boards)
      //get pencil marks and check the values. 

      //group 1, top row should be 4, 5, 6
      var actualPencilMarksForGroupRow = result.GetGroups().First(x => x.Index == 0).GetRowCells(RowPosition.Top).GetPencilMarks().ToList();
      var expectedPencilMarks = new[] { 4, 5, 6 };
      Assert.That(actualPencilMarksForGroupRow, Is.EquivalentTo(expectedPencilMarks));
      //group 1, top row should be 7, 8 9
      actualPencilMarksForGroupRow = result.GetGroups().First(x => x.Index == 1).GetRowCells(RowPosition.Top).GetPencilMarks().ToList();
      expectedPencilMarks = new[] { 7, 8, 9 };
      Assert.That(actualPencilMarksForGroupRow, Is.EquivalentTo(expectedPencilMarks));

      //group 2, top row should be 7, 8, 9
      actualPencilMarksForGroupRow = result.GetGroups().First(x => x.Index == 1).GetRowCells(RowPosition.Top).GetPencilMarks().ToList();
      expectedPencilMarks = new[] { 7, 8, 9 };
      Assert.That(actualPencilMarksForGroupRow, Is.EquivalentTo(expectedPencilMarks));
      //group 2, bottom row should be 1, 2, 3
      actualPencilMarksForGroupRow = result.GetGroups().First(x => x.Index == 1).GetRowCells(RowPosition.Bottom).GetPencilMarks().ToList();
      expectedPencilMarks = new[] { 1, 2, 3 };
      Assert.That(actualPencilMarksForGroupRow, Is.EquivalentTo(expectedPencilMarks));

      //group 3, middle row should be 7, 8, 9
      actualPencilMarksForGroupRow = result.GetGroups().First(x => x.Index == 2).GetRowCells(RowPosition.Middle).GetPencilMarks().ToList();
      expectedPencilMarks = new[] { 7, 8, 9 };
      Assert.That(actualPencilMarksForGroupRow, Is.EquivalentTo(expectedPencilMarks));
      //group 3, bottom row should be 4, 5, 6
      actualPencilMarksForGroupRow = result.GetGroups().First(x => x.Index == 2).GetRowCells(RowPosition.Bottom).GetPencilMarks().ToList();
      expectedPencilMarks = new[] { 4, 5, 6 };
      Assert.That(actualPencilMarksForGroupRow, Is.EquivalentTo(expectedPencilMarks));
    }
  }
}
