using Tarefas.Core.Models.Categories;
using Tarefas.Core.Requests.Categories;
using Tarefas.Core.Responses;

namespace Tarefas.Core.Handlers;

public interface ICategoryHandler
{
    Task<Response<Category?>> CreateAsync(CreateCategoryRequest request);
    Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request);
    Task<Response<Category?>> GetByIdAsync(GetByIdCategoryRequest request);
    Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request);
    Task<Response<List<Category>?>> GetAllAsync();
}