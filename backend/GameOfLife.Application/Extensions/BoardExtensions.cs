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
      Generation = board.Generation,
      ConvergenceState = board.ConvergenceState,
      InitialGrid = board.InitialGrid,
      Grid = board.Grid
    };
  }

  public static Board ToEntity(this BoardDto boardDto)
  {
    if (boardDto == null)
      throw new ArgumentNullException(nameof(boardDto));

    var board = new Board
    {
      Id = boardDto.Id,
      Name = boardDto.Name,
      BoardSize = boardDto.BoardSize,
      Generation = boardDto.Generation,
      InitialGrid = boardDto.InitialGrid,
      Grid = boardDto.Grid,
      ConvergenceState = boardDto.ConvergenceState
    };

    return board;
  }
}