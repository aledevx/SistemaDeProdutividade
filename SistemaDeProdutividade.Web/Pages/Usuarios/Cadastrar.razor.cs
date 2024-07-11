using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.ViewModel.Produtividades;
using SistemaDeProdutividade.Communication.ViewModel.Setores;
using SistemaDeProdutividade.Web.DTOs;
using SistemaDeProdutividade.Web.Handlers;

namespace SistemaDeProdutividade.Web.Pages;

public partial class CadastrarUsuarioPage : ComponentBase
{
    #region Properties
    public string[] perfis = { "Servidor", "Chefe", "Admin" };
    public bool IsBusy { get; set; } = false;
    public string cpf { get; set; } = string.Empty;
    public string matricula { get; set; } = string.Empty;
    public string nomeUsuario { get; set; } = string.Empty;
    public string perfilSelected { get; set; } = string.Empty;
    public Guid SetorId { get; set; } = Guid.Empty;
    public Guid CargoId { get; set; } = Guid.Empty;
    public UsuarioDto? usuarioLogado;
    public List<SetorIndexVM> Setores { get; set; } = [];
    public List<CargoIndexVM> Cargos { get; set; } = [];

    #endregion

    #region Services
    [Inject]
    public AuthHandler authHandler { get; set; } = null!;
    [Inject]
    public UsuarioHandler UserHandler { get; set; } = null!;
    [Inject]
    public ProdutividadeHandler ProdHandler { get; set; } = null!;
    [Inject]
    public SetorHandler SetorHandler { get; set; } = null!;
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
            var request = new CadastrarUsuarioRequestJson(nomeUsuario, matricula, cpf, perfilSelected, usuarioLogado!.Cpf,CargoId, SetorId );
            var response = await UserHandler.CadastrarAsync(request);
            if (response.IsSuccess)
            {
                Snackbar.Add("Usuário cadastrado com sucesso", Severity.Success);
                NavigationManager.NavigateTo("/usuarios");
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
            usuarioLogado = await authHandler.GetUserAsync();
            var cargos = await ProdHandler.BuscarCargos();
            var setores = await SetorHandler.BuscarTodos();
            if (cargos.IsSuccess && setores.IsSuccess)
            {
                Setores = setores.Data!.Setores;
                Cargos = cargos.Data!.Cargos;
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
