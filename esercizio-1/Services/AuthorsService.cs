using System.Data;
using esercizio_1.Interfaces;
using esercizio_1.Payloads;

namespace esercizio_1.Entities
{
    public class AuthorService(Idatabaseaccessor db) : IAuthorService
    {
        public List<Author> GetAll()
        {
            List<Author> res = [];

            FormattableString query = $"SELECT * FROM authors";

            DataSet queryRes = db.ExecuteSelectQuery(query);
            DataTable resTable = queryRes.Tables[0];

            foreach (DataRow dataRow in resTable.Rows)
                res.Add(Author.FromDataRow(dataRow));

            return res;
        }

        public Author? GetById(int id)
        {
            FormattableString query = $"SELECT * FROM authors WHERE id = {id}";

            DataSet queryRes = db.ExecuteSelectQuery(query);
            DataTable resTable = queryRes.Tables[0];

            if (resTable.Rows.Count == 0)
                return null;

            Author res = Author.FromDataRow(resTable.Rows[0]);

            return res;

        }

        public bool Insert(AuthorDTO author)
        {
            FormattableString query = $"INSERT INTO authors (name, country) VALUES ({author.Name}, {author.Country})";

            return db.ExecuteModifyQuery(query) == 1;

        }

        public bool Update(int id, AuthorDTO dto)
        {
            FormattableString query = $"UPDATE authors SET name = {dto.Name} , country = {dto.Country} WHERE id = {id}";

            return db.ExecuteModifyQuery(query) == 1;

        }

        public bool Delete(int idToDelete)
        {
            FormattableString query = $"DELETE FROM authors WHERE id = {idToDelete}";

            return db.ExecuteModifyQuery(query) == 1;
        }

        public List<Book>? GetAuthorBooks(int authorId)
        {
            List<Book> res = [];

            FormattableString query = $"SELECT b.* FROM authors a JOIN books b ON b.author_id = a.id WHERE a.id = {authorId}";

            DataSet queryRes = db.ExecuteSelectQuery(query);
            DataTable resTable = queryRes.Tables[0];

            if (resTable.Rows.Count == 0)
                return null;

            foreach (DataRow dataRow in resTable.Rows)
                res.Add(Book.FromDataRow(dataRow));

            return res;

        }
    }
}