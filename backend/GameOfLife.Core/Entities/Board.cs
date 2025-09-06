using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace GameOfLife.Core.Entities;

public class Board
{
  public Guid Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public int Width { get; set; } = 8;
  public int Height { get; set; } = 8;
  public string BoardState { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  [NotMapped]
  public bool[][]? Grid { get => GetGrid(); set => SetGrid(value); }

  public bool[][]? GetGrid()
  {
    if (string.IsNullOrEmpty(BoardState)) return null;

    try
    {
      return JsonSerializer.Deserialize<bool[][]>(BoardState) ?? null;
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error deserializing board state {Id}#{Name}: {ex.Message} \n {BoardState}");
      return null;
    }
  }

  public void SetGrid(bool[][]? grid)
  {
    if (grid == null || grid.Length != Width || grid[0].Length != Height)
    {
      throw new Exception($"Grid dimensions do not match board dimensions {Id}#{Name}");
    }

    BoardState = JsonSerializer.Serialize(grid);
  }

}
