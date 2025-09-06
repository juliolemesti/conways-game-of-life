namespace GameOfLife.Tests.Utils;

public static class TestUtils
{
  public static bool[][] CreateTestGrid(int boardSize, int[,] alivePositions)
  {
    bool[][] grid = new bool[boardSize][];
    for (int i = 0; i < boardSize; i++)
    {
      grid[i] = new bool[boardSize];
    }

    for (int i = 0; i < alivePositions.GetLength(0); i++)
    {
      Console.WriteLine($"Alive position {i}: ({alivePositions[i, 0]}, {alivePositions[i, 1]})");
    }

    for (int i = 0; i < alivePositions.GetLength(0); i++)
    {
      int row = alivePositions[i, 0];
      int col = alivePositions[i, 1];
      grid[row][col] = true;
    }

    return grid;
  }
}

public static class TestData
{
  public static int[,] CrossPattern(int centerPos) => new int[,]
  {
    { centerPos - 1, centerPos },
    { centerPos, centerPos - 1 },
    { centerPos, centerPos },
    { centerPos, centerPos + 1 },
    { centerPos + 1, centerPos }
  };

  public static int[,] CrossPatternSecondGeneration(int centerPos) => new int[,]
  {
    { centerPos - 1, centerPos - 1 },
    { centerPos - 1, centerPos },
    { centerPos - 1, centerPos + 1 },
    { centerPos, centerPos - 1 },
    { centerPos, centerPos + 1 },
    { centerPos + 1, centerPos - 1 },
    { centerPos + 1, centerPos },
    { centerPos + 1, centerPos + 1 }
  };

  public static int[,] GliderPattern(int centerPos) => new int[,]
  {
    { centerPos - 1, centerPos },
    { centerPos, centerPos + 1 },
    { centerPos + 1, centerPos - 1 }, { centerPos + 1, centerPos }, { centerPos + 1, centerPos + 1 }
  };

  public static int[,] BlinkerPattern(int centerPos) => new int[,]
  {
    { centerPos, centerPos - 1 }, { centerPos, centerPos }, { centerPos, centerPos + 1 }
  };
}