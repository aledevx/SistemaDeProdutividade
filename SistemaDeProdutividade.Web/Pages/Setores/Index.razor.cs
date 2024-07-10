using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Communication.ViewModel.Setores;
using SistemaDeProdutividade.Web.Handlers;
using SistemaDeProdutividade.Web.Models;
using SistemaDeProdutividade.Web.Models.Setores;

namespace SistemaDeProdutividade.Web.Pages;

public partial class IndexSetorPage : ComponentBase
{
    #region Properties
    public bool dense = false;
    public bool hover = true;
    public bool striped = false;
    public bool bordered = false;
    public string searchString1 = "";
    public SetorIndexWeb selectedItem1 = default!;
    public HashSet<SetorIndexWeb> selectedItems = new HashSet<SetorIndexWeb>();
    public bool IsBusy { get; set; } = false;
    public PontuarProdutividadeRequestJson InputModel { get; set; } = new();
    public List<SetorIndexWeb> Setores { get; set; } = [];
    public int Qtd = 1;
    #endregion

    #region Services

    [Inject]
    public SetorHandler Handler { get; set; } = null!;
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
            var result = await Handler.BuscarTodos();
            if (result.IsSuccess)
            {
                Setores = result.Data!.Setores.Select(u => new SetorIndexWeb(u.Id, u.Nome, Qtd++)).ToList();
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

    public bool FilterFunc1(SetorIndexWeb setor) => FilterFunc(setor, searchString1);
    public bool FilterFunc(SetorIndexWeb setor, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (setor.Nome.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }

    public void NavigateToProfile(Guid id)
    {
        navigationManager.NavigateTo($"/setores/visualizar/{id}");
    }
    #endregion
}
