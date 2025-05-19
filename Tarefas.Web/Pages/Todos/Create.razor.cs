using Microsoft.AspNetCore.Components;
using MudBlazor;
using Tarefas.Core.Handlers;
using Tarefas.Core.Models.Categories;
using Tarefas.Core.Requests.Todos;

namespace Tarefas.Web.Pages.Todos;

public partial class CreateTodoPage : ComponentBase
{

    #region Propriedades

    public CreateTodoRequest InputModel { get; set; } = new();
    public List<Category> Categories { get; set; } = [];

    #endregion
    #region Services

    [Inject]
    public ITodoHandler TodoHandler { get; set; } = null!;

    [Inject]
    public ICategoryHandler CategoryHandler { get; set; } = null!;

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
            
            var result = await TodoHandler.CreateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/todos");
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