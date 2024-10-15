using chorescore_api.Services;

namespace sandwich_api.Controllers;

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

}
