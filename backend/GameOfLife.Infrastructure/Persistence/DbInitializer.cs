using System.Text.Json;
using GameOfLife.Core.Entities;

namespace GameOfLife.Infrastructure.Persistence;

public static class DbInitializer
{

  public static void Initialize(GameDbContext context)
  {
    context.Database.EnsureCreated();

    if (context.Boards.Any()) { return; }

    // Create an 8x8 board with random isAlive
    var grid = new bool[8][];
    for (int x = 0; x < 8; x++)
    {
      grid[x] = new bool[8];
      for (int y = 0; y < 8; y++)
      {
        bool isAlive = new Random().Next(2) == 0;
        grid[x][y] = isAlive;
      }
    }

    var defaultBoards = new[]
    {
      new Board { Id = Guid.NewGuid(), Name = "Default 8x8 Board", Width = 8, Height = 8, Grid = grid }
    };

    context.Boards.AddRange(defaultBoards);
    context.SaveChanges();
  }
}