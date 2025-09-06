namespace GameOfLife.Application.DTO;

public class BoardDto
{
  private bool[][]? _grid;
  public Guid Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public int Width { get; internal set; } = 8;
  public int Height { get; internal set; } = 8;
  public bool[][]? Grid
  {
    get => _grid; internal set => _grid = value ?? null;
  }
}