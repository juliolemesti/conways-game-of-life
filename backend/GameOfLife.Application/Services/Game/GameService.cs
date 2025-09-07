using System.Diagnostics;
using DeepEqual.Syntax;
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
    if (grid == null || currentBoard.IsEmptyState == true)
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

    var board = new Board
    {
      Id = currentBoard.Id,
      Name = currentBoard.Name,
      BoardSize = currentBoard.BoardSize,
      Grid = newGrid,
      Generation = currentBoard.Generation + 1
    };

    // Detect still life
    if (board.Grid.IsDeepEqual(currentBoard.Grid))
    {
      board.ConvergenceState = BoardConvergenceState.StillLife;
    }

    return board;
  }

  public Board GetXNextGenerations(Board currentBoard, int x)
  {
    var grid = currentBoard.Grid;
    if (grid == null)
    {
      _logger.LogWarning("Board {BoardName} has null grid", currentBoard.Name);
      return currentBoard;
    }

    return GetFinalGeneration(currentBoard, x + 1);
  }

  /**
  * Get the final generation of a board
  * @param currentBoard - The current board
  * @param maxGenerations - The maximum number of generations to generate
  * @return The final generation of the board
  */
  public Board GetFinalGeneration(Board currentBoard, int maxGenerations = 1000)
  {
    if (currentBoard.Grid == null)
    {
      _logger.LogWarning("Board {BoardName} has null grid", currentBoard.Name);
      return currentBoard;
    }

    var stopwatch = Stopwatch.StartNew();

    // Keep track of the last two generations to detect stability
    var lastGenerationsQueue = new Queue<bool[][]>();
    lastGenerationsQueue.Enqueue(currentBoard.Grid);
    var maxCycleDetection = 30;

    do
    {
      var nextGeneration = GetNextGeneration(currentBoard);
      if (nextGeneration.Grid == null)
      {
        _logger.LogWarning("Next generation has null grid");
        break;
      }

      // Detect empty state
      if (nextGeneration.ConvergenceState == BoardConvergenceState.Empty)
      {
        _logger.LogInformation("Board {BoardName} has reached {State} after {Generations} generations", currentBoard.Name, nextGeneration.ConvergenceState, nextGeneration.Generation);
        currentBoard = nextGeneration;
        break;
      }

      // Detect still life
      if (nextGeneration.ConvergenceState == BoardConvergenceState.StillLife)
      {
        currentBoard.ConvergenceState = nextGeneration.ConvergenceState;
        _logger.LogInformation("Board {BoardName} has reached {State} state after {Generations} generations", currentBoard.Name, currentBoard.ConvergenceState, currentBoard.Generation);
        break;
      }

      // Check for oscillators up to the last 30 generations
      if (lastGenerationsQueue.Count == 2)
      {
        foreach (var previousGrid in lastGenerationsQueue)
        {
          if (nextGeneration.Grid.IsDeepEqual(previousGrid))
          {
            _logger.LogInformation("Board {BoardName} reached oscillating state after {Generations} generations", currentBoard.Name, nextGeneration.Generation);

            currentBoard = nextGeneration;
            break;
          }
        }
      }

      // Maintain queue size
      lastGenerationsQueue.Enqueue(nextGeneration.Grid);
      if (lastGenerationsQueue.Count > maxCycleDetection)
      {
        lastGenerationsQueue.Dequeue();
      }

      currentBoard = nextGeneration;

    } while (currentBoard.Generation < maxGenerations);

    if (currentBoard.ConvergenceState == BoardConvergenceState.None && currentBoard.Generation >= maxGenerations)
    {
      currentBoard.ConvergenceState = BoardConvergenceState.MaxGeneration;
    }

    stopwatch.Stop();
    _logger.LogInformation("GetFinalGeneration completed in {ElapsedMs}ms | Board: {Board} | Generations: {Generations} | State: {State}",
      stopwatch.ElapsedMilliseconds, currentBoard.Name, currentBoard.Generation, currentBoard.ConvergenceState);

    return currentBoard;
  }

  public int CountAliveNeighbors(bool[][] grid, int row, int col)
  {
    if (grid == null)
    {
      _logger.LogWarning("Grid is null");
      return 0;
    }

    // Generate a 2D array of all neighbor positions for a given cell (row, col)
    int[,] neighborOffsets = new int[,]
    {
      {-1, -1}, {-1, 0}, {-1, 1},
      { 0, -1},          { 0, 1},
      { 1, -1}, { 1, 0}, { 1, 1}
    };

    int aliveNeighbors = 0;
    for (int i = 0; i < neighborOffsets.GetLength(0); i++)
    {
      int newRow = row + neighborOffsets[i, 0];
      int newCol = col + neighborOffsets[i, 1];

      if (newRow >= 0 && newRow < grid.Length && newCol >= 0 && newCol < grid[0].Length && grid[newRow][newCol])
      {
        aliveNeighbors++;
      }
    }

    return aliveNeighbors;
  }

}