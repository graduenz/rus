using Microsoft.AspNetCore.Mvc;

namespace Rus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    private readonly ILogger<HelloController> _logger;

    public HelloController(ILogger<HelloController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string HelloWorld()
    {
        return "Hello World!";
    }
}