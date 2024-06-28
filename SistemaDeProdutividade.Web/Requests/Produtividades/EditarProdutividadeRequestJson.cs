using SistemaDeProdutividade.Web.DTOs.Atividades;

namespace SistemaDeProdutividade.Web.Requests.Produtividades;

public class EditarProdutividadeRequestJson
{
    public string Code { get; set; }
    public string NomeUsuario { get; set; } = string.Empty;
    public string MatriculaUsuario { get; set; } = string.Empty;
    public string CargoUsuario { get; set; } = string.Empty;
    public string Lotacao { get; set; } = string.Empty;
    public string Status { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public DateTime DataCriacao { get; set; }

    public List<AtividadePontuadaDTO> AtividadesPontuadas = [];

    public EditarProdutividadeRequestJson(string code, string nomeUsuario,
        string matriculaUsuario,
        string cargoUsuario,
        string lotacao,
        DateTime dataInicio,
        DateTime dataFim,
        string status)
    {
        Code = code;
        NomeUsuario = nomeUsuario;
        MatriculaUsuario = matriculaUsuario;
        CargoUsuario = cargoUsuario;
        Lotacao = lotacao;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Status = status;
    }
    public EditarProdutividadeRequestJson()
    {

    }
}