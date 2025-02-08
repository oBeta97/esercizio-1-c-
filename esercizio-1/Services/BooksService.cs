using esercizio_1.Entities.EFCore;
using esercizio_1.Entities.Settings;
using esercizio_1.Entities.Utils;
using esercizio_1.Interfaces;
using esercizio_1.Payloads;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sprache;

namespace esercizio_1.Services
{
    // non è stato utilizzata la dependency injection per evitare complicazioni e rendere più snello il codice
    public class BooksService(LibrarydbContext _dbContext, IOptions<BooksSettings> options) : IBookService
    {

        private readonly LibrarydbContext dbContext = _dbContext;
        private readonly BooksSettings booksSettings = options.Value;

        public bool ModelState { get; private set; }

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
            // AsNoTracking() dice ad EFCore di non inserire nel Change Tracker l'oggetto che viene restituito dal db
            return dbContext.Books.AsNoTracking().Where(book => book.Id == id).SingleOrDefault();
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


            Page<Book> res = new(query.ToList(), totItems, pageLimit, pageIndex);

            return res;
        }

        public bool Insert(BookDTO dto)
        {

            // EFCore ha un Change Tracker (gestito per singola richiesta) dove va a tracciare le modifiche degli oggetti.
            // La/le query di modifica del DB avviene quando viene fatto il save. Fino a quel momento tutte le modifiche sono "locali"
            // Gli stati degli oggetti nel CT sono: 
            //   - Detached (non tracciato)
            //   - Unchanged (Trancciato ma non ha subito modifiche)
            //   - Added (Tracciato ma deve essere ancora inserito nel db)
            //   - Modified (Tracciato ed ha subito modifiche)
            //   - Deleted (Tracciato ma deve essere eliminato dal db)

            // Aggiungo al change tracker il nuovo oggetto da inserire (ha lo stato *added*)
            dbContext.Books.Add(dto.ToBook());

            // Dico ad EFCore di applicare le modifiche che ha tracciato nel Change Tracker (in questo caso fa la insert di book)
            // Dopo l'esecuzione di questa riga l'oggetto book passerà da *added* ad *unchanged* 
            int insertedRows = dbContext.SaveChanges();

            return insertedRows > 0;
        }

        public bool Update(int idToUpdate, BookDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}