using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Todos;
using Tarefas.Core.Requests.Todos;
using Tarefas.Core.Responses;

namespace Tarefas.Api.EndPoints.Todos;

public class GetByIdTodoEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", HandlerAsync)
            .WithName("Todo : GetById")
            .WithSummary("Recupera uma tarefa ")
            .WithDescription("Recupera uma tarefa")
            .WithOrder(4)
            .Produces<Response<Todo?>>();
    }
    
    private static async Task<IResult> HandlerAsync(
        ITodoHandler handler,
        long id
    )
    {
        var request = new GetByIdTodoRequest
        {
            Id = id
        };
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result.Data);
    }
}