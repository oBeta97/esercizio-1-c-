using esercizio_1.Database;

var builder = WebApplication.CreateBuilder(args);

// Aggiungi tutti i figli di ControllerBase
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<Idatabaseaccessor, PostgresDatabaseAccessor>();

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

