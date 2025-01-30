
using esercizio_1.Entities;
using esercizio_1.Payloads;

namespace esercizio_1.Interfaces
{
    public interface IAuthorService : IBaseCRUD<Author, AuthorDTO>
    {
        public List<Book>? GetAuthorBooks(int authorId);
    }

}