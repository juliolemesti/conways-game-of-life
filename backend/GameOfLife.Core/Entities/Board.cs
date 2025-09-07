using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace GameOfLife.Core.Entities;

public class Board
{
  public Guid Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public int BoardSize { get; set; } = 13;
  public int Generation { get; set; } = 1;
  public BoardConvergenceState ConvergenceState { get; set; } = BoardConvergenceState.None;
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
    if (grid == null || grid.Length != BoardSize || grid[0].Length != BoardSize)
    {
      throw new Exception($"Grid dimensions do not match board dimensions {Id}#{Name}");
    }

    BoardState = JsonSerializer.Serialize(grid);
    ConvergenceState = IsEmptyState == true ? BoardConvergenceState.Empty : BoardConvergenceState.None;
  }

  public bool? IsEmptyState { get => Grid?.All(row => row.All(cell => !cell)); }

}

public enum BoardConvergenceState
{
  None = 0,           // Not converged, still evolving and not at max limit
  Empty = 1,          // Board has reached an empty state (all cells dead)
  StillLife = 2,      // Board has reached a stable, unchanging state
  Oscillator = 3,     // Board is oscillating between states
  MaxGeneration = 4   // Board reached the maximum generation limit without converging
};
