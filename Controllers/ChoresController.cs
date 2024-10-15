using chorescore_api.Models;
using chorescore_api.Services;

namespace chorescore_api.Controllers;

[ApiController]
[Route("api/chores")]
public class ChoresController : ControllerBase
{
  public ChoresController(ChoresService choresService)
  {
    _choresService = choresService;
  }
  private readonly ChoresService _choresService;

  [HttpGet("test")]
  public string TestGet()
  {
    return "API is working";
  }

  [HttpGet]
  public ActionResult<List<Chore>> GetChores()
  {
    try
    {
      List<Chore> chores = _choresService.GetChores();
      return Ok(chores);
    }
    catch (System.Exception error)
    {
      return BadRequest(error.Message);
    }
  }
  [HttpGet("{choreId}")]
  public ActionResult<Chore> getChoreById(int choreId)
  {
    try
    {
      Chore chore = _choresService.getChoreById(choreId);
      return Ok(chore);
    }
    catch (System.Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpPost]
  public ActionResult<Chore> createChore([FromBody] Chore choreData)
  {
    try
    {
      Chore chore = _choresService.createChore(choreData);
      return Ok(chore);
    }
    catch (System.Exception error)
    {
      return BadRequest(error.Message);
    }
  }
  [HttpDelete("{choreId}")]

  public ActionResult<string> deleteChore(int choreId)
  {
    try
    {
      string message = _choresService.deleteChore(choreId);
      return Ok(message);
    }
    catch (System.Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}
