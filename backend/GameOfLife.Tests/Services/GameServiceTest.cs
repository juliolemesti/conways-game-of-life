using GameOfLife.Application.Services;
using GameOfLife.Core.Entities;
using Moq;
using Microsoft.Extensions.Logging;
using GameOfLife.Tests.Utils;

namespace GameOfLife.Tests.Services;

public class GameServiceTest
{

  private const int BOARD_SIZE = 13; //Always an odd number
  private const int CENTER_POS = (BOARD_SIZE - 1) / 2;
  private readonly Board _testBoard;
  private readonly GameService _gameService;

  public GameServiceTest()
  {
    var crossPattern = TestData.CrossPattern(CENTER_POS);
    _testBoard = new Board
    {
      Id = Guid.NewGuid(),
      Name = "Test Board",
      BoardSize = BOARD_SIZE,
      Grid = TestUtils.CreateTestGrid(BOARD_SIZE, crossPattern)
    };

    var loggerFactory = LoggerFactory.Create(builder =>
      builder.AddConsole().SetMinimumLevel(LogLevel.Trace));
    var logger = loggerFactory.CreateLogger<GameService>();
    _gameService = new GameService(logger);
  }

  [Fact]
  public void TestGetNextGeneration()
  {
    var result = _gameService.GetNextGeneration(_testBoard);

    var crossPatternSecondGeneration = TestData.SquarePattern(CENTER_POS);
    var crossPatternSecondGenerationGrid = TestUtils.CreateTestGrid(BOARD_SIZE, crossPatternSecondGeneration);
    Assert.Equal(result.Grid, crossPatternSecondGenerationGrid);

    result = _gameService.GetNextGeneration(result);
    var DiamondPattern = TestData.DiamondPattern(CENTER_POS);
    var DiamondPatternGrid = TestUtils.CreateTestGrid(BOARD_SIZE, DiamondPattern);
    Assert.Equal(result.Grid, DiamondPatternGrid);

    result = _gameService.GetNextGeneration(result);
    var hollowDiamondPattern = TestData.HollowDiamondPattern(CENTER_POS);
    var hollowDiamondGrid = TestUtils.CreateTestGrid(BOARD_SIZE, hollowDiamondPattern);
    Assert.Equal(result.Grid, hollowDiamondGrid);
  }

  [Fact]
  public void TestGet2NextGenerations()
  {
    var result = _gameService.GetXNextGenerations(_testBoard, 2);
    var DiamondPattern = TestData.DiamondPattern(CENTER_POS);
    var DiamondPatternGrid = TestUtils.CreateTestGrid(BOARD_SIZE, DiamondPattern);
    Assert.Equal(result.Grid, DiamondPatternGrid);
  }

  [Fact]
  public void TestGet3NextGenerations()
  {
    var result = _gameService.GetXNextGenerations(_testBoard, 3);
    var hollowDiamondPattern = TestData.HollowDiamondPattern(CENTER_POS);
    var hollowDiamondGrid = TestUtils.CreateTestGrid(BOARD_SIZE, hollowDiamondPattern);
    Assert.Equal(result.Grid, hollowDiamondGrid);
  }

  [Fact]
  public void TestGetFinalBoardState()
  {
  }

}

public class CountAliveNeighborsTest
{

  private const int BOARD_SIZE = 13; //Always an odd number
  private const int CENTER_POS = (BOARD_SIZE - 1) / 2;
  private readonly bool[][] _testGrid;

  private readonly GameService _gameService;

  public CountAliveNeighborsTest()
  {
    var crossPattern = TestData.CrossPattern(CENTER_POS);
    _testGrid = TestUtils.CreateTestGrid(BOARD_SIZE, crossPattern);

    var loggerFactory = LoggerFactory.Create(builder =>
      builder.AddConsole().SetMinimumLevel(LogLevel.Trace));
    var logger = loggerFactory.CreateLogger<GameService>();
    _gameService = new GameService(logger);
  }

  [Fact]
  public void CountAliveNeighbors_Returns4_ForCenterCell()
  {
    var result = _gameService.CountAliveNeighbors(_testGrid, CENTER_POS, CENTER_POS);
    Assert.Equal(4, result);
  }

  [Fact]
  public void CountAliveNeighbors_Returns5_ForCellRightOfCenter()
  {
    var result = _gameService.CountAliveNeighbors(_testGrid, CENTER_POS, CENTER_POS + 1);
    Assert.Equal(3, result);
  }

  [Fact]
  public void CountAliveNeighbors_Returns5_ForCellBelowCenter()
  {
    var result = _gameService.CountAliveNeighbors(_testGrid, CENTER_POS + 1, CENTER_POS);
    Assert.Equal(3, result);
  }

  [Fact]
  public void CountAliveNeighbors_Returns6_ForCellDiagonalBelowRightOfCenter()
  {
    var result = _gameService.CountAliveNeighbors(_testGrid, CENTER_POS + 1, CENTER_POS + 1);
    Assert.Equal(3, result);
  }

  [Fact]
  public void CountAliveNeighbors_Returns3_ForCellDiagonalBelowLeftOfCenter()
  {
    var result = _gameService.CountAliveNeighbors(_testGrid, CENTER_POS + 1, CENTER_POS - 1);
    Assert.Equal(3, result);
  }

  [Fact]
  public void CountAliveNeighbors_Returns3_ForCellAboveCenter()
  {
    var result = _gameService.CountAliveNeighbors(_testGrid, CENTER_POS - 1, CENTER_POS);
    Assert.Equal(3, result);
  }

  [Fact]
  public void CountAliveNeighbors_Returns4_ForCellDiagonalAboveRightOfCenter()
  {
    var result = _gameService.CountAliveNeighbors(_testGrid, CENTER_POS - 1, CENTER_POS + 1);
    Assert.Equal(3, result);
  }

  [Fact]
  public void CountAliveNeighbors_Returns2_ForCellDiagonalAboveLeftOfCenter()
  {
    var result = _gameService.CountAliveNeighbors(_testGrid, CENTER_POS - 1, CENTER_POS - 1);
    Assert.Equal(3, result);
  }

  [Fact]
  public void CountAliveNeighbors_Returns3_ForCellLeftOfCenter()
  {
    var result = _gameService.CountAliveNeighbors(_testGrid, CENTER_POS, CENTER_POS - 1);
    Assert.Equal(3, result);
  }

  [Fact]
  public void CountAliveNeighbors_Returns3_ForCellLeftOfCenter2()
  {
    var result = _gameService.CountAliveNeighbors(_testGrid, CENTER_POS, CENTER_POS - 2);
    Assert.Equal(1, result);
  }

  [Fact]
  public void CountAliveNeighbors_Returns3_ForCellLeftOfCenter3()
  {
    var result = _gameService.CountAliveNeighbors(_testGrid, CENTER_POS, CENTER_POS - 3);
    Assert.Equal(0, result);
  }

}