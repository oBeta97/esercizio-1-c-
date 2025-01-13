using System.Data;
using esercizio_1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace esercizio_1.Services
{
    public class TestService(Idatabaseaccessor db) : ITestServices
    {
        public Idatabaseaccessor Db { get; } = db;

        public List<long> Test()
        {
            var res = new List<long>();

            var queryResult = Db.Query("SELECT * FROM public.\"Kumbukani\"");

            var dataTable = queryResult.Tables[0];

            foreach (DataRow row in dataTable.Rows)
                res.Add( (long) row["ID"] );

            return res;
        }
    }
}