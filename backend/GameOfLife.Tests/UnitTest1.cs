using GameOfLife.Core.Entities;

namespace GameOfLife.Tests;

public class UnitTest1
{
  [Fact]
  public void Test1()
  {
    var board = GetTestBoard();

    

  }

  public static Board GetTestBoard()
  {
    // Create an 8x8 board with random isAlive
    var cells = new List<Cell>();
    for (int x = 0; x < 8; x++)
    {
      for (int y = 0; y < 8; y++)
      {
        bool isAlive = new Random().Next(2) == 0;

        cells.Add(new Cell { Row = x, Column = y, IsAlive = isAlive });
      }
    }

    var board = new Board { Id = Guid.NewGuid(), Name = "Default 8x8 Board", Cells = cells };

    return board;
  }
}