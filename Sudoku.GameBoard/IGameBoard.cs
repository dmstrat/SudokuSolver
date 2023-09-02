﻿namespace Sudoku.GameBoard
{
  public interface IGameBoard
  {
    public event GameBoardHadActivity BoardHadActivity;
    public IEnumerable<GameCell> GetCells();
    public IEnumerable<GameBoardGroup> GetGroups();
    public IEnumerable<GameBoardRow> GetRows();
    public IEnumerable<GameBoardColumn> GetColumns();
    public GameCell GetCellByIndex(int cellIndex);
    public string GetValuesAsString();
    public GameBoardGroup GetGroupBy(GameCell cell);
    public GameBoardRow GetRowBy(GameCell cell);
    public GameBoardColumn GetColumnBy(GameCell cell);
    public string BuildZeroBasedString();
  }
}
