using System.Data;
using esercizio_1.Interfaces;

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

        public Author GetById(int id)
        {
            FormattableString query = $"SELECT * FROM authors WHERE id = {id}";

            DataSet queryRes = db.ExecuteSelectQuery(query);
            DataTable resTable = queryRes.Tables[0];

            Author res = Author.FromDataRow(resTable.Rows[0]);

            return res;

        }
    }
}