namespace esercizio_1.API.Infrastructure.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                // Abilita le annotazioni (importante se vuoi usare [SwaggerOperation])
                options.EnableAnnotations();
            });

        }
    }
}