using esercizio_1.Database;
using esercizio_1.Interfaces;
using esercizio_1.Services;

var builder = WebApplication.CreateBuilder(args);

// Aggiungi tutti i figli di ControllerBase
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection, quando il builder trova queste interfacce inietta la classe specificata
builder.Services.AddScoped<Idatabaseaccessor, PostgresDatabaseAccessor>();
builder.Services.AddScoped<ITestServices, TestService>();

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

