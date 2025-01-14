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

            // RIP Kumbukani :(
            // var queryResult = Db.Query("SELECT * FROM public.\"Kumbukani\"");

            // var dataTable = queryResult.Tables[0];
            var dataTable = new DataTable();

            foreach (DataRow row in dataTable.Rows)
                res.Add( (long) row["ID"] );

            return res;
        }
    }
}