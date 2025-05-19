using Microsoft.AspNetCore.Components;
using Tarefas.Core.Requests.Todos;

namespace Tarefas.Web.Pages.Todos;

public partial class CreateTodoPage : ComponentBase
{
    
    public CreateTodoRequest InputModel { get; set; } = new();
    
    
    
    #region Methods

    public async Task OnValidSubmitAsync()
    {
       

        // try
        // {
        //     var result = await TransactionHandler.CreateAsync(InputModel);
        //     if (result.IsSuccess)
        //     {
        //         Snackbar.Add(result.Message, Severity.Success);
        //         NavigationManager.NavigateTo("/lancamentos/historico");
        //     }
        //     else
        //         Snackbar.Add(result.Message, Severity.Error);
        // }
        // catch (Exception ex)
        // {
        //     Snackbar.Add(ex.Message, Severity.Error);
        // }
        // finally
        // {
        //     IsBusy = false;
        // }
    }

    #endregion
}