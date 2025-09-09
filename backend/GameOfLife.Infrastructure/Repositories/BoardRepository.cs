using Microsoft.EntityFrameworkCore;
using GameOfLife.Core.Interfaces;
using GameOfLife.Infrastructure.Persistence;
using GameOfLife.Core.Entities;

namespace GameOfLife.Infrastructure.Repositories;

public class BoardRepository : IBoardRepository
{
  private readonly GameDbContext _context;

  public BoardRepository(GameDbContext context)
  {
    _context = context;
  }

  public async Task<Board?> GetBoardByIdAsync(int id)
  {
    return await _context.Boards.FirstOrDefaultAsync(b => b.Id == id);
  }

  public async Task<List<Board>> GetAllBoardsAsync()
  {
    return await _context.Boards.ToListAsync();
  }

  public async Task<Board> CreateBoardAsync(Board board)
  {
    _context.Boards.Add(board);
    await _context.SaveChangesAsync();
    return board;
  }

  public async Task<bool> UpdateBoardAsync(Board board)
  {
    var existingBoard = await _context.Boards.FirstOrDefaultAsync(b => b.Id == board.Id);
    if (existingBoard == null) return false;

    existingBoard.Name = board.Name;
    existingBoard.BoardSize = board.BoardSize;
    existingBoard.State = board.State;

    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<bool> DeleteBoardAsync(int id)
  {
    var board = await _context.Boards.FindAsync(id);
    if (board == null) return false;

    _context.Boards.Remove(board);
    await _context.SaveChangesAsync();
    return true;
  }
}