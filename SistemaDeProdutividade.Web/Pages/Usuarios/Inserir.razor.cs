using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.Requests.Usuarios;
using SistemaDeProdutividade.Web.Handlers;

namespace SistemaDeProdutividade.Web.Pages;

public partial class InserirUsuarioPage : ComponentBase
{
    #region Properties
    public string[] perfis = { "Servidor", "Chefe", "Admin" };
    public bool IsBusy { get; set; } = false;
    public InsetirUsuarioRequestJson InputModel { get; set; } = new();

    #endregion

    #region Services

    [Inject]
    public UsuarioHandler Handler { get; set; } = null!;
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
            var result = await Handler.InserirAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add("Usuário cadastrado com sucesso", Severity.Success);
                NavigationManager.NavigateTo("/usuarios");
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
