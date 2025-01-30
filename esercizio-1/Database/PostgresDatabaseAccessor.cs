using System.Data;
using esercizio_1.Interfaces;
using Npgsql;

namespace esercizio_1.Database
{
    public class PostgresDatabaseAccessor(IdbDetails _dbDetails) : Idatabaseaccessor
    {

        private readonly string ConnectionString = _dbDetails.GetConnectionString();

        // Ritorna una tupla stringa/NpgsqlParameter
        private static (string query, NpgsqlParameter[] parameters) CreateQueryWithParameter(FormattableString formattedQuery)
        {

            // SELECT * FROM "Kumbukani" WHERE ID = @0 -> parametro: @0 = 2
            var queryArguments = formattedQuery.GetArguments();
            var npgParameters = new List<NpgsqlParameter>();
            for (var i = 0; i < queryArguments.Length; i++)
            {
                var parameter = new NpgsqlParameter(i.ToString(), queryArguments[i]);
                npgParameters.Add(parameter);
                queryArguments[i] = "@" + i;
            }

            return (formattedQuery.ToString(), npgParameters.ToArray());
        }

        public int ExecuteModifyQuery(FormattableString formattedQuery)
        {
            var queryWithParameter = CreateQueryWithParameter(formattedQuery);

            using var connection = new NpgsqlConnection(ConnectionString);

            connection.Open();

            using var cmd = new NpgsqlCommand(queryWithParameter.query, connection);

            cmd.Parameters.AddRange(queryWithParameter.parameters);

            return cmd.ExecuteNonQuery();
        }

        public DataSet ExecuteSelectQuery(FormattableString formattedQuery)
        {

            var queryWithParameter = CreateQueryWithParameter(formattedQuery);

            DataSet res = new DataSet();
            DataTable resTable = new DataTable();

            res.Tables.Add(resTable);


            using var connection = new NpgsqlConnection(ConnectionString);

            connection.Open();

            using var cmd = new NpgsqlCommand(queryWithParameter.query, connection);

            cmd.Parameters.AddRange(queryWithParameter.parameters);

            using var reader = cmd.ExecuteReader();

            resTable.Load(reader);

            return res;
        }
    }
}