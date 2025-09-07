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
      BoardSize = board.BoardSize,
      Grid = board.Grid
    };
  }
}