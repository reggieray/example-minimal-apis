using Examples.MinimalApi.Todo.MediatR.Data;
using Examples.MinimalApi.Todo.MediatR.Dtos;
using Examples.MinimalApi.Todo.MediatR.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examples.MinimalApi.Todo.MediatR.Endpoints
{
    public static class TodoEndpoints
    {
        public static void MapTodoEndpoints(this WebApplication app)
        {
            app.MapGet("/todoitems", async (IMediator mediator) => await mediator.Send(new GetAllTodosRequest()).ConfigureAwait(false))
                .WithName("GetAllTodos");

            app.MapGet("/todoitems/{id}", async (IMediator mediator, int id) => await mediator.Send(new GetTodoByIdRequest(id)).ConfigureAwait(false))
                .WithName("GetTodoById")
                .Produces<TodoItemDTO>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            app.MapPost("/todoitems", async (IMediator mediator, CreateTodoRequest request) => await mediator.Send(request).ConfigureAwait(false))
                .WithName("CreateTodo")
                .Produces<TodoItemDTO>(StatusCodes.Status201Created);

            app.MapPut("/todoitems/{id}", async (IMediator mediator, int id, UpdateTodoRequest request) =>
            {
                if (id != request.Id)
                {
                    return Results.BadRequest();
                }

                return await mediator.Send(request).ConfigureAwait(false);
            })
                .WithName("UpdateTodo")
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status204NoContent);

            app.MapDelete("/todoitems/{id}", async (IMediator mediator, int id) => await mediator.Send(new DeleteTodoRequest(id)).ConfigureAwait(false))
                .WithName("DeleteTodo")
                .Produces(StatusCodes.Status404NotFound)
                .Produces<TodoItemDTO>(StatusCodes.Status200OK);
        }

        public static void AddTodoServices(this IServiceCollection services)
        {
            services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddMediatR(typeof(TodoItemDTO));
        }
    }
}
