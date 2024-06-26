using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.Requests.Produtividades;

namespace SistemaDeProdutividade.Web.Pages;

public partial class RecebidoProdPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    #endregion


    //protected override async Task OnInitializedAsync()
    //{
    //    IsBusy = true;
        
    //}
}
