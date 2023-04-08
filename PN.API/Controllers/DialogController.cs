using Microsoft.AspNetCore.Mvc;
using PN.API.Requests;
using PN.API.Services;
using PN.Domain.Models;

namespace PN.API.Controllers;

[ApiController]
[Route("api/dialog")]
public class DialogController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<string>> ProcessMessage([FromServices] IDialogService service, DialogRequest request)
    {
        return Ok(await service.GetDialogResponseAsync(request));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Dialog>>> GetDialogHistory([FromServices] IDialogService service)
    {
        return Ok(await service.GetDialogHistory());
    }
}