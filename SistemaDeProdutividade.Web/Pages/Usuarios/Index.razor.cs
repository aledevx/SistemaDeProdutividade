using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Web.Handlers;
using SistemaDeProdutividade.Web.Models;

namespace SistemaDeProdutividade.Web.Pages;

public partial class IndexUsuarioPage : ComponentBase
{
    #region Properties
    public bool dense = false;
    public bool hover = true;
    public bool striped = false;
    public bool bordered = false;
    public string searchString1 = "";
    public UsuarioIndex selectedItem1 = null;
    public HashSet<UsuarioIndex> selectedItems = new HashSet<UsuarioIndex>();

    public bool IsBusy { get; set; } = false;
    public List<UsuarioIndex> Usuarios { get; set; } = [];
    public int Qtd = 1;
    #endregion
    #region Services

    [Inject]
    public UsuarioHandler Handler { get; set; } = null!;
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
                Usuarios = result.Data!.Usuarios.Select(u => new UsuarioIndex(u.Id, u.Nome, u.Cpf, u.Matricula, Qtd++)).ToList();
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
    public bool FilterFunc1(UsuarioIndex usuario) => FilterFunc(usuario, searchString1);

    public void NavigateToProfile(Guid id)
    {
        navigationManager.NavigateTo($"/usuarios/perfil/{id}");
    }

    public bool FilterFunc(UsuarioIndex usuario, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (usuario.Nome.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (usuario.Cpf.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ($"{usuario.Matricula}".Contains(searchString))
            return true;
        return false;
    }

    #endregion

}
