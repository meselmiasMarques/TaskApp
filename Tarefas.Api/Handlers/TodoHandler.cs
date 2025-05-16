using Microsoft.EntityFrameworkCore;
using Tarefas.Api.Data;
using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Enums;
using Tarefas.Core.Models.Todos;
using Tarefas.Core.Requests.Todos;
using Tarefas.Core.Responses;

namespace Tarefas.Api.Handlers;

public class TodoHandler(AppDbContext context) : ITodoHandler
{
    public async Task<Response<Todo?>> CreateAsync(CreateTodoRequest request)
    {
        try
        {
            var todo = new Todo
            {
                Title = request.Title,
                Description = request.Description,
                CategoryId = request.CategoryId,
                CreatedAt = DateTime.Now,
                Status = EStatus.Pending //cria com status inicial pendente
            };

            await context.Todos.AddAsync(todo);
            await context.SaveChangesAsync();

            return new Response<Todo?>(todo, 201, "Tarefa criada com sucesso !");
        }
        catch
        {
            return new Response<Todo?>(null, 404, "Ocorreu um erro ao salvar Tarefa !");
        }
    }

    public async Task<Response<Todo?>> UpdateAsync(UpdateTodoRequest request)
    {
        try
        {
            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (todo is null)
                return new Response<Todo?>(null, 404, "Não foi possível recuperar a tarefa");

            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.CategoryId = request.CategoryId;
            todo.Status = request.Status;

            context.Todos.Update(todo);
            await context.SaveChangesAsync();

            return new Response<Todo?>(todo, 200, "Tarefa Atualizada com sucesso !");
        }
        catch
        {
            return new Response<Todo?>(null, 404, "Ocorreu um erro ao atualizar Tarefa !");
        }
    }

    public async Task<Response<Todo?>> GetByIdAsync(GetByIdTodoRequest request)
    {
        try
        {
            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (todo is null)
                return new Response<Todo?>(null, 404, "Não foi possível recuperar a tarefa");
            return new Response<Todo?>(todo);
        }
        catch
        {
            return new Response<Todo?>(null, 404, "Ocorreu um erro ao recuperar Tarefa !");
        }
    }

    public async Task<Response<Todo?>> DeleteAsync(DeleteTodoRequest request)
    {
        try
        {
            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (todo is null)
                return new Response<Todo?>(null, 404, "Não foi possível recuperar a tarefa");

            context.Todos.Remove(todo);
            await context.SaveChangesAsync();
            return new Response<Todo?>(null, 200, "Tarefa Excluída com sucesso !");
        }
        catch 
        {
            return new Response<Todo?>(null, 404, "Ocorreu um erro ao recuperar Tarefa !");
        }
    }

    public async Task<Response<List<Todo>?>> GetAllAsync()
    {
        try
        {
            var todos = await context.Todos.ToListAsync();
            return new Response<List<Todo>?>(todos, 200);
            
        }
        catch 
        {
            return new Response<List<Todo>?>(null, 404, "Ocorreu um erro ao recuperar Tarefas !");

        }
    }

    public async Task<Response<List<Todo>?>> GetByCategoryAsync(GetByCategoryRequest request)
    {
        try
        {
            var todos = await context.Todos.Where(c => c.CategoryId == request.CategoryId).ToListAsync();
            return new Response<List<Todo>?>(todos, 200);
            
        }
        catch 
        {
            return new Response<List<Todo>?>(null, 404, "Ocorreu um erro ao recuperar Tarefas !");
        }
    }
}