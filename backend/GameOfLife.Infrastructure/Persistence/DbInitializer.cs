using GameOfLife.Core.Entities;

namespace GameOfLife.Infrastructure.Persistence;

public static class DbInitializer
{

  public static void Initialize(GameDbContext context)
  {
    context.Database.EnsureCreated();

    if (context.Boards.Any()) { return; }

    // Create an 8x8 board with random cells
    var cells = new List<Cell>();
    for (int x = 0; x < 8; x++)
    {
      for (int y = 0; y < 8; y++)
      {
        bool isAlive = new Random().Next(2) == 0;

        cells.Add(new Cell { Row = x, Column = y, IsAlive = isAlive });
      }
    }

    var defaultBoards = new[]
    {
      new Board { Id = Guid.NewGuid(), Name = "Default 8x8 Board", Cells = cells }
    };

    context.Boards.AddRange(defaultBoards);
    context.SaveChanges();
  }
}