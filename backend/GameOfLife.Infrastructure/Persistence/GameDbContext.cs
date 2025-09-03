using Microsoft.EntityFrameworkCore;
using GameOfLife.Core.Entities;

namespace GameOfLife.Infrastructure.Persistence;

public class GameDbContext : DbContext
{
  public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
  {
  }

  public DbSet<Board> Boards { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Board>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
      entity.Property(e => e.Cells)
            .HasConversion(
                v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions)null),
                v => System.Text.Json.JsonSerializer.Deserialize<List<Cell>>(v, (System.Text.Json.JsonSerializerOptions)null))
            .IsRequired();
      entity.Property(e => e.CreatedAt).IsRequired();
    });

    base.OnModelCreating(modelBuilder);
  }
}
