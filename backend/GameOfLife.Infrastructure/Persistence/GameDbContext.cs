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
      entity.Property(e => e.CreatedAt).IsRequired();
      entity.HasMany(e => e.Cells).WithOne().HasForeignKey("BoardId").IsRequired();
    });

    modelBuilder.Entity<Cell>(entity =>
    {
      entity.HasKey(e => new { e.Row, e.Column, e.BoardId });
      entity.Property(e => e.IsAlive);
    });

    base.OnModelCreating(modelBuilder);
  }
}
