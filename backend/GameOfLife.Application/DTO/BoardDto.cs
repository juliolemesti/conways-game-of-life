using GameOfLife.Core.Entities;

namespace GameOfLife.Application.DTO;

public class BoardDto
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public int BoardSize { get; set; }
  public int Generation { get; set; } = 1;
  public BoardConvergenceState ConvergenceState { get; set; } = BoardConvergenceState.None;
  public bool[][]? Grid { get; set; }
  public bool[][]? InitialGrid { get; set; }

  public bool? IsEmptyState { get => Grid?.All(row => row.All(cell => !cell)); }
}