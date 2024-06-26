using SistemaDeProdutividade.Web.DTOs.Atividades;

namespace SistemaDeProdutividade.Web.Requests.Produtividades;

public class CadastrarProdutividadeRequestJson 
{
    public string Cargo { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public IEnumerable<AtividadeDTO> Atividades { get; set; } = [];
}
