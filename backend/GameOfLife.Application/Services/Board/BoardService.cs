using GameOfLife.Core.Entities;
using GameOfLife.Application.DTO;
using GameOfLife.Core.Interfaces;
using GameOfLife.Application.Extensions;

namespace GameOfLife.Application.Services;


public class BoardService : IBoardService
{
  private readonly IBoardRepository _boardRepository;

  public BoardService(IBoardRepository boardRepository)
  {
    _boardRepository = boardRepository;
  }

  public async Task<BoardDto?> GetBoardByIdAsync(Guid id)
  {
    var board = await _boardRepository.GetBoardByIdAsync(id);
    return board.ToDto();
  }

  public async Task<List<BoardDto>> GetAllBoardsAsync()
  {
    var boards = await _boardRepository.GetAllBoardsAsync();
    return boards.Select(b => b.ToDto()).ToList();
  }

  public async Task<BoardDto> CreateBoardAsync(BoardDto input)
  {
    var board = new Board
    {
      Id = Guid.NewGuid(),
      Name = input.Name,
      Cells = input.Cells.Select(c => new Cell
      {
        Row = c.Row,
        Column = c.Column,
        IsAlive = c.IsAlive
      }).ToList()
    };

    await _boardRepository.CreateBoardAsync(board);

    return board.ToDto();
  }

  public async Task<bool> UpdateBoardAsync(BoardDto board)
  {
    var existingBoard = await _boardRepository.GetBoardByIdAsync(board.Id);
    if (existingBoard == null) return false;

    existingBoard.Name = board.Name;
    existingBoard.Cells = board.Cells.Select(c => new Cell
    {
      Row = c.Row,
      Column = c.Column,
      IsAlive = c.IsAlive
    }).ToList();

    return await _boardRepository.UpdateBoardAsync(existingBoard);
  }

  public async Task<bool> DeleteBoardAsync(Guid id)
  {
    return await _boardRepository.DeleteBoardAsync(id);
  }

}