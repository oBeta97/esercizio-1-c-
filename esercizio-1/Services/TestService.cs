using System.Data;
using esercizio_1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace esercizio_1.Services
{
    public class TestService(Idatabaseaccessor db) : ITestServices
    {
        public Idatabaseaccessor Db { get; } = db;

        // Dummy method! 
        public List<long> Test()
        {
            var res = new List<long>();

            // int id = 4;

            // FormattableString q = $"SELECT * FROM public.\"Kumbukani\" WHERE \"ID\" = {id}";
            FormattableString q = $"SELECT * FROM public.\"Kumbukani\"";

            // RIP Kumbukani :(
            var queryResult = Db.ExecuteSelectQuery(q);

            var dataTable = queryResult.Tables[0];
            // var dataTable = new DataTable();

            foreach (DataRow row in dataTable.Rows)
                res.Add( (long) row["ID"] );

            return res;
        }
    }
}