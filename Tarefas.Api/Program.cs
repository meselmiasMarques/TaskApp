using Microsoft.EntityFrameworkCore;
using Tarefas.Api;
using Tarefas.Api.Data;
using Tarefas.Api.EndPoints;
using Tarefas.Api.Handlers;
using Tarefas.Core.Handlers;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy
                .WithOrigins("https://localhost:7172", "http://localhost:5055") // 👈 CORRETO: separados por vírgula
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Banco de Dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeções
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITodoHandler, TodoHandler>();

var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ APLICA A POLÍTICA COM O NOME CORRETO
app.UseCors(MyAllowSpecificOrigins);

// Endpoints
app.MapEndpoints();

app.Run();