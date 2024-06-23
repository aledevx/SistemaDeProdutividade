using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Web.Requests.Produtividades;

namespace SistemaDeProdutividade.Web.Pages;

public partial class PontuarProdutividadePage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public PontuarProdutividadeRequestJson InputModel { get; set; } = new();
    #endregion

    public string[] headings = { "nº", "Descrição da Atividade", "Peso", "Quantidade", "Subtotal" };
    public string[] rows = {
        @"1 DescriçãoTeste 3 10 30",
        @"2 DescriçãoTeste 3 10 30",
        @"3 DescriçãoTeste 3 10 30",
        @"4 DescriçãoTeste 3 10 30",
        @"5 DescriçãoTeste 3 10 30",
        @"6 DescriçãoTeste 3 10 30",
    };
    public DateRange dateRange = new DateRange(DateTime.Now.AddDays(-30), DateTime.Now);
    public DateTime today = DateTime.Now;

    private void OnDateRangeChanged()
    {
        if (dateRange.End.HasValue)
        {
            dateRange = new DateRange(dateRange.Start, today);
        }
    }
    //protected override async Task OnInitializedAsync()
    //{
    //    IsBusy = true;
        
    //}
}
