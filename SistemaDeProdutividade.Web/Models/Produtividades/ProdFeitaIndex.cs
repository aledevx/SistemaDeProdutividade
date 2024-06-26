namespace SistemaDeProdutividade.Web.Models.Produtividades;

public class ProdFeitaIndex
{
    public string Code { get; set; }
    public string NomeUsuario { get; set; }
    public string Cargo { get; set; }
    public DateTime DataCriacao { get; set; }
    public string Status { get; set; }
    public ProdFeitaIndex(string code, string nomeUsuario, string cargo, DateTime dataCriacao, string status)
    {
        Code = code;
        NomeUsuario = nomeUsuario;
        Cargo = cargo;
        DataCriacao = dataCriacao;
        Status = status;
    }
}
