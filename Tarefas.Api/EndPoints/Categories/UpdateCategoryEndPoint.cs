using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Categories;
using Tarefas.Core.Requests.Categories;
using Tarefas.Core.Responses;

namespace Tarefas.Api.EndPoints.Categories;

public class UpdateCategoryEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", HanderAsync)
            .WithName("Categories : Update")
            .WithSummary("Atualiza uma  categoria")
            .WithDescription("Atualiza uma categoria")
            .WithOrder(2)
            .Produces<Response<Category?>>();
    }
    
    private static async Task<IResult> HanderAsync(
        ICategoryHandler handler,
        UpdateCategoryRequest request,
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