using Microsoft.AspNetCore.Mvc;
using personalis_notitia_api.Models;
using personalis_notitia_api.Requests;
using personalis_notitia_api.Services;

namespace personalis_notitia_api.Controllers;

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