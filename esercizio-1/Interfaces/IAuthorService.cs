
using esercizio_1.Entities;

namespace esercizio_1.Interfaces
{
    public interface IAuthorService
    {
        public List<Author> GetAll();
        public Author GetById(int id);
    }

}