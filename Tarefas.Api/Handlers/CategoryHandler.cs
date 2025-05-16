using Microsoft.EntityFrameworkCore;
using Tarefas.Api.Data;
using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Categories;
using Tarefas.Core.Requests.Categories;
using Tarefas.Core.Responses;

namespace Tarefas.Api.Handlers;

public class CategoryHandler(AppDbContext context) : ICategoryHandler
{
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        try
        {
            var category = new Category
            {
                Title = request.Title
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, 201, "Categoria Criada com sucesso !");
        }
        catch
        {
            return new Response<Category?>(null, 404, "Ocorreu um erro ao salvar categoria");
        }
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        try
        {
            var category = context.Categories.FirstOrDefault(x => x.Id == request.Id);
            if (category is null)
                return new Response<Category?>(null, 500, "Categoria não encontrada");

            category.Title = request.Title;

            context.Categories.Update(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, 200, "Categoria Atualizada com sucesso !");
        }
        catch
        {
            return new Response<Category?>(null, 404, "Ocorreu um erro ao salvar categoria");
        }
    }

    public async Task<Response<Category?>> GetByIdAsync(GetByIdCategoryRequest request)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (category is null)
                return new Response<Category?>(null, 500, "Categoria não encontrada");
            return new Response<Category?>(category);
        }
        catch (Exception e)
        {
            return new Response<Category?>(null, 404, "Ocorreu um erro ao salvar categoria");
        }
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            var category = context.Categories.FirstOrDefault(x => x.Id == request.Id);
            if (category is null)
                return new Response<Category?>(null, 500, "Categoria não encontrada");

            context.Remove(category);
            await context.SaveChangesAsync();
            return new Response<Category?>(null, 200, "Categoria excluída !");
        }
        catch (Exception e)
        {
            return new Response<Category?>(null, 404, "Ocorreu um erro ao excluir categoria");
        }
    }

    public async Task<Response<List<Category>?>> GetAllAsync()
    {
        try
        {
            var categories = await context
                .Categories.AsNoTracking()
                .ToListAsync();

            return new Response<List<Category>?>(categories, 200);
        }
        catch
        {
            return new Response<List<Category>?>(null, 404, "Ocorreu um erro ao listar categorias");
        }
    }
}