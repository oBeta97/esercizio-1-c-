using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using esercizio_1.Entities.EFCore;
using esercizio_1.Interfaces;
using esercizio_1.Payloads;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace esercizio_1.Services
{
    public class CachedGenreService(IMemoryCache cache, IGenreService genreService) : ICachedGenreService
    {
        public bool Delete(int idToDelete)
        {

            // Comando di pulizia della cache di IMemeoryCache
            // cache.Remove($"Genre{idToDelete}");

            throw new NotImplementedException();
        }

        public List<Genre> GetAll()
        {

            // In questo caso dotnet controlla nella cache della macchina se vi è un indice "Genres" salvato e lo restituisce senza fare chiamate al db
            // in caso contrario esegue la lambda trascritta
            return cache.GetOrCreate("Genres", cacheEntry =>
            {

                // Dato che abbiamo impostato un SizeLimit ad ogni salvataggio in cache dobbiamo indicare un peso dell'oggetto salvato
                // Purtroppo non vi è un modo ufficiale per calcolare il "peso" di un oggetto ma va calcolato in modo empirico
                cacheEntry.SetSize(5);

                // Andiamo a definire la scadenza dei dati:

                // SlidingExpiration significa che ad ogni richiesta il timer di 120s viene resettato (potrebbe non essere mai aggiornato questo endpoint)
                // cacheEntry.SetSlidingExpiration(TimeSpan.FromSeconds(120));

                // AbsoluteExpiration significa che dopo X tempo i dati in cache vengono eliminati
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(120));

                // Eseguiamo la chiamata a db ed i dati ritornati vengono salvati in cache con l'indicice indicato sopra
                return genreService.GetAll();

            }) ?? [];
        }

        // La cache in questo caso è gestita dal controller!
        public Genre? GetById(int id)
        {
            return genreService.GetById(id);
        }

        public bool Insert(GenreDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Update(int idToUpdate, GenreDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}