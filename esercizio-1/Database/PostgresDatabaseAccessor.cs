using System.Data;
using Npgsql;

namespace esercizio_1.Database
{
    public class PostgresDatabaseAccessor : Idatabaseaccessor
    {
        public DataSet Query(string query)
        {

            DataSet res = new DataSet();
            DataTable resTable = new DataTable();

            res.Tables.Add(resTable);


            using var connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=Test;Username=postgres;Password=1234;");

            connection.Open();

            using var cmd = new NpgsqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            resTable.Load(reader);

            return res;
        }
    }
}