using Tarefas.Api.EndPoints.Categories;
using Tarefas.Api.EndPoints.Todos;
using Tarefas.Core.Requests.Categories;
using Tarefas.Core.Requests.Todos;

namespace Tarefas.Api.EndPoints;

public static class EndPoints
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup("");

        endpoints.MapGroup("v1/categories")
            .WithTags("Categories")
            .MapEndpoint<CreateCategoryEndPoint>()
            .MapEndpoint<UpdateCategoryEndPoint>()
            .MapEndpoint<GetAllCategoryEndPoint>()
            .MapEndpoint<GetByIdCategoryEndPoint>()
            .MapEndpoint<DeleteCategoryEndPoint>();

        endpoints.MapGroup("v1/todos")
            .WithTags("Todos")
            .MapEndpoint<CreateTodoEndPoint>()
            .MapEndpoint<UpdateTodoEndPoint>()
            .MapEndpoint<GetByIdTodoEndPoint>()
            .MapEndpoint<DeleteTodoEndPoint>()
            .MapEndpoint<GetTodoByCategoryEndPoint>()
            .MapEndpoint<GetAllTodoEndPoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}