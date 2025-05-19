using Microsoft.AspNetCore.Components;
using MudBlazor;
using Tarefas.Core.Handlers;
using Tarefas.Core.Requests.Categories;
using Tarefas.Web.Handlers;

namespace Tarefas.Web.Pages.Categories;

public partial class CreateCategoryPage : ComponentBase
{
    
    public CreateCategoryRequest InputModel { get; set; } = new();
    
    
    #region Services

    [Inject]
    public ICategoryHandler Handler { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    #endregion
    
    #region Methods

    public async Task OnValidSubmitAsync()
    {
        try
        {
            var result = await Handler.CreateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/categorias");
            }
            else
                Snackbar.Add(result.Message, Severity.Error);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        
    }

    #endregion
}