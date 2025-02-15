namespace esercizio_1.API.Infrastructure.Configuration
{
    public static class CacheConfiguration
    {
        public static void AddResponseCache(this IServiceCollection services, ConfigurationManager configuration)
        {
            // ------------------------------ RESPONSE CACHE -----------------------------
            // Riferimento alla configurazione della response cache tramite classi esterne
            services.ConfigureCacheProfiles(configuration);
            // Aggiungo il ResponseCaching al progetto
            services.AddResponseCaching();
            // ---------------------------------------------------------------------------

        }
    }
}