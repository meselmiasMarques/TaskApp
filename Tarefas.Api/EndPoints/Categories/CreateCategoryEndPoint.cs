using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Categories;
using Tarefas.Core.Requests.Categories;
using Tarefas.Core.Responses;

namespace Tarefas.Api.EndPoints.Categories;

public class CreateCategoryEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HanderAsync)
            .WithName("Categories : create")
            .WithSummary("Cria uma nova categoria")
            .WithDescription("Cria uma nova categoria para todos")
            .WithOrder(1)
            .Produces<Response<Category?>>();
    }

    private static async Task<IResult> HanderAsync(
        ICategoryHandler handler,
        CreateCategoryRequest request
    )
    {
       var result = await handler.CreateAsync(request);
       return result.IsSuccess
              ? TypedResults.Created($"{result.Data?.Id}", result)
              : TypedResults.BadRequest(result.Data);
    }
}