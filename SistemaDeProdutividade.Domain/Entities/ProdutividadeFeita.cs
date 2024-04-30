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
    public string Codigo { get; set; } = string.Empty; //TODO: VERIFICAR NO BANCO SE ESSE CÓDIGO JA EXISTE, GERAR OUTRO CÓDIGO CASO JA EXISTA
    public string NomeUsuario { get; } = string.Empty;
    public string MatriculaUsuario { get; } = string.Empty;
    public string CargoUsuario { get; } = string.Empty;
    public string SetorLotado { get; } = string.Empty;
    public DateTime DataInicio { get; }
    public DateTime DataFim { get; }
    public StatusProdutividade Status { get; set; } = StatusProdutividade.Criada;
    public Guid UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public bool Ativo { get; set; } = true;
    public bool FaltasNaoJustificadas { get; set; } = false;
    public bool SemAssinaturaServidor { get; set; } = false; //PARA CASO O SERVIDOR ESTEJA DE FÉRIAS
    public List<Assinatura> Assinaturas { get; set; } = [];
    public List<AtividadePontuada> Atividades { get; set; } = [];
    public List<HistoricoMovimentacaoProd> Historico { get; set; } = [];
}
