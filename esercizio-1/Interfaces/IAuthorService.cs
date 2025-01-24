
using esercizio_1.Entities;
using esercizio_1.Payloads;

namespace esercizio_1.Interfaces
{
    public interface IAuthorService
    {
        public List<Author> GetAll();
        public Author? GetById(int id);
        public bool Insert(AuthorDTO dto);
        public bool Update(int idToUpdate, AuthorDTO dto);
        public bool Delete(int idToDelete);
        public List<Book>? GetAuthorBooks(int authorId);
    }

}