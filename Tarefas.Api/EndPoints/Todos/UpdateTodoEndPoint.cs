using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Todos;
using Tarefas.Core.Requests.Todos;
using Tarefas.Core.Responses;

namespace Tarefas.Api.EndPoints.Todos;

public class UpdateTodoEndPoint  : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", HanderAsync)
            .WithName("Todos : Update")
            .WithSummary("Atualiza uma  tarefa")
            .WithDescription("Atualiza uma tarefa")
            .WithOrder(2)
            .Produces<Response<Todo?>>();
    }
    
    private static async Task<IResult> HanderAsync(
        ITodoHandler handler,
        UpdateTodoRequest request,
        long id
    )
    {
        request.Id = id;
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result.Data);
    }
}