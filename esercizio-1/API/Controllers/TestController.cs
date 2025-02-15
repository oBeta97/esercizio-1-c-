using esercizio_1.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TestController(ITestServices testServices) : ControllerBase
{
    public ITestServices TestServices { get; } = testServices;

    [HttpGet]
    public IActionResult Test()
    {
        return Ok(TestServices.Test());
    }

}