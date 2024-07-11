using SistemaDeProdutividade.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Entities;
public class ProdutividadeFeita
{
    public Guid Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string NomeUsuario { get; } = string.Empty;
    public string MatriculaUsuario { get; } = string.Empty;
    public string CargoUsuario { get; } = string.Empty;
    public string SetorLotado { get; } = string.Empty;
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public StatusProdutividade Status { get; set; } = StatusProdutividade.EmCriacao;
    public Guid UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public bool Ativo { get; set; } = true;
    public decimal ValorDaProdutividade { get; set; }
    public bool SemAssinaturaServidor { get; set; } = false; //PARA CASO O SERVIDOR ESTEJA DE FÉRIAS
    public string? Observacao { get; set; } = string.Empty;
    public List<Assinatura> Assinaturas { get; set; } = [];
    public List<AtividadePontuada> Atividades { get; set; } = [];
    public List<HistoricoMovimentacaoProd> Historico { get; set; } = [];
    public ProdutividadeFeita(string codigo,
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
    public void AddPeriodo(DateTime dataInicio, DateTime dataFim)
    {
        DataInicio = dataInicio;
        DataFim = dataFim;
    }
    public void AddAssinatura(Assinatura assinatura) 
    {
        Assinaturas.Add(assinatura);
    }
    public void AddAtividade(AtividadePontuada atividade) 
    {
        Atividades.Add(atividade);
    }
    public void AtualizarValorProd(decimal valorAtualizado) 
    {
        ValorDaProdutividade = valorAtualizado;
    }
    public void AddObservacao(string observacao)
    {
        Observacao = observacao;
    }

}
