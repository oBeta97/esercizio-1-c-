

using esercizio_1.Entities.EFCore;
using esercizio_1.Entities.Settings;
using esercizio_1.Entities.Utils;
using esercizio_1.Interfaces;
using esercizio_1.Payloads;
using Microsoft.Extensions.Options;
using Sprache;

namespace esercizio_1.Services
{
    // non è stato utilizzata la dependency injection per evitare complicazioni e rendere più snello il codice
    public class BooksService(LibrarydbContext _dbContext, IOptions<BooksSettings> options) : IBookService
    {

        private readonly LibrarydbContext dbContext = _dbContext;
        private readonly BooksSettings booksSettings = options.Value;


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

        public Page<Book> GetPage(int pageIndex, string orderBy, bool ascending)
        {

            int pageLimit = booksSettings.PerPage;

            if (!booksSettings.Order.Allow.Contains(orderBy))
                orderBy = booksSettings.Order.By;

            IQueryable<Book> query = dbContext.Books;
            
            long totItems = query.Count();

            // ATTENZIONE! In base a come vengono elencati i metodi la query verrà generata in modo diverso!
            // Per la paginazione prima si ordina, poi si saltano N valori (skip) e poi si prendono M valori (take)
            query = query
                .OrderByDynamic(orderBy, ascending)
                .Skip(pageLimit * pageIndex)
                .Take(pageLimit);


            Page<Book> res = new(query.ToList(),totItems, pageLimit, pageIndex);

            return res;
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