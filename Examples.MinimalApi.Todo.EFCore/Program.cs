using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));

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

app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.Select(x => new TodoItemDTO(x)).ToListAsync().ConfigureAwait(false))
    .WithName("GetAllTodos");

app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id).ConfigureAwait(false)
        is TodoItem todo
            ? Results.Ok(new TodoItemDTO(todo))
            : Results.NotFound())
    .WithName("GetTodoById")
    .Produces<TodoItemDTO>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);

app.MapPost("/todoitems", async (TodoItemDTO todoItemDTO, TodoDb db) =>
{
    var todoItem = new TodoItem
    {
        IsComplete = todoItemDTO.IsComplete,
        Name = todoItemDTO.Name
    };

    db.Todos.Add(todoItem);
    await db.SaveChangesAsync().ConfigureAwait(false);

    return Results.Created($"/todoitems/{todoItem.Id}", new TodoItemDTO(todoItem));
})
.WithName("CreateTodo")
.Produces<TodoItemDTO>(StatusCodes.Status201Created);

app.MapPut("/todoitems/{id}", async (int id, TodoItemDTO todoItemDTO, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id).ConfigureAwait(false);

    if (todo is null) return Results.NotFound();

    todo.Name = todoItemDTO.Name;
    todo.IsComplete = todoItemDTO.IsComplete;

    await db.SaveChangesAsync().ConfigureAwait(false);

    return Results.NoContent();
})
.WithName("UpdateTodo")
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status204NoContent);

app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id).ConfigureAwait(false) is TodoItem todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync().ConfigureAwait(false);
        return Results.Ok(new TodoItemDTO(todo));
    }

    return Results.NotFound();
})
.WithName("DeleteTodo")
.Produces(StatusCodes.Status404NotFound)
.Produces<TodoItemDTO>(StatusCodes.Status200OK);

app.Run();

public class TodoItem
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public string? Secret { get; set; }
}

public class TodoItemDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }

    public TodoItemDTO() { }
    public TodoItemDTO(TodoItem todoItem) =>
    (Id, Name, IsComplete) = (todoItem.Id, todoItem.Name, todoItem.IsComplete);
}

class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<TodoItem> Todos => Set<TodoItem>();
}