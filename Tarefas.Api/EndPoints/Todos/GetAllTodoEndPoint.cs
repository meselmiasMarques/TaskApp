using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Todos;
using Tarefas.Core.Responses;

namespace Tarefas.Api.EndPoints.Todos;

public class GetAllTodoEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", HanderAsync)
            .WithName("Todos : GetAll")
            .WithSummary("Lista todas Tarefas")
            .WithDescription("Lista todas Tarefas")
            .WithOrder(3)
            .Produces<Response<List<Todo>>>();
    }
    
    
    private static async Task<IResult> HanderAsync(
        ITodoHandler handler
        
    )
    {
        var result = await handler.GetAllAsync();
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result.Data);
    }
}