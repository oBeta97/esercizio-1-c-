using DotNetEnv;
using esercizio_1.Database;
using esercizio_1.Entities;
using esercizio_1.Entities.EFCore;
using esercizio_1.Interfaces;
using esercizio_1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Leggo tramite il pachetto nuget il file .env
Env.Load("./.env");
// Associo ad una variabile la connectionString
string? connectionString = Env.GetString("CONNECTION_STRING", "CONNECTION_STRING NOT FOUND!");


// Build di Serilog con impostazione di cosa, come e dove trascrivere le informazioni da loggare
builder.Host.UseSerilog((context, services, configuration) =>
    configuration
        // --- Configurazione manuale ---
        // .WriteTo.Console() // Log in console
        // .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // log giornaliero su file (nuovo file ogni giorno)

        // --- Configurazione da file di configurazione appSettings.json ---
        .ReadFrom.Configuration(context.Configuration) // Lettura delle configurazioni in appsettings
);


// Aggiungi tutti i figli di ControllerBase
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In questo caso i dbContext vengono creati ad ogni richiesta (più sicuro ma più lento)
// builder.Services.AddDbContext<LibrarydbContext>(
//     options => options.UseNpgsql("Server=localhost;Port=5432;Database=librarydb;Username=postgres;Password=1234;")
// );

// In questo caso viene crato all'avvio dell'applicazione un pool di dbContext che vengono iniettati ad ogni richiesta
// Questo rende più reattiva l'app ma scoperta ad alcune problematiche date dalla "condivisione" dei dbContext.
// NB! Il dbContext viene assegnato ad una richiesta per tutto il suo ciclo vitale. Solo alcune modifiche permangono e non vengono "sbiancate" al termine della richiesta
builder.Services.AddDbContextPool<LibrarydbContext>(
    options => options.UseNpgsql(connectionString)
);

// Quando un servizio ha bisogno di IOptions<DatabaseSettings>, usa questa configurazione
builder.Services.Configure<DatabaseSettings>(options =>
{
    if(connectionString == "CONNECTION_STRING NOT FOUND!")
        throw new Exception("CONNECTION_STRING NOT FOUND!");

    options.ConnectionString = connectionString;
});

// Dependency injection, quando il builder trova queste interfacce inietta la classe specificata
builder.Services.AddScoped<Idatabaseaccessor, PostgresDatabaseAccessor>();
builder.Services.AddScoped<ITestServices, TestService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BooksService>();

// Aggiungiamo un singleton di IdbDetails specificandone la classe da recuperare manualmente tramite gli IOptions
// in questo caso va a cercare un IOptions<DatabaseSettings> che abbiamo istanziato sopra
builder.Services.AddSingleton<IdbDetails>(sp =>
    // In questo caso cerca una ISTANZA IOptions<DatabaseSettings>, se non lo trova restituisce null
    // sp.GetService<IOptions<DatabaseSettings>>()

    // In questo caso cerca una ISTANZA IOptions<DatabaseSettings>, se non lo trova genera una eccezione
    // NB! Non da errore se la connectionString non è stata trovata!!!
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Esegui il map di tutti i controller trovati
app.MapControllers();


app.Run();

Log.CloseAndFlush();
