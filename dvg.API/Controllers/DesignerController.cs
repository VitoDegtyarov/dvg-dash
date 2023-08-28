using dvg.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dvg.API.Controllers;

[Route("api/designers")]
[ApiController]
public class DesignerController : ControllerBase
{
    private readonly IDesignerService _designerService;

    public DesignerController(IDesignerService designerService)
    {
        _designerService = designerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDesigners()
    {
        var designers = await _designerService.GetAllAsync();

        return Ok(designers);
    }
}