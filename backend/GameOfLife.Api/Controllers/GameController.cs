using Microsoft.AspNetCore.Mvc;

namespace GameOfLife.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{

  public GameController()
  {

  }

  [HttpGet]
  public string GetGameState()
  {
    Console.WriteLine("GetGameState endpoint called at " + DateTime.Now);
    return "Game is running";
  }

}