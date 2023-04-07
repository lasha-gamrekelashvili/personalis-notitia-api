using Microsoft.AspNetCore.Mvc;
using personalis_notitia_api.Requests;

namespace personalis_notitia_api.Controllers;

[ApiController]
[Route("api/dialog")]
public class DialogController: ControllerBase
{
    [HttpPost]
    public string ProcessMessage(DialogRequest dto)
    {
        return $"you said: {dto.Message}";
    }
}