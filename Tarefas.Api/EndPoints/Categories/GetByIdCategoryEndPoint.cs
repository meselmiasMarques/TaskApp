using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Categories;
using Tarefas.Core.Requests.Categories;
using Tarefas.Core.Responses;

namespace Tarefas.Api.EndPoints.Categories;

public class GetByIdCategoryEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", HandlerAsync)
            .WithName("Categories : GETByID")
            .WithSummary("Recupera uma  categoria")
            .WithDescription("Recupera uma categoria")
            .WithOrder(4)
            .Produces<Response<Category?>>();
    }
    
    private static async Task<IResult> HandlerAsync(
        ICategoryHandler handler,
        long id
    )
    {
        var request = new GetByIdCategoryRequest
        {
            Id = id
        };
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result.Data);
    }
}