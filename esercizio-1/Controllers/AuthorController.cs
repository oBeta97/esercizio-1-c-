using esercizio_1.Entities;
using esercizio_1.Interfaces;
using esercizio_1.Payloads;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace esercizio_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Endpoint gestiti con ADO.NET")]
    public class AuthorController(IAuthorService authorService) : ControllerBase
    {
        [HttpGet("all")]
        [SwaggerOperation(
            Summary = "Recupera tutti gli autori",
            Description = "Restituisce una lista e non una Page di autori"
        )]
        public IActionResult GetAll()
        {
            return Ok(authorService.GetAll());
        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Crea una classe Page degli autori",
            Description = "Restituisce la paginazione di autori"
        )]
        public IActionResult GetPage(
                [FromQuery] int pageIndex = 0,
                [FromQuery] string orderBy = "",
                [FromQuery] bool ascending = false
            )
        {
            if (pageIndex >= 0)
            {
                return Ok(authorService.GetPage(pageIndex, orderBy, ascending));
            }

            return BadRequest();
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Author? author = authorService.GetById(id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpGet("{id:int}/books")]
        public IActionResult GetBooks(int id)
        {
            Author? author = authorService.GetById(id);

            if (author == null)
                return NotFound();

            return Ok(authorService.GetAuthorBooks(author.Id));
        }

        [HttpPost]
        public IActionResult Insert([FromBody] AuthorDTO author)
        {

            if (authorService.Insert(author))
                return Created();

            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] AuthorDTO authorDTO)
        {

            Author? author = authorService.GetById(id);

            if (author != null && authorService.Update(id, authorDTO))
            {
                Author? updatedAuthor = authorService.GetById(id);
                return Ok(updatedAuthor);
            }

            return NotFound();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Author? author = authorService.GetById(id);

            if (author != null && authorService.Delete(id))
                return NoContent();

            return NotFound();
        }

    }

}