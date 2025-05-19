using System.Net.Http;
using System.Net.Http.Json;
using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Categories;
using Tarefas.Core.Requests.Categories;
using Tarefas.Core.Responses;

namespace Tarefas.Web.Handlers;

public class CategoryHandler : ICategoryHandler
{
    private readonly HttpClient _http;

    public CategoryHandler(HttpClient http)
    {
        _http = http;
    }

    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        var result = await _http.PostAsJsonAsync("v1/categories", request);

        return await result.Content.ReadFromJsonAsync<Response<Category?>>()
               ?? new Response<Category?>(null, 400, "falha ao criar categoria");
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        var result = await _http.PutAsJsonAsync($"v1/categories/{request.Id}", request);

        return await result.Content.ReadFromJsonAsync<Response<Category?>>()
               ?? new Response<Category?>(null, 400, "falha ao atualizar categoria");
    }

    public async Task<Response<Category?>> GetByIdAsync(GetByIdCategoryRequest request)
        => await _http.GetFromJsonAsync<Response<Category?>>($"v1/categories/{request.Id}")
           ?? new Response<Category?>(null, 400, "Falha ao Recuperar categoria");

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        var result = await _http.DeleteAsync($"v1/categories/{request.Id}");

        return await result.Content.ReadFromJsonAsync<Response<Category?>>()
               ?? new Response<Category?>(null, 400, "Falha ao escluir categoria");
    }

    public async Task<Response<List<Category>?>> GetAllAsync()
        => await _http.GetFromJsonAsync<Response<List<Category>?>>("v1/categories")
           ?? new Response<List<Category>?>(null, 400, "Erro ao recuperar categorias");
}