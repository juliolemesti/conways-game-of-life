using GameOfLife.Core.Entities;

namespace GameOfLife.Core.Interfaces;

public interface IBoardRepository
{
  Task<Board?> GetBoardByIdAsync(Guid id);
  Task<List<Board>> GetAllBoardsAsync();
  Task<Board> CreateBoardAsync(Board board);
  Task<bool> UpdateBoardAsync(Board board);
  Task<bool> DeleteBoardAsync(Guid id);
}
