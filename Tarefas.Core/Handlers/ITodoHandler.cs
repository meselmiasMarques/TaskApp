using Tarefas.Core.Models.Todos;
using Tarefas.Core.Requests.Todos;
using Tarefas.Core.Responses;

namespace Tarefas.Core.Handlers;

public interface ITodoHandler
{
    Task<Response<Todo?>> CreateAsync(CreateTodoRequest request);
    Task<Response<Todo?>> UpdateAsync(UpdateTodoRequest request);
    Task<Response<Todo?>> GetByIdAsync(GetByIdTodoRequest request);
    Task<Response<Todo?>> DeleteAsync(DeleteTodoRequest request);
    Task<Response<List<Todo>?>> GetAllAsync();
    Task<Response<List<Todo>?>> GetByCategoryAsync(GetByCategoryRequest request);
    
}