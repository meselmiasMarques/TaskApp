namespace Tarefas.Api.EndPoints;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}