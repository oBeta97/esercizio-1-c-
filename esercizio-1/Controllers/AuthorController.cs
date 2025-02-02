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
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(authorService.GetAll());
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