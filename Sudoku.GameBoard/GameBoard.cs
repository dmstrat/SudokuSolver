using System.Text;

namespace Sudoku.GameBoard
{
  public class GameBoard : IGameBoard
  {
    public IList<GameCell> GameCells { get; }

    public GameBoard(IList<GameCell> gameCells)
    {
      GameCells = gameCells;
    }

    public override string ToString()
    {
      var rowSeparator = "----------------------------------------";
      var stringBuilder = new StringBuilder(); 
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, GameCells, 0);
      stringBuilder.AppendLine();
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, GameCells, 0+9);
      stringBuilder.AppendLine();
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, GameCells, 0+9+9);
      stringBuilder.AppendLine();
      stringBuilder.AppendLine(rowSeparator);
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, GameCells, 0+9+9+9);
      stringBuilder.AppendLine();
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, GameCells, 0+9+9+9+9);
      stringBuilder.AppendLine();
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, GameCells, 0+9+9+9+9+9);
      stringBuilder.AppendLine();
      stringBuilder.AppendLine(rowSeparator); 
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, GameCells, 0+9+9+9+9+9+9);
      stringBuilder.AppendLine();
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, GameCells, 0+9+9+9+9+9+9+9);
      stringBuilder.AppendLine();
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      stringBuilder = GenerateRow(stringBuilder, GameCells, 0+9+9+9+9+9+9+9+9);
      stringBuilder.AppendLine();
      stringBuilder.AppendLine(rowSeparator);
      stringBuilder.Append(rowSeparator);
      stringBuilder.AppendLine();
      var newString = stringBuilder.ToString();
      return newString;
    }

    private StringBuilder GenerateRow(StringBuilder stringBuilder, IList<GameCell> gameCells, int startOffset)
    {
      stringBuilder.Append("| ");
      stringBuilder.Append(gameCells[startOffset].Value.ToString());
      stringBuilder.Append(" | ");
      stringBuilder.Append(gameCells[startOffset + 1].Value.ToString());
      stringBuilder.Append(" | ");
      stringBuilder.Append(gameCells[startOffset + 2].Value.ToString());
      stringBuilder.Append(" || ");
      stringBuilder.Append(gameCells[startOffset + 3].Value.ToString());
      stringBuilder.Append(" | ");
      stringBuilder.Append(gameCells[startOffset + 4].Value.ToString());
      stringBuilder.Append(" | ");
      stringBuilder.Append(gameCells[startOffset + 5].Value.ToString());
      stringBuilder.Append(" || ");
      stringBuilder.Append(gameCells[startOffset + 6].Value.ToString());
      stringBuilder.Append(" | ");                       
      stringBuilder.Append(gameCells[startOffset + 7].Value.ToString());
      stringBuilder.Append(" | ");
      stringBuilder.Append(gameCells[startOffset + 8].Value.ToString());
      stringBuilder.Append(" ||");

      return stringBuilder;
    }

    public string GetValuesAsString()
    {
      var newString = GameCells.Select(x => x.Value).Aggregate("", (current, next) => current + (next.HasValue ? next.ToString() : " "));
      return newString;
    }

    public IEnumerable<GameCell> GetBoardCells()
    {
      return GameCells;
    }

    public GameCell GetCellByIndex(int cellIndex)
    {
      return GameCells[cellIndex];
    }
  }
}