using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Web.Models.Setores;
using SistemaDeProdutividade.Web.Requests.Setores;

namespace SistemaDeProdutividade.Web.Pages;

public partial class SetorVisualizarPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    #endregion



    //protected override async Task OnInitializedAsync()
    //{
    //    IsBusy = true;

    //}
}
