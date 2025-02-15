using esercizio_1.Database;
using esercizio_1.Entities;
using esercizio_1.Interfaces;
using Microsoft.Extensions.Options;

namespace esercizio_1.API.Infrastructure.Configuration
{
    public static class DatabaseInjection
    {
        public static void ConfigureDbDependencies(this IServiceCollection services)
        {
            services.AddScoped<Idatabaseaccessor, PostgresDatabaseAccessor>();

            // Aggiungiamo un singleton di IdbDetails specificandone la classe da recuperare manualmente tramite gli IOptions
            // in questo caso va a cercare un IOptions<DatabaseSettings> che abbiamo istanziato sopra
            services.AddSingleton<IDbDetails>(sp =>
                // In questo caso cerca una ISTANZA IOptions<DatabaseSettings>, se non lo trova restituisce null
                // sp.GetService<IOptions<DatabaseSettings>>()

                // In questo caso cerca una ISTANZA IOptions<DatabaseSettings>, se non lo trova genera una eccezione
                // NB! Non da errore se la connectionString non è stata trovata!!!
                sp.GetRequiredService<IOptions<DatabaseSettings>>().Value
            );
        }
    }
}