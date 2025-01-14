

using esercizio_1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace esercizio_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return Ok(authorService.GetById(id));
        }



    }

}