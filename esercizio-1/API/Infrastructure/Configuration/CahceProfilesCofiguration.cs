using Microsoft.AspNetCore.Mvc;

namespace esercizio_1.API.Infrastructure.Configuration
{
    public static class CahceProfilesCofiguration
    {

        public static void ConfigureCacheProfiles(this IServiceCollection services, ConfigurationManager configuration)
        {

            // Prendo tutti i CacheProfile presenti nel appsettings
            Dictionary<string, CacheProfile> cacheProfiles = configuration.GetSection("CacheProfiles")
                                                                // Il get va a mettere nella key del dictionaly il titolo della sezione e mappa il contenuto nell'oggetto specificato
                                                                .Get<Dictionary<string, CacheProfile>>() ?? new Dictionary<string, CacheProfile>();

            // Aggiungo i profili per le mie response
            services.AddControllers(options =>
            {
                // Metodo "classico" con i dati dei profili hard coded
                // options.CacheProfiles.Add("Default", new CacheProfile
                // {
                //     Duration = 120,
                //     Location = ResponseCacheLocation.Any,
                //     // Definisce se i nodi intermedi della rete devono salvare o meno i dati
                //     NoStore = false
                // });

                // Aggiunta dinamica dei profili presi da appsettings
                // In questo caso Default e NoCache
                foreach (var cacheProfile in cacheProfiles)
                    // Add vuole un Dictionary<string, CacheProfile>!
                    options.CacheProfiles.Add(cacheProfile);
            });
        }

    }
}