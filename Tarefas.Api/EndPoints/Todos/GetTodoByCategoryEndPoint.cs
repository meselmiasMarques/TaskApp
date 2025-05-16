using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Todos;
using Tarefas.Core.Requests.Todos;
using Tarefas.Core.Responses;

namespace Tarefas.Api.EndPoints.Todos;

public class GetTodoByCategoryEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/category/{CategoryId}", HandlerAsync)
            .WithName("Todo : GetByCategory")
            .WithSummary("Recupera todos por categoria")
            .WithDescription("Recupera todos por categoria")
            .WithOrder(5)
            .Produces<Response<Todo?>>();
    }
    
    private static async Task<IResult> HandlerAsync(
        ITodoHandler handler,
        long categoryId
    )
    {
        var request = new GetByCategoryRequest
        {
            CategoryId = categoryId
        };
        var result = await handler.GetByCategoryAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result.Data);
    }
}