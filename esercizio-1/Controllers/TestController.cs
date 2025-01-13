using esercizio_1.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{

    public TestController(ITestServices testServices)
    {
        TestServices = testServices;
    }

    public ITestServices TestServices { get; }

    [HttpGet]
    public IActionResult Test(){
        return Ok("ciao");
    }

}