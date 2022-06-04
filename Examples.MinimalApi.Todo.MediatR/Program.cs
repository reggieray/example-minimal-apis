using Examples.MinimalApi.Todo.MediatR.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTodoServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapTodoEndpoints();

app.Run();