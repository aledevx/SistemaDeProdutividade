using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.Requests.Produtividades;

namespace SistemaDeProdutividade.Web.Pages;

public partial class IndexSetorPage : ComponentBase
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
