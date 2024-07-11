using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.Enums;
using SistemaDeProdutividade.Communication.Requests.Setores;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.ViewModel.Setores;
using SistemaDeProdutividade.Web.Handlers;

namespace SistemaDeProdutividade.Web.Pages;

public partial class CadastrarSetorPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public string nomeSetor { get; set; } = string.Empty;
    public Guid? SetorSuperiorId { get; set; }
    public TipoSetor tipoSetor { get; set; }
    public List<SetorIndexVM> Setores { get; set; } = [];

    #endregion

    #region Services

    [Inject]
    public SetorHandler Handler { get; set; } = null!;
    [Inject]
    public AuthHandler authHandler { get; set; } = null!;
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
            var request = new CadastrarSetorRequestJson(nomeSetor, tipoSetor, SetorSuperiorId);
            var response = await Handler.CadastrarAsync(request);
            if (response.IsSuccess)
            {
                Snackbar.Add(response.Message, Severity.Success);
                NavigationManager.NavigateTo("/setores");
            }
            else
            {
                var errors = response.Data as ListErrorsResponseJson;
                foreach (var error in errors!.Errors)
                {
                    Snackbar.Add(error, Severity.Error);
                }
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
    protected override async Task OnInitializedAsync()
    {

        try
        {
            var result = await Handler.BuscarTodos();
            if (result.IsSuccess)
            {
                Setores = result.Data!.Setores;
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    public async void Voltar()
    {
        await authHandler.Voltar();
    }

    #endregion
}
