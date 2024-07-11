using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.Requests.Usuarios;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Usuarios;
using SistemaDeProdutividade.Communication.ViewModel.Produtividades;
using SistemaDeProdutividade.Communication.ViewModel.Setores;
using SistemaDeProdutividade.Web.DTOs;
using SistemaDeProdutividade.Web.Handlers;
using SistemaDeProdutividade.Web.Responses;

namespace SistemaDeProdutividade.Web.Pages;

public partial class LotacaoUsuarioPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public string[] perfis = { "Servidor", "Chefe", "Admin" };
    public string perfilSelected { get; set; } = string.Empty;
    [Parameter] public Guid Id { get; set; }
    public string Cpf { get; set; } = string.Empty;
    public string MatriculaUsuario { get; set; } = string.Empty;
    public string NomeUsuario { get; set; } = string.Empty;
    public string SetorUsuario { get; set; } = string.Empty;
    public string CargoUsuario { get; set; } = string.Empty;
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
            var request = new LotarUsuarioRequestJson(SetorId, CargoId, usuarioLogado!.Cpf, perfilSelected);
            var response = await UserHandler.LotarAsync(Id, request);
            if (response.IsSuccess)
            {
                Snackbar.Add(response.Message, Severity.Success);
                NavigationManager.NavigateTo($"/usuarios/perfil/{Id}");
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
            var userData = await UserHandler.PerfilAsync(Id, usuarioLogado!.Cpf);
            if (userData.IsSuccess) 
            {
                var perfilData = userData.Data as PerfilUsuarioResponseJson;

                NomeUsuario = perfilData!.Nome;
                Cpf = perfilData.Cpf;
                MatriculaUsuario = perfilData.Matricula;
                SetorUsuario = perfilData.Setor;
                CargoUsuario = perfilData.Cargo;
            }

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

    public void Voltar() 
    {
        NavigationManager.NavigateTo($"/usuarios/perfil/{Id}");
    }

    #endregion
}
