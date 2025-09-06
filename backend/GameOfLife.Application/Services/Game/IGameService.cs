using GameOfLife.Core.Entities;
using GameOfLife.Application.DTO;
using GameOfLife.Core.Interfaces;
using GameOfLife.Application.Extensions;

namespace GameOfLife.Application.Services;

public interface IGameService
{
  public Board GetNextGeneration(Board currentBoard);
  public int? CountAliveNeighbors(bool[][] grid, int row, int col);
}