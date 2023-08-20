﻿namespace Sudoku.GameBoard
{
  public interface IGameBoard
  {
    public IEnumerable<GameCell> GetCells();
    public IEnumerable<GameBoardGroup> GetGroups();
    public IEnumerable<GameBoardRow> GetRows();
    public IEnumerable<GameBoardColumn> GetColumns();
    public GameCell GetCellByIndex(int cellIndex);
  }
}