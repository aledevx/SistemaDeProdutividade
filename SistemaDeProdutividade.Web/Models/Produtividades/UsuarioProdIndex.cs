namespace SistemaDeProdutividade.Web.Models.Produtividades;

public class UsuarioProdIndex
{
    public string Code { get; set; }
    public string Cargo { get; set; }
    public DateTime DataInicial { get; set; }
    public DateTime DataFinal { get; set; }
    public DateTime DataCriacao { get; set; }
    public string Status { get; set; }
    public UsuarioProdIndex(string code, string cargo, DateTime dataInicial, DateTime dataFinal, DateTime dataCriacao, string status)
    {
        Code = code;
        Cargo = cargo;
        DataInicial = dataInicial;
        DataFinal = dataFinal;
        DataCriacao = dataCriacao;
        Status = status;
    }
}
