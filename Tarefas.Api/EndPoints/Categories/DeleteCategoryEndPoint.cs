using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Categories;
using Tarefas.Core.Requests.Categories;
using Tarefas.Core.Responses;

namespace Tarefas.Api.EndPoints.Categories;

public class DeleteCategoryEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("/{id}", HandlerAsync)
            .WithName("Categories : Delete")
            .WithSummary("Exclui uma  categoria")
            .WithDescription("Exclui uma categoria")
            .WithOrder(5)
            .Produces<Response<Category?>>();
    }
    
    private static async Task<IResult> HandlerAsync(
        ICategoryHandler handler,
        long id
    )
    {
        var request = new DeleteCategoryRequest
        {
            Id = id
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result.Data);
    }
}