using esercizio_1.Interfaces;

namespace esercizio_1.Entities
{
    public class DatabaseSettings : IdbDetails
{
    public string ConnectionString { get; set; } = string.Empty;

    public string GetConnectionString()
    {
        return ConnectionString;
    }
}

}