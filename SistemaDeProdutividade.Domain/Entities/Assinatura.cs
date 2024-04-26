using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Entities;
public class Assinatura
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public Guid UsuarioId { get; set; }
    public Guid ProdutividadeFeitaId { get; set; }
    public DateTime DataAssinatura { get; set; } = DateTime.Now;
    public bool Ativo { get; set; } = true;
}
