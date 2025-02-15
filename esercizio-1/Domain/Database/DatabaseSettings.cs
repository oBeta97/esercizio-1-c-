using esercizio_1.Interfaces;

namespace esercizio_1.Entities
{
    public class DatabaseSettings : IDbDetails
{
    public string ConnectionString { get; set; } = string.Empty;

    public string GetConnectionString()
    {
        return ConnectionString;
    }
}

}