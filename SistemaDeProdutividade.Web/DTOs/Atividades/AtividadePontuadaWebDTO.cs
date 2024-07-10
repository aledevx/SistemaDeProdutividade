namespace SistemaDeProdutividade.Web.DTOs.Atividades;

public class AtividadePontuadaWebDTO 
{
    public int Numero { get; set; }
    public string Descricao { get; set; }
    public int Pontuacao { get; set; }
    public int Qtd { get; set; }
    public AtividadePontuadaWebDTO(int numero, string descricao, int pontuacao, int qtd)
    {
        Numero = numero;
        Descricao = descricao;
        Pontuacao = pontuacao;
        Qtd = qtd;
    }
}
