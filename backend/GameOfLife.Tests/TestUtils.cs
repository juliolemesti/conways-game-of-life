namespace GameOfLife.Tests.Utils;

public static class TestUtils
{
  public static bool[][] CreateTestGrid(int boardSize, int[,] alivePositions)
  {
    bool[][] grid = new bool[boardSize][];
    for (int i = 0; i < boardSize; i++) { grid[i] = new bool[boardSize]; }

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

  public static int[,] SquarePattern(int centerPos) => new int[,]
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

  public static int[,] DiamondPattern(int centerPos) => new int[,]
  {
    { centerPos - 2, centerPos },
    { centerPos - 1, centerPos - 1 }, { centerPos - 1, centerPos + 1 },
    { centerPos, centerPos - 2 }, { centerPos, centerPos + 2 },
    { centerPos + 1, centerPos - 1 }, { centerPos + 1, centerPos + 1 },
    { centerPos + 2, centerPos }
  };

  public static int[,] HollowDiamondPattern(int centerPos) => new int[,]
  {
    { centerPos - 2, centerPos },
    { centerPos - 1, centerPos - 1 }, { centerPos - 1, centerPos }, { centerPos - 1, centerPos + 1 },
    { centerPos, centerPos - 2 }, { centerPos, centerPos - 1 }, { centerPos, centerPos + 1 }, { centerPos, centerPos + 2 },
    { centerPos + 1, centerPos - 1 }, { centerPos + 1, centerPos }, { centerPos + 1, centerPos + 1 },
    { centerPos + 2, centerPos }
  };

  public static int[,] LineWithLength6Pattern(int centerPos) => new int[,]
  {
    { centerPos, centerPos },
    { centerPos, centerPos + 1},
    { centerPos, centerPos + 2},
    { centerPos, centerPos + 3},
    { centerPos, centerPos + 4},
    { centerPos, centerPos + 5}
  };
  
  public static int[,] LineWithLength6Pattern11thGenerationState(int centerPos) => new int[,]
  {
    { centerPos -1, centerPos - 1}, { centerPos -1, centerPos + 6},
    { centerPos, centerPos - 2}, { centerPos, centerPos + 7},
    { centerPos +1, centerPos - 1}, { centerPos +1, centerPos + 6}
  };

  public static int[,] LineWithLength6PatternFinalState(int centerPos) => new int[,]
  {
    { centerPos, centerPos - 1},
    { centerPos, centerPos - 2},
    { centerPos, centerPos + 6},
    { centerPos, centerPos + 7}
  };

  public static int[,] LineWithLength7Pattern(int centerPos) => new int[,]
  {
    { centerPos - 3, centerPos },
    { centerPos - 2, centerPos },
    { centerPos - 1, centerPos },
    { centerPos, centerPos },
    { centerPos + 1, centerPos },
    { centerPos + 2, centerPos },
    { centerPos + 3, centerPos }
  };

  public static int[,] LineWithLength7PatternFinalState(int centerPos) => new int[,]
    {
    // Top hollow diamond
    { centerPos - 6, centerPos },
    { centerPos - 5, centerPos - 1 }, { centerPos - 5, centerPos + 1 },
    { centerPos - 4, centerPos - 1 }, { centerPos - 4, centerPos + 1 },
    { centerPos - 3, centerPos },

    // Left hollow diamond
    { centerPos - 1, centerPos - 5 }, { centerPos - 1, centerPos - 4 },
    { centerPos, centerPos - 6 }, { centerPos, centerPos - 3 },
    { centerPos + 1, centerPos - 5 }, { centerPos + 1, centerPos - 4 },

    // Right hollow diamond
    { centerPos - 1, centerPos + 5 }, { centerPos - 1, centerPos + 4 },
    { centerPos, centerPos + 6 }, { centerPos, centerPos + 3 },
    { centerPos + 1, centerPos + 5 }, { centerPos + 1, centerPos + 4 },

    // Bottom hollow diamond
    { centerPos + 6, centerPos },
    { centerPos + 5, centerPos - 1 }, { centerPos + 5, centerPos + 1 },
    { centerPos + 4, centerPos - 1 }, { centerPos + 4, centerPos + 1 },
    { centerPos + 3, centerPos },
    };
}