using System.Data;
using esercizio_1.Entities.Utils;
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

                if (queryArguments[i] is NotASqlParameter)
                    continue;

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


            using var connection = new NpgsqlConnection(ConnectionString);

            connection.Open();

            using var cmd = new NpgsqlCommand(queryWithParameter.query, connection);

            cmd.Parameters.AddRange(queryWithParameter.parameters);

            using var reader = cmd.ExecuteReader();

            int tableIndex = 0;

            // Metodo dinamico per gestire più query:
            // Carichiamo la prima tabella
            DataTable firstTable = new DataTable($"Table{tableIndex}");
            res.Tables.Add(firstTable);
            firstTable.Load(reader);

            // Se reader non è stato chiuso (quindi dovrebbero esserci nuove tabelle)
            while (!reader.IsClosed)
            {
                tableIndex++;
                DataTable resTable = new DataTable($"Table{tableIndex}");
                res.Tables.Add(resTable);
                resTable.Load(reader);
            }


            return res;
        }
    }
}