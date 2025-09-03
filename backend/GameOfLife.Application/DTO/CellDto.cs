namespace GameOfLife.Application.DTO;

public class CellDto
{
  public int Row { get; set; }
  public int Column { get; set; }
  public Guid BoardId { get; set; }
  public bool IsAlive { get; set; } = false;
}