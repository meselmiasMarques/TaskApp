using System.Net.Http.Json;
using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Todos;
using Tarefas.Core.Requests.Todos;
using Tarefas.Core.Responses;

namespace Tarefas.Web.Handlers;

public class TodoHandler : ITodoHandler
{
    private readonly HttpClient _http;

    public TodoHandler(HttpClient http)
    {
        _http = http;
    }
    
    public async Task<Response<Todo?>> CreateAsync(CreateTodoRequest request)
    {
        var result = await _http.PostAsJsonAsync("v1/todos", request);

        return await result.Content.ReadFromJsonAsync<Response<Todo?>>()
               ?? new Response<Todo?>(null, 400, "falha ao criar tarefas");
    }

    public async Task<Response<Todo?>> UpdateAsync(UpdateTodoRequest request)
    {
        var result = await _http.PutAsJsonAsync($"v1/todos/{request.Id}", request);

        return await result.Content.ReadFromJsonAsync<Response<Todo?>>()
               ?? new Response<Todo?>(null, 400, "falha ao atualizar tarefa");
    }

    public async Task<Response<Todo?>> GetByIdAsync(GetByIdTodoRequest request)
        => await _http.GetFromJsonAsync<Response<Todo?>>($"v1/todos/{request.Id}")
           ?? new Response<Todo?>(null, 400, "Falha ao Recuperar tarefa");
    public async Task<Response<Todo?>> DeleteAsync(DeleteTodoRequest request)
    {
        var result = await _http.DeleteAsync($"v1/categories/{request.Id}");

        return await result.Content.ReadFromJsonAsync<Response<Todo?>>()
               ?? new Response<Todo?>(null, 400, "Falha ao excluir tarefa");
    }

    public async Task<Response<List<Todo>?>> GetAllAsync()
        => await _http.GetFromJsonAsync<Response<List<Todo>?>>("v1/todos")
           ?? new Response<List<Todo>?>(null, 400, "Erro ao recuperar categorias");

    public async Task<Response<List<Todo>?>> GetByCategoryAsync(GetByCategoryRequest request)
        => await _http.GetFromJsonAsync<Response<List<Todo>?>>($"v1/todos/category/{request.CategoryId}")
           ?? new Response<List<Todo>?>(null, 400, "Erro ao recuperar todos por categoria");
}