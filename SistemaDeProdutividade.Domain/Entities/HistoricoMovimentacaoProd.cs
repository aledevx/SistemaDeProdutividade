using SistemaDeProdutividade.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Entities;
public class HistoricoMovimentacaoProd
{
    public Guid Id { get; set; }
    public Guid ProdutividadeFeitaId { get; set; }
    public Guid UsuarioId { get; set; }
    public StatusProdutividade StatusProdutividade { get; set; }
    public DateTime DataMovimentacao { get; set; }
    public string Observacao { get; set; } = string.Empty;
}
