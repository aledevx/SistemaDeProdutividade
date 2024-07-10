using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Usuarios;
using SistemaDeProdutividade.Communication.ViewModel.Produtividades;
using SistemaDeProdutividade.Web.DTOs;
using SistemaDeProdutividade.Web.Handlers;

namespace SistemaDeProdutividade.Web.Pages;

public partial class UsuarioPerfilPage : ComponentBase
{
    #region Properties
    [Parameter] public Guid Id { get; set; }
    public bool IsBusy { get; set; } = false;
    public int Qtd = 1;
    public UsuarioDto? usuarioLogado;
    public PerfilUsuarioResponseJson UsuarioPerfil { get; set; } = new();
    public List<ProdutividadeFinalizadaIndexVM> Prods { get; set; } = [];
    #endregion
    #region Services
    [Inject]
    public AuthHandler authHandler { get; set; } = null!;
    [Inject]
    public UsuarioHandler UserHandler { get; set; } = null!;
    [Inject]
    public NavigationManager navigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Methods
    public void NavigateToPage()
    {
        navigationManager.NavigateTo($"/usuarios/lotacao/{Id}");
    }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            usuarioLogado = await authHandler.GetUserAsync();
            var response = await UserHandler.PerfilAsync(Id, usuarioLogado!.Cpf);
            if (response.IsSuccess)
            {
                var perfilData = response.Data as PerfilUsuarioResponseJson;
                UsuarioPerfil = perfilData!;
                if (UsuarioPerfil != null) 
                {
                    if (UsuarioPerfil.ProdutividadesFinalizadas!.Count() > 0) 
                    {
                        foreach (var item in UsuarioPerfil.ProdutividadesFinalizadas!) 
                        {
                            Prods.Add(new ProdutividadeFinalizadaIndexVM(item.Id,
                                item.Code,
                                Qtd++,
                                item.Cargo,
                                item.DataInicial,
                                item.DataFinal,
                                item.DataCriacao,
                                item.Status));
                        }

                    }
                }
            }
            else
            {
                var errors = response.Data as ListErrorsResponseJson;
                foreach (var error in errors!.Errors)
                {
                    Snackbar.Add(error, Severity.Error);
                    navigationManager.NavigateTo("/");
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
    #endregion
}
