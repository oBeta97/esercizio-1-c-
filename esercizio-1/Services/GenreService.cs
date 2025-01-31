using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using esercizio_1.Entities.EFCore;
using esercizio_1.Interfaces;
using esercizio_1.Payloads;

namespace esercizio_1.Services
{
    public class GenreService(LibrarydbContext dbContext) : IGenreService
    {
        public bool Delete(int idToDelete)
        {
            throw new NotImplementedException();
        }

        public List<Genre> GetAll()
        {
            return dbContext.Genres.ToList();
        }

        public Genre? GetById(int id)
        {
            // Se il risultato è piu di 1 solleverà un'eccezione. Se non c'è corrispondenza restituisce null!
            return dbContext.Genres.Where(g => g.Id == id).SingleOrDefault();
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