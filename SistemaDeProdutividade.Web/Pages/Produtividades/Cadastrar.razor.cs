using Microsoft.AspNetCore.Components;
using SistemaDeProdutividade.Web.Requests.Produtividades;

namespace SistemaDeProdutividade.Web.Pages;

public partial class CadastrarProdutividadePage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public PontuarProdutividadeRequestJson InputModel { get; set; } = new();
    #endregion
    public string Cargo { get; set; } = null!;
    public string[] headings = { "nº", "Descrição da Atividade", "Peso", "Quantidade", "Subtotal" };
    public string[] rows = {
        @"1 DescriçãoTeste 3 10 30",
        @"2 DescriçãoTeste 3 10 30",
        @"3 DescriçãoTeste 3 10 30",
        @"4 DescriçãoTeste 3 10 30",
        @"5 DescriçãoTeste 3 10 30",
        @"6 DescriçãoTeste 3 10 30",
    };

    //protected override async Task OnInitializedAsync()
    //{
    //    IsBusy = true;
        
    //}
}
