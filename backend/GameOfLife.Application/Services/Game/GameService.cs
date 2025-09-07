using GameOfLife.Core.Entities;
using Microsoft.Extensions.Logging;

namespace GameOfLife.Application.Services;

public class GameService : IGameService
{
  private readonly ILogger<GameService> _logger;

  public GameService(ILogger<GameService> logger)
  {
    _logger = logger;
  }

  public Board GetNextGeneration(Board currentBoard)
  {
    var grid = currentBoard.Grid;
    if (grid == null)
    {
      _logger.LogWarning("Board {BoardId} has null grid", currentBoard.Id);
      return currentBoard;
    }

    var newGrid = new bool[grid.Length][];
    for (int i = 0; i < grid.Length; i++)
    {
      newGrid[i] = new bool[grid[i].Length];
      for (int j = 0; j < grid[i].Length; j++)
      {
        var aliveNeighbors = CountAliveNeighbors(grid, i, j);
        if (grid[i][j])
        {
          newGrid[i][j] = aliveNeighbors == 2 || aliveNeighbors == 3;
        }
        else
        {
          newGrid[i][j] = aliveNeighbors == 3;
        }
      }
    }

    currentBoard.Grid = newGrid;

    return currentBoard;
  }

  public Board GetXNextGenerations(Board currentBoard, int x)
  {
    var grid = currentBoard.Grid;
    if (grid == null)
    {
      _logger.LogWarning("Board {BoardId} has null grid", currentBoard.Id);
      return currentBoard;
    }

    for (int i = 0; i < x; i++)
    {
      currentBoard = GetNextGeneration(currentBoard);
    }

    return currentBoard;
  }


  public int? CountAliveNeighbors(bool[][] grid, int row, int col)
  {
    _logger.LogTrace("Board State: {BoardState}", grid);

    // Generate a 2D array of all neighbor positions for a given cell (row, col)
    int[,] neighborOffsets = new int[,]
    {
      {-1, -1}, {-1, 0}, {-1, 1},
      { 0, -1},          { 0, 1},
      { 1, -1}, { 1, 0}, { 1, 1}
    };

    if (grid == null)
    {
      _logger.LogWarning("Grid is null");
      return null;
    }

    int aliveNeighbors = 0;
    for (int i = 0; i < neighborOffsets.GetLength(0); i++)
    {
      int newRow = row + neighborOffsets[i, 0];
      int newCol = col + neighborOffsets[i, 1];

      _logger.LogTrace("Checking neighbor at offset ({OffsetRow}, {OffsetCol}) -> position ({NewRow}, {NewCol})",
        neighborOffsets[i, 0], neighborOffsets[i, 1], newRow, newCol);

      if (newRow >= 0 && newRow < grid.Length && newCol >= 0 && newCol < grid[0].Length && grid[newRow][newCol])
      {
        aliveNeighbors++;
        _logger.LogTrace("Found alive neighbor at ({NewRow}, {NewCol})", newRow, newCol);
      }
    }

    _logger.LogDebug("Found {AliveNeighbors} alive neighbors for position ({Row}, {Col})",
      aliveNeighbors, row, col);

    return aliveNeighbors;
  }

}