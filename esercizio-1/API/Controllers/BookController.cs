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

    public class BookController(IBookService bookService) : ControllerBase
    {
        [HttpGet("all")]
        [SwaggerOperation(
            Summary = "Recupera tutti i books",
            Description = "Restituisce una lista e non una Page di books"
        )]
        public IActionResult GetAll()
        {
            return Ok(bookService.GetAll());
        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Crea una classe Page dei books",
            Description = "Restituisce la paginazione di books"
        )]
        public IActionResult GetPage(
                [FromQuery] int pageIndex = 0,
                [FromQuery] string orderBy = "",
                [FromQuery] bool ascending = false
            )
        {
            if (pageIndex < 0)
                return BadRequest("");


            return Ok(bookService.GetPage(pageIndex, orderBy, ascending));
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(bookService.GetById(id));
        }

        [HttpPost]
        public IActionResult Insert([FromBody] BookDTO dto)
        {
            // Dato che il DTO ha le DataAnnotation .net esegue un controllo se le annotazioni sono state rispettate
            if (!ModelState.IsValid)
            {
                return BadRequest("Body object is wrong");
            }

            if (!bookService.Insert(dto)){
                return StatusCode(500, "Internal server error!");
            }

            return Created();

        }

    }

}