using Microsoft.AspNetCore.Components;
using SistemaDeProdutividade.Web.Requests.Produtividades;

namespace SistemaDeProdutividade.Web.Pages;

public partial class UsuarioPerfilPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public PontuarProdutividadeRequestJson InputModel { get; set; } = new();
    #endregion

  

    //protected override async Task OnInitializedAsync()
    //{
    //    IsBusy = true;
        
    //}
}
