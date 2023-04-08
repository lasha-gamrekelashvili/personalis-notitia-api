using Microsoft.AspNetCore.Mvc;

namespace PN.API.Controllers;

[ApiController]
[Route("/")]
public class HealthcheckController : ControllerBase
{
    [HttpGet]
    public string Healthcheck()
    {
        return "Hello World!";
    }
}