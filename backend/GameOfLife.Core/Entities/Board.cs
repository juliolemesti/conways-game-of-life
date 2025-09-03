namespace GameOfLife.Core.Entities;

public class Board
{
  public int Id { get; set; }
  public string Name { get; set; }
  public List<Cell> Cells { get; set; }
  public DateTime CreatedAt { get; set; }
}
