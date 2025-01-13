using esercizio_1.Interfaces;

namespace   esercizio_1.Services
{
    public class TestService : ITestServices
    {
        public TestService(Idatabaseaccessor db)
        {
            Db = db;
        }

        public Idatabaseaccessor Db { get; }

        public string Test()
        {
            var result = Db.Query("SELECT * FROM Kumbukani");
            return "ciao";
        }
    }
}