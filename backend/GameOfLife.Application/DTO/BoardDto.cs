namespace GameOfLife.Application.DTO;

public class BoardDto
{
  private bool[][]? _grid;
  public Guid Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public int BoardSize { get; internal set; } = 13;
  public bool[][]? Grid
  {
    get => _grid; internal set => _grid = value ?? null;
  }
}