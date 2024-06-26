namespace SistemaDeProdutividade.Web.Models.Produtividades;

public class ProdRecebidaIndex
{
    public string Code { get; set; }
    public string NomeUsuario { get; set; }
    public string Setor { get; set; }
    public DateTime DataCriacao { get; set; }
    public ProdRecebidaIndex(string code, string nomeUsuario, string setor, DateTime dataCriacao)
    {
        Code = code;
        NomeUsuario = nomeUsuario;
        Setor = setor;
        DataCriacao = dataCriacao;
    }
}
