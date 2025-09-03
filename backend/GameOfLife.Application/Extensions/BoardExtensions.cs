using GameOfLife.Core.Entities;
using GameOfLife.Application.DTO;

namespace GameOfLife.Application.Extensions;

public static class BoardExtensions
{
  public static BoardDto ToDto(this Board board)
  {
    return new BoardDto
    {
      Id = board.Id,
      Name = board.Name,
      Cells = board.Cells.Select(c => c.ToDto()).ToList()
    };
  }

  public static CellDto ToDto(this Cell cell)
  {
    return new CellDto
    {
      Row = cell.Row,
      Column = cell.Column,
      IsAlive = cell.IsAlive
    };
  }
}