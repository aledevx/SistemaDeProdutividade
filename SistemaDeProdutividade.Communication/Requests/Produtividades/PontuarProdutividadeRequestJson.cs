using SistemaDeProdutividade.Communication.DTOs.Atividades;

namespace SistemaDeProdutividade.Communication.Requests.Produtividades;
public class PontuarProdutividadeRequestJson
{
    public string NomeUsuario { get; set;  } = string.Empty;
    public string MatriculaUsuario { get; set; } = string.Empty;
    public string CargoUsuario { get; set; } = string.Empty;
    public string Lotacao { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; } 
    public DateTime DataFim { get; set; }
    public List<AtividadePontuadaDTO> AtividadesPontuadas = [];

    public PontuarProdutividadeRequestJson(string nomeUsuario,
        string matriculaUsuario, 
        string cargoUsuario, 
        string lotacao, 
        DateTime dataInicio, 
        DateTime dataFim)
    {
        NomeUsuario = nomeUsuario;
        MatriculaUsuario = matriculaUsuario;
        CargoUsuario = cargoUsuario;
        Lotacao = lotacao;
        DataInicio = dataInicio;
        DataFim = dataFim;
    }
    public PontuarProdutividadeRequestJson()
    {
        
    }
}


