using esercizio_1.Entities;
using esercizio_1.Interfaces;
using esercizio_1.Payloads;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace esercizio_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Endpoint gestiti con EF CORE")]

    public class BookController(IBookService authorService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(authorService.GetAll());
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id){
            return Ok(authorService.GetById(id));
        }

    }

}