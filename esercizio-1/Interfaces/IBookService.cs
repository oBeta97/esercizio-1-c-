using esercizio_1.Entities.EFCore;
using esercizio_1.Payloads;

namespace esercizio_1.Interfaces
{
    public interface IBookService : IBaseCRUD<Book, BookDTO>
    {
        
    }

}