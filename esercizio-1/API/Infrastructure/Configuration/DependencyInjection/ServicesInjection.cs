using esercizio_1.Interfaces;
using esercizio_1.Services;

namespace esercizio_1.API.Infrastructure.Configuration
{
    public static class ServicesInjection
    {
        public static void ServicesConfiguration(this IServiceCollection services)
        {
            // Dependency injection, quando il builder trova queste interfacce inietta la classe specificata
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ITestServices, TestService>();
            services.AddScoped<IBookService, BooksService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICachedGenreService, CachedGenreService>();
            
        }
    }
}