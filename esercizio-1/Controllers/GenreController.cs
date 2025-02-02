using esercizio_1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace esercizio_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Endpoint gestiti con il sistema di caching")]
    // In questo caso andiamo a decidere che gli endpoint di Genre devono utilizzare il caching
    // Se domani andiamo a creare degli endpoint amministrativi che non devono avere alcun caching basterà "legarsi" a IGenreService e non al cachedService
    public class GenreController(ICachedGenreService genreService) : ControllerBase
    {

        [HttpGet]
        [SwaggerOperation(
            Summary = "Recupera tutti i generi - IMemoryCache",
            Description = "Utilizzo di IMemoryCache"
        )]
        public IActionResult GetAll()
        {
            return Ok(genreService.GetAll());
        }

        [HttpGet("{id:int}")]
        // METODO "CLASSICO":
        // Applicazione della Response cache (duration in secondi):
        // diciamo al server di rispondere con un "Cache-control: <location>, max-age = <duration>" negli headers
        //  Client -> Solo il browser salverà in cache la risposta
        //  Public -> tutti i nodi che riceveranno la risposta (e hanno un caching) salveranno la risposta
        // [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Client)]
        // NB! il valore di default di "Location" è public!
        // [ResponseCache(Duration = 120)]
        // METODO PROFILI:
        [ResponseCache(CacheProfileName = "Default")]
        [SwaggerOperation(
            Summary = "Recupera un genere per ID - ResponseCache",
            Description = "Utilizzo della ResponseCache"
        )]
        public IActionResult GetById(int id)
        {
            return Ok(genreService.GetById(id));
        }


    }
}