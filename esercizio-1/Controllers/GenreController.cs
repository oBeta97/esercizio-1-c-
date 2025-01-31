using esercizio_1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace esercizio_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // In questo caso andiamo a decidere che gli endpoint di Genre devono utilizzare il caching
    // Se domani andiamo a creare degli endpoint amministrativi che non devono avere alcun caching basterà "legarsi" a IGenreService e non al cachedService
    public class GenreController(ICachedGenreService genreService) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(genreService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(genreService.GetById(id));
        }


    }
}