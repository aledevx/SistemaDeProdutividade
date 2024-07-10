using SistemaDeProdutividade.Communication.DTOs.Assinaturas;
using SistemaDeProdutividade.Communication.DTOs.Atividades;
using SistemaDeProdutividade.Domain.Enums;

namespace SistemaDeProdutividade.Communication.Responses.Produtividades;
public class ProdutividadeFeitaResponseJson
{
    public string Codigo { get; set; } = string.Empty;
    public string NomeUsuario { get; set; } = string.Empty;
    public string MatriculaUsuario { get; set; } = string.Empty;
    public string CargoUsuario { get; set; } = string.Empty;
    public string SetorLotado { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set;  }
    public StatusProdutividade Status { get; set; }
    public Guid UsuarioId { get; set; }
    public DateTime DataCriacao { get; set; }
    public string? Observacao { get; set; }
    public decimal ValorDaProdutividade { get; set; }
    public List<AssinaturaDTO> Assinaturas { get; set; } = [];
    public List<AtividadePontuadaDTO> Atividades { get; set; } = [];
    public ProdutividadeFeitaResponseJson()
    {
    }
    public ProdutividadeFeitaResponseJson(string codigo,
        string nomeUsuario,
        string matriculaUsuario,
        string cargoUsuario,
        string setorLotado,
        Guid usuarioId,
        decimal valorDaProdutividade)
    {
        Codigo = codigo;
        NomeUsuario = nomeUsuario;
        MatriculaUsuario = matriculaUsuario;
        CargoUsuario = cargoUsuario;
        SetorLotado = setorLotado;
        UsuarioId = usuarioId;
        ValorDaProdutividade = valorDaProdutividade;
    }
    public void AddAtividade(AtividadePontuadaDTO atividade) 
    {
        Atividades.Add(atividade);
    }
    public void AddAssinatura(AssinaturaDTO assinatura) 
    {
        Assinaturas.Add(assinatura);
    }
    public void AddStatus(StatusProdutividade status) 
    {
        Status = status;
    }
    public void AddDatas(DateTime dataInicio, DateTime dataFim, DateTime dataCriacao) 
    {
        DataInicio = dataInicio;
        DataFim = dataFim;
        DataCriacao = dataCriacao;
    }
    public void AddObservacao(string observacao) 
    {
        Observacao = observacao;
    }
}
