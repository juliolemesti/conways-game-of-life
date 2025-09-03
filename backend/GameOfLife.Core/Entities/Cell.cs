namespace GameOfLife.Core.Entities;

public class Cell
{
  public int Row { get; set; }
  public int Column { get; set; }
  public Guid BoardId { get; set; }
  public bool IsAlive { get; set; } = false;
}