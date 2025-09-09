using GameOfLife.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using GameOfLife.Application.Services;

namespace GameOfLife.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoardController : ControllerBase
{
  private readonly IBoardService _boardService;

  public BoardController(IBoardService boardService)
  {
    _boardService = boardService;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<BoardDto>> GetGameState(int id)
  {
    var board = await _boardService.GetBoardByIdAsync(id);
    return Ok(board);
  }

  [HttpGet]
  public async Task<ActionResult<List<BoardDto>>> GetAllBoards()
  {
    var boards = await _boardService.GetAllBoardsAsync();
    return Ok(boards);
  }

  [HttpPost]
  public async Task<ActionResult<BoardDto>> CreateBoard(BoardDto board)
  {
    var createdBoard = await _boardService.CreateBoardAsync(board);
    return CreatedAtAction(nameof(GetGameState), new { id = createdBoard.Id }, createdBoard);
  }

  [HttpPost("{id}")]
  public async Task<IActionResult> UpdateBoard(int id, BoardDto board)
  {
    if (id != board.Id)
    {
      return BadRequest();
    }

    var updatedBoard = await _boardService.UpdateBoardAsync(board);
    return Ok(updatedBoard);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteBoard(int id)
  {
    await _boardService.DeleteBoardAsync(id);
    return NoContent();
  }
}