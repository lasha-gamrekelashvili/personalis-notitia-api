using Microsoft.AspNetCore.Mvc;

namespace personalis_notitia_api.Controllers;

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