using Examples.MinimalApi.Todo.FastEndpoints.Data;
using Examples.MinimalApi.Todo.FastEndpoints.Services;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDb>(opt => opt.UseSqlite("Data Source=todos.db"));
builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.AddHealthChecks()
    .AddDbContextCheck<TodoDb>();

var app = builder.Build();

EnsureDb(app.Services);

app.UseDefaultExceptionHandler();
app.UseFastEndpoints();

app.MapHealthChecks("/healthcheck");

app.UseHttpsRedirection();

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();

static void EnsureDb(IServiceProvider services)
{
#pragma warning disable CA2000 // Dispose objects before losing scope
    using var db = services.CreateScope().ServiceProvider.GetRequiredService<TodoDb>();
#pragma warning restore CA2000 // Dispose objects before losing scope
    db.Database.EnsureCreated();    
}