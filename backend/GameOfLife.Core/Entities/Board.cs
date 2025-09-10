using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace GameOfLife.Core.Entities;

public class Board
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public int BoardSize { get; set; } = 13;
  public int Generation { get; set; } = 1;
  public BoardConvergenceState ConvergenceState { get; set; } = BoardConvergenceState.None;
  public string InitialState { get; set; } = string.Empty;
  public string State { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  [NotMapped]
  public bool[][]? InitialGrid
  {
    get => GetGridFromState(InitialState); 
    set
    {
      if (value == null || value.Length != BoardSize || value[0].Length != BoardSize)
      {
        throw new Exception($"Grid dimensions do not match board dimensions {Id}#{Name}");
      }
      InitialState = JsonSerializer.Serialize(value);
      if (State == string.Empty) State = InitialState;
    }
  }

  [NotMapped]
  public bool[][]? Grid
  {
    get => GetGridFromState(State); 
    set
    {
      if (value == null || value.Length != BoardSize || value[0].Length != BoardSize)
      {
        throw new Exception($"Grid dimensions do not match board dimensions {Id}#{Name}");
      }
      State = JsonSerializer.Serialize(value);
      ConvergenceState = IsEmptyState == true ? BoardConvergenceState.Empty : BoardConvergenceState.None;
      if (InitialState == string.Empty) InitialState = State;
    }
  }

  private bool[][]? GetGridFromState(string state)
  {
    if (string.IsNullOrEmpty(state)) return null;

    try
    {
      return JsonSerializer.Deserialize<bool[][]>(state) ?? null;
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error deserializing board state {Id}#{Name}: {ex.Message} \n {state}");
      return null;
    }
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
