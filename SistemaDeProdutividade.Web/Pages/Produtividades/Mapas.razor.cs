using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.ViewModel.Produtividades;
using SistemaDeProdutividade.Web.Handlers;

namespace SistemaDeProdutividade.Web.Pages;

public partial class MapasProdPage : ComponentBase
{
    #region Properties
    public bool dense = false;
    public bool hover = true;
    public bool striped = false;
    public bool bordered = false;
    public string searchString1 = "";
    public MapaProdIndexVM selectedItem1 = null;
    public HashSet<MapaProdIndexVM> selectedItems = new HashSet<MapaProdIndexVM>();

    public bool IsBusy { get; set; } = false;
    public List<MapaProdIndexVM> Mapas { get; set; } = [];
    public int Qtd = 1;
    #endregion
    #region Services

    [Inject]
    public ProdutividadeHandler prodHandler { get; set; } = null!;
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
            var result = await prodHandler.BuscarMapas();
            if (result.IsSuccess)
            {
                Mapas = result.Data!.Mapas.Select(m => new MapaProdIndexVM(m.Id, m.Cargo, m.ValorProd)).ToList();
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
    public bool FilterFunc1(MapaProdIndexVM mapa) => FilterFunc(mapa, searchString1);

    public void NavigateToProfile(Guid id)
    {
        navigationManager.NavigateTo($"/produtividades/visualizar/mapa");
    }

    public bool FilterFunc(MapaProdIndexVM mapa, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (mapa.Cargo.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ($"{mapa.ValorProd}".Contains(searchString))
            return true;
        return false;
    }

    #endregion

}
