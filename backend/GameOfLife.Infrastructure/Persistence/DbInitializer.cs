using System.Text.Json;
using GameOfLife.Core.Entities;

namespace GameOfLife.Infrastructure.Persistence;

public static class DbInitializer
{

  private static int DEFAULT_BOARD_SIZE = 13;

  public static void Initialize(GameDbContext context)
  {
    context.Database.EnsureCreated();

    if (context.Boards.Any()) { return; }

    // Create an 8x8 board with random isAlive
    var grid = new bool[DEFAULT_BOARD_SIZE][];
    for (int x = 0; x < DEFAULT_BOARD_SIZE; x++)
    {
      grid[x] = new bool[DEFAULT_BOARD_SIZE];
      for (int y = 0; y < DEFAULT_BOARD_SIZE; y++)
      {
        bool isAlive = new Random().Next(2) == 0;
        grid[x][y] = isAlive;
      }
    }

    var defaultBoards = new[]
    {
      new Board { Id = Guid.NewGuid(), Name = "Default 8x8 Board", BoardSize = DEFAULT_BOARD_SIZE, Grid = grid }
    };

    context.Boards.AddRange(defaultBoards);
    context.SaveChanges();
  }
}