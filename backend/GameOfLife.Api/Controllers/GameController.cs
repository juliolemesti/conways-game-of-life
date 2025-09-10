using GameOfLife.Application.DTO;
using GameOfLife.Application.Extensions;
using GameOfLife.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameOfLife.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{

  private readonly IGameService _gameService;

  public GameController(IGameService gameService)
  {
    _gameService = gameService;
  }

  [HttpPost("NextGeneration")]
  public ActionResult<BoardDto> NextGeneration(BoardDto board)
  {
    var boardEntity = _gameService.GetNextGeneration(board.ToEntity());
    return Ok(boardEntity.ToDto());
  }

  [HttpGet("GetXNextGenerations")]
  public ActionResult<BoardDto> GetXNextGenerations(BoardDto board, int x)
  {
    var boardEntity = _gameService.GetXNextGenerations(board.ToEntity(), x);
    return Ok(boardEntity.ToDto());
  }

  [HttpGet("GetFinalGeneration")]
  public ActionResult<BoardDto> GetFinalGeneration(BoardDto board, int maxGenerations)
  {
    var boardEntity = _gameService.GetFinalGeneration(board.ToEntity(), maxGenerations);
    return Ok(boardEntity.ToDto());
  }

}