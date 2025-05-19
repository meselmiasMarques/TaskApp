using Microsoft.AspNetCore.Components;
using MudBlazor;
using Tarefas.Core.Handlers;
using Tarefas.Core.Requests.Categories;

namespace Tarefas.Web.Pages.Categories;

public partial class EditCategoryPage : ComponentBase
{

    #region Propriedades

    public UpdateCategoryRequest InputModel { get; set; } = new();
    public bool IsBusy { get; set; } = false;

    #endregion
    
    #region Services

    [Inject]
    public ICategoryHandler Handler { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Parameters

    [Parameter]
    public string Id { get; set; } = string.Empty;

    #endregion
    
    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        GetByIdCategoryRequest? request = null;
        try
        {
            request = new GetByIdCategoryRequest
            {
                Id = long.Parse(Id)
            };
        }
        catch 
        {
            Snackbar.Add("Parâmetro inválido", Severity.Error);
        }
        
        if (request is null)
            return;
        
        IsBusy = true;
        try
        {
            var response = await Handler.GetByIdAsync(request);
            if (response.IsSuccess)
            {
                InputModel = new UpdateCategoryRequest
                {
                    Id = response.Data.Id,
                    Title = response.Data.Title
                };
            }
            
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        } finally
        {
            IsBusy = false;
        }
    }

    #endregion
    
    #region Methods

    public async Task OnValidSubmitAsync()
    {
        try
        {
            var result = await Handler.UpdateAsync(InputModel);
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