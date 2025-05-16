using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Categories;
using Tarefas.Core.Responses;

namespace Tarefas.Api.EndPoints.Categories;

public class GetAllCategoryEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", HanderAsync)
            .WithName("Categories : GetAll")
            .WithSummary("Lista todas categorias")
            .WithDescription("Lista todas categorias")
            .WithOrder(3)
            .Produces<Response<List<Category>>>();
    }
    
    
    private static async Task<IResult> HanderAsync(
        ICategoryHandler handler
        
    )
    {
        var result = await handler.GetAllAsync();
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result.Data);
    }
}