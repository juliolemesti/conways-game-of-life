namespace GameOfLife.Application.DTO;

public class BoardDto
{
  public Guid Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public List<CellDto> Cells { get; set; } = new List<CellDto>();
}