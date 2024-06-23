using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Web.Handlers;
using SistemaDeProdutividade.Web.Requests;

namespace SistemaDeProdutividade.Web.Pages;

public partial class LoginPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public LoginRequestJson InputModel { get; set; } = new();

    #endregion

    #region Services

    [Inject]
    public AuthHandler Handler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.LoginAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/");
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion
}
