﻿using System.Diagnostics;
using Sudoku.Engine.Exceptions;
using Sudoku.Engine.Solvers;
using Sudoku.GameBoard;

namespace Sudoku.Engine
{
  public class Engine
  {
    private const int _MaxLoopCount = 100;
    private readonly IGameBoard _OriginalGameBoard;
    private IGameBoard _GameBoard;
    private IEnumerable<ISolver> _Solvers;
    private bool _BoardHadActivity;
    private readonly int _BoardInactivityMaxCount = 5;

    public Engine(IGameBoard gameBoard)
    {
      _OriginalGameBoard = GameBoardFactory.Create(gameBoard.GetValuesAsString());
      _GameBoard = (GameBoard.GameBoard)gameBoard;
      _Solvers = CollectDefaultSolversForEngine();
      _BoardHadActivity = false;
      gameBoard.BoardHadActivity += SomethingChanged;
    }

    public void SomethingChanged(IGameBoard gameBoard)
    {
      _BoardHadActivity = true;
      Trace.WriteLine($"CurrentBoard:{_GameBoard.BuildZeroBasedString()}");
    }

    public IGameBoard Solve()
    {
      EnsureGameBoardProvided();
      var notSolved = true;
      var loopCount = 0;
      var pencilMarksGenerator = new PencilMarksGenerator();
      _GameBoard = pencilMarksGenerator.GeneratePencilMarks(_GameBoard);
      var boardHadNoActivityCount = 0;
      while (notSolved && (boardHadNoActivityCount <= _BoardInactivityMaxCount) && loopCount <= _MaxLoopCount)
      {
        foreach (var solver in _Solvers)
        {
          _GameBoard = solver.Solve(_GameBoard);
        }

        LogPencilMarks();
        notSolved = IsGameUnsolved();
        if (_BoardHadActivity)
        {
          boardHadNoActivityCount = 0;
        }
        else
        {
          boardHadNoActivityCount++;
        }
        loopCount++;
        _BoardHadActivity = false;
      }
      return _GameBoard;
    }

    public void RegisterSolvers(IEnumerable<ISolver> solvers)
    {
      _Solvers = solvers;
    }

    private IEnumerable<ISolver> CollectDefaultSolversForEngine()
    {
      var solverList = new List<ISolver>();
      solverList.Add(new SinglePencilMarkLeftSolver());
      solverList.Add(new SinglePencilMarkAcrossGroupColumnRowSolver());
      solverList.Add(new StraightLineRemovesPencilMarksSolver());
      solverList.Add(new Pattern01Solver());
      return solverList;
    }

    private bool IsGameUnsolved()
    {
      var atLeastOneCellNotSolved = _GameBoard.GetCells().Any(x => x.Value is null);
      return atLeastOneCellNotSolved;
    }

    private void EnsureGameBoardProvided()
    {
      var gameBoardNotProvided = !_GameBoard.GetCells().Any();
      if (gameBoardNotProvided)
      {
        throw new NoGameBoardProvided("GameBoard NOT provided");
      }
    }

    private void LogPencilMarks()
    {
      Trace.WriteLine($"Pencil Marks: ");
      Trace.Indent();
      foreach (var cell in _GameBoard.GetCells())
      {
        if (cell.Value is null)
        {
          Trace.WriteLine(
            $"Cell Index: {cell.Index} => Pencil Marks: {string.Join(",", cell.PencilMarks)}"); //add missing numbers as pencil marks to cell 
        }
      }
      Trace.Unindent();
    }
  }
}