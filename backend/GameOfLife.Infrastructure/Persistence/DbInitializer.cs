using GameOfLife.Core.Entities;

namespace GameOfLife.Infrastructure.Persistence;

public static class DbInitializer
{

  public static void Initialize(GameDbContext context)
  {
    context.Database.EnsureCreated();

    context.SaveChanges();
  }
}