using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.Responses.Setores;
using SistemaDeProdutividade.Communication.ViewModel.Setores;
using SistemaDeProdutividade.Web.Handlers;

namespace SistemaDeProdutividade.Web.Pages;

public partial class SetorVisualizarPage : ComponentBase
{
    #region Properties
    [Parameter] public Guid Id { get; set; }
    public bool dense = false;
    public bool hover = true;
    public bool striped = false;
    public bool bordered = false;
    public string searchString1 = "";
    public IndexUsuarioSetorVM selectedItem1 = default!;
    public HashSet<IndexUsuarioSetorVM> selectedItems = new HashSet<IndexUsuarioSetorVM>();
    public bool IsBusy { get; set; } = false;
    public SetorResponseJson SetorData { get; set; } = new();
    public List<IndexUsuarioSetorVM> UsuariosLotados { get; set; } = [];
    public int Qtd = 1;
    #endregion

    #region Services

    [Inject]
    public SetorHandler setorHandler { get; set; } = null!;
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
            var result = await setorHandler.VisualizarAsync(Id);
            if (result.IsSuccess)
            {
                var data = result.Data as SetorResponseJson;
                SetorData = data!;
                if (data!.UsuariosLotados.Count() > 0) 
                {
                    UsuariosLotados = data.UsuariosLotados;
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

    public bool FilterFunc1(IndexUsuarioSetorVM usuario) => FilterFunc(usuario, searchString1);
    public bool FilterFunc(IndexUsuarioSetorVM usuario, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (usuario.Nome.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }

    public void NavigateToProfile(Guid id)
    {
        navigationManager.NavigateTo($"/usuarios/perfil/{id}");
    }
    #endregion
}
