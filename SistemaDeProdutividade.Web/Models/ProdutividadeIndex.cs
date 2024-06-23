namespace SistemaDeProdutividade.Web.Models;

public class ProdutividadeIndex
{
    public int Number { get; set; }
    public string Cargo { get; set; }
    public DateTime DataInicial { get; set; }
    public DateTime DataFinal { get; set; } 
    public DateTime DataCriacao { get; set; }
    public string Status { get; set; }
}
