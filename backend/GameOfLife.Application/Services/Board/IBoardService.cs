using GameOfLife.Core.Entities;
using GameOfLife.Application.DTO;

namespace GameOfLife.Application.Services;

public interface IBoardService
{
  Task<BoardDto?> GetBoardByIdAsync(int id);
  Task<List<BoardDto>> GetAllBoardsAsync();
  Task<BoardDto> CreateBoardAsync(BoardDto board);
  Task<bool> UpdateBoardAsync(BoardDto board);
  Task<bool> DeleteBoardAsync(int id);

}