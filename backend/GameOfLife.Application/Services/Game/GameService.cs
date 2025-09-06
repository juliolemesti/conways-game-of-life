using GameOfLife.Core.Entities;
using GameOfLife.Application.DTO;
using GameOfLife.Core.Interfaces;
using GameOfLife.Application.Extensions;

namespace GameOfLife.Application.Services;

public class GameService : IGameService
{

  public Board GetNextGeneration(Board currentBoard)
  {
    return null;
  }

  public int? CountAliveNeighbors(Board board)
  {
    return null;
  }

}