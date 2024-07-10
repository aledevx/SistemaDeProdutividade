using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.ViewModel.Produtividades;
using SistemaDeProdutividade.Web.DTOs;
using SistemaDeProdutividade.Web.Handlers;

namespace SistemaDeProdutividade.Web.Pages;

public partial class IndexProdPage : ComponentBase
{
    #region Properties
    public bool dense = false;
    public bool hover = true;
    public bool striped = false;
    public bool bordered = false;
    public string searchString1 = "";
    public UsuarioDto? usuarioLogado;
    public ProdFeitaIndexVM selectedItem1 = null;
    public HashSet<ProdFeitaIndexVM> selectedItems = new HashSet<ProdFeitaIndexVM>();
    public bool IsBusy { get; set; } = false;
    public List<ProdFeitaIndexVM> Produtividades { get; set; } = [];
    public int Qtd = 1;
    #endregion

    #region Services

    [Inject]
    public ProdutividadeHandler prodHandler { get; set; } = null!;
    [Inject]
    public AuthHandler authHandler { get; set; } = null!;
    [Inject]
    public NavigationManager navigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Methods

    protected override async Task OnInitializedAsync()
    {

        IsBusy = true;
        try
        {
            usuarioLogado = await authHandler.GetUserAsync();
            var result = await prodHandler.BuscarTodasProdutividadesFeitas(usuarioLogado!.Cpf);
            if (result.IsSuccess)
            {
                Produtividades = result.Data!.Prods.Select(p => new ProdFeitaIndexVM(p.Id,
                    Qtd++,
                    p.Codigo,
                    p.NomeUsuario,
                    p.Cargo,
                    p.Matricula,
                    p.Lotacao,
                    p.DataCriacao,
                    p.Status,
                    p.UsuarioId)).ToList();
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
    public bool FilterFunc1(ProdFeitaIndexVM prod) => FilterFunc(prod, searchString1);
    public void NavigateToProfile(Guid id)
    {
        navigationManager.NavigateTo($"/produtividades/visualizar/{id}");
    }
    public bool FilterFunc(ProdFeitaIndexVM prod, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (prod.Cargo.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (prod.NomeUsuario.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (prod.Codigo.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ($"{prod.DataCriacao}".Contains(searchString))
            return true;
        if ($"{prod.Status}".Contains(searchString))
            return true;
        return false;
    }
    #endregion
}
