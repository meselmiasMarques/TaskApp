using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Todos;
using Tarefas.Core.Requests.Todos;
using Tarefas.Core.Responses;

namespace Tarefas.Api.EndPoints.Todos;

public class CreateTodoEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HandlerAsync)
            .WithName("Todos : create")
            .WithSummary("Cria uma nova Tarefa")
            .WithDescription("Cria uma nova Tarefa ")
            .WithOrder(1)
            .Produces<Response<Todo?>>();
    }

    private static async Task<IResult> HandlerAsync(
        ITodoHandler Handler,
        CreateTodoRequest request
    )
    {
        var result = await Handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}