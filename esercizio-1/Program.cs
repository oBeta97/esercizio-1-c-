using DotNetEnv;
using esercizio_1.API.Infrastructure.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Accedo agli appSettings
var configuration = builder.Configuration;

// ---------------------------------------- READ .ENV FILE -----------------------------------
// Leggo tramite il pachetto nuget il file .env
Env.Load("./.env");
// Associo ad una variabile la connectionString
string? connectionString = Env.GetString("CONNECTION_STRING", "CONNECTION_STRING NOT FOUND!");
// -------------------------------------------------------------------------------------------

// Aggiungi tutti i figli di ControllerBase
builder.Services.AddControllers();

// ----------------------------------------------------- SERILOG -------------------------------------------------------------------
// Build di Serilog con impostazione di cosa, come e dove trascrivere le informazioni da loggare
builder.Host.UseSerilog((context, services, configuration) =>
    configuration
        // --- Configurazione manuale ---
        // .WriteTo.Console() // Log in console
        // .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // log giornaliero su file (nuovo file ogni giorno)

        // --- Configurazione da file di configurazione appSettings.json ---
        .ReadFrom.Configuration(context.Configuration) // Lettura delle configurazioni in appsettings
);
// --------------------------------------------------------------------------------------------------------------------------------

builder.Services.ConfigureSwagger();

builder.Services.ConfigureDb(connectionString);

builder.Services.ReadCustomConfigurations(configuration, connectionString);

//----------------------- DEPENDENCY INJECTION -------------------
// Riferimento alla configurazione della DI tramite classi esterne
builder.Services.ServicesConfiguration();
builder.Services.SettingsConfiguration();
//----------------------------------------------------------------

builder.Services.AddResponseCache(configuration);
// Local Cache
builder.Services.AddMemoryCache();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Aggiungo alla pipeline di middleware quello del responsecaching
app.UseResponseCaching();

// Esegui il map di tutti i controller trovati
app.MapControllers();


app.Run();

Log.CloseAndFlush();
