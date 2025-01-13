using System.Data;

namespace   esercizio_1.Database
{
    public class PostgresDatabaseAccessor : Idatabaseaccessor
    {
        public DataSet Query(string query)
        {
            using(var connection = new Npgsql.NpgsqlConnection("Server=localhost;Port=5432;Database=Test;Username=postgres;Password=1234;")){
                connection.Open();
                var command = new Npgsql.NpgsqlCommand(query, connection);
                var dataset = new DataSet();
                var adapter = new Npgsql.NpgsqlDataAdapter(command);
                adapter.Fill(dataset);
                return dataset;
            }
        }
    }
}