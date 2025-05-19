using Microsoft.AspNetCore.Components;
using MudBlazor;
using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Categories;
using Tarefas.Core.Requests.Categories;

namespace Tarefas.Web.Pages.Categories;

public partial class ListCategoriesPage : ComponentBase
{

    #region Propriedades

    public List<Category> Categories { get; set; } = [];
    
    public string SearchTerm { get; set; } = string.Empty;

    #endregion

    #region Services

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public IDialogService DialogService { get; set; } = null!;

    [Inject]
    public ICategoryHandler Handler { get; set; } = null!;

    #endregion
    
    #region OVERRIDES

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var result = await Handler.GetAllAsync();

            if (result.IsSuccess)
            {
                Categories = result.Data ?? [];
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    
    

    #endregion

    #region Metodos

    public Func<Category, bool> Filter => category =>
    {
        if (string.IsNullOrWhiteSpace(SearchTerm))
            return true;

        if (category.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (category.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;
        

        return false;
    };


    public async Task OnDeleteButtonClickedAsync(long id, string title)
    {
        try
        {
            var request = new DeleteCategoryRequest { Id = id };
             await Handler.DeleteAsync(request);
             Categories.RemoveAll(c => c.Id == request.Id);
             Snackbar.Add($"Categoria {title} excluída", Severity.Success);

        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

    #endregion
}