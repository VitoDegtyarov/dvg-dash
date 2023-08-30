using dvg.Core.UpdateModels;
using dvg.Dto;
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

    [HttpPost]
    public async Task<IActionResult> AddDesigner(DesignerDto designer)
    {
        await _designerService.InsertAsync(designer);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteDesigner(Guid id)
    {
        try
        {
            await _designerService.DeleteDesignerAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("{id:guid}")]
    public Task<IActionResult> UpdateDesigner(Guid id, DesignerUpdateModel updateModel)
    {
        _designerService.UpdateDesigner(id, updateModel);
        return Task.FromResult<IActionResult>(Ok());
    }
}