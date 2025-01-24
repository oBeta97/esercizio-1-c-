

using esercizio_1.Entities.EFCore;
using esercizio_1.Interfaces;
using esercizio_1.Payloads;

namespace esercizio_1.Services
{
    // non è stato utilizzata la dependency injection per evitare complicazioni e rendere più snello il codice
    public class BooksService(LibrarydbContext _dbContext) : IBookService
    {

        private readonly LibrarydbContext dbContext = _dbContext;

        public bool Delete(int idToDelete)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            return dbContext.Books.ToList();
        }

        public Book? GetById(int id)
        {
            // Se il risultato è piu di 1 solleverà un'eccezione. Se non c'è corrispondenza restituisce null!
            return dbContext.Books.Where(book => book.Id == id).SingleOrDefault();
        }

        public bool Insert(BookDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Update(int idToUpdate, BookDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}