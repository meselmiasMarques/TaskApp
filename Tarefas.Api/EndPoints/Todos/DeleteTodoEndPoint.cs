using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Todos;
using Tarefas.Core.Requests.Todos;
using Tarefas.Core.Responses;

namespace Tarefas.Api.EndPoints.Todos;

public class DeleteTodoEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("/{id}", HandlerAsync)
            .WithName("Todos : Delete")
            .WithSummary("Exclui uma Tarefa")
            .WithDescription("Exclui uma Tarefa")
            .WithOrder(4)
            .Produces<Response<Todo?>>();
    }
    
    private static async Task<IResult> HandlerAsync(
        ITodoHandler Handler,
        long id
    )
    {
        var request = new DeleteTodoRequest { Id = id };
        var result = await Handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}