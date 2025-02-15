using esercizio_1.Entities.Settings;

namespace esercizio_1.API.Infrastructure.Configuration
{
    public static class SettingsInjection
    {
        public static void SettingsConfiguration(this IServiceCollection services)
        {
            // Aggiungo un transient per tutti i service di authorSettings
            services.AddTransient<AuthorsSettings>();
            services.AddTransient<BooksSettings>();
        }
    }
}