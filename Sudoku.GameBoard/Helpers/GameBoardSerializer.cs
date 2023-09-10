using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging.Abstractions;

namespace Sudoku.GameBoard.Helpers
{
  public static class GameBoardSerializer
  {
    public static string ToJson(IGameBoard gameBoard)
    {
      var serializedJson = JsonSerializer.Serialize(gameBoard);
      return serializedJson;
    }

    public static IGameBoard FromJson(string jsonGameBoard)
    {
      var gameBoardRaw = JsonSerializer.Deserialize<GameBoard>(jsonGameBoard);
      if (gameBoardRaw != null)
      {
        return (IGameBoard)gameBoardRaw;
      }

      throw new Exception("could not deserialize json");
    }
  }
}
