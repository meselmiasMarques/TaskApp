using Microsoft.EntityFrameworkCore;
using Tarefas.Api.Data;
using Tarefas.Api.EndPoints;
using Tarefas.Api.Handlers;
using Tarefas.Core.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
//builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

// Habilita o middleware do Swagger (em desenvolvimento ou produção)
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Você pode customizar aqui se quiser
}

app.MapEndpoints();

app.Run();
