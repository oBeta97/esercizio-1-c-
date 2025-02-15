using esercizio_1.Entities.EFCore;
using Microsoft.EntityFrameworkCore;

namespace esercizio_1.API.Infrastructure.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDb(this IServiceCollection services, string connectionString)
        {
            // In questo caso i dbContext vengono creati ad ogni richiesta (più sicuro ma più lento)
            // builder.Services.AddDbContext<LibrarydbContext>(
            //     options => options.UseNpgsql("Server=localhost;Port=5432;Database=librarydb;Username=postgres;Password=1234;")
            // );

            // In questo caso viene crato all'avvio dell'applicazione un pool di dbContext che vengono iniettati ad ogni richiesta
            // Questo rende più reattiva l'app ma scoperta ad alcune problematiche date dalla "condivisione" dei dbContext.
            // NB! Il dbContext viene assegnato ad una richiesta per tutto il suo ciclo vitale. Solo alcune modifiche permangono e non vengono "sbiancate" al termine della richiesta
            services.AddDbContextPool<LibrarydbContext>(
                options => options.UseNpgsql(connectionString)
            );

            // Aggiunta della dependency injection delle classi del database
            services.ConfigureDbDependencies();
        }
    }
}