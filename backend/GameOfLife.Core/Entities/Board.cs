namespace GameOfLife.Core.Entities;

public class Board
{
  public Guid Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public List<Cell> Cells { get; set; } = new List<Cell>();
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
