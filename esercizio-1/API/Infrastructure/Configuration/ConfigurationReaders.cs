using esercizio_1.Entities;
using esercizio_1.Entities.Settings;
using Microsoft.Extensions.Caching.Memory;

namespace esercizio_1.API.Infrastructure.Configuration
{
    public static class ConfigurationReaders
    {
        public static void ReadCustomConfigurations(this IServiceCollection services, ConfigurationManager configuration, string connectionString)
        {
            // Quando un servizio ha bisogno di IOptions<DatabaseSettings>, usa questa configurazione
            services.Configure<DatabaseSettings>(options =>
            {
                if (connectionString == "CONNECTION_STRING NOT FOUND!")
                    throw new Exception(connectionString);

                options.ConnectionString = connectionString;
            });

            // Vado a leggere in modo tipizzato in appsettings la sezione Authors
            services.Configure<AuthorsSettings>(
                configuration.GetSection("Authors")
            );
            services.Configure<BooksSettings>(
                configuration.GetSection("Books")
            );

            // Andiamo a leggere negli appsettings il SizeLimit della memoria ram che andremo ad occupare e lo configuro nell'applicazione
            services.Configure<MemoryCacheOptions>(configuration.GetSection("CacheOptions"));
        }
    }
}