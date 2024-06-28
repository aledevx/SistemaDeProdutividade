using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Web.Requests.Produtividades;

namespace SistemaDeProdutividade.Web.Pages;

public partial class VisualizarProdPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public EditarProdutividadeRequestJson ProdData { get; set; } = new EditarProdutividadeRequestJson("A111",
        "Alexandre da Silva Oliveira",
        "2003391",
        "Assessor V",
        "Gerência de Tecnologia da Informação",
        new DateTime(2024, 6, 30), new DateTime(2024, 7, 29), "Aguardando assinatura do Chefe");
    #endregion

    public DateRange dateRange = new DateRange(DateTime.Now.AddDays(-30), DateTime.Now);
    public DateTime dataHoje = DateTime.Now;

    private void OnDateRangeChanged()
    {
        if (dateRange.End.HasValue)
        {
            ProdData.DataInicio = dateRange.Start!.Value;
            ProdData.DataFim = dateRange.End!.Value;
        }
    }
    //protected override async Task OnInitializedAsync()
    //{
    //    IsBusy = true;
        
    //}
}
