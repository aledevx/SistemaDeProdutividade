using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Entities;
public class Produtividade
{
    public Guid Id { get; private set; }
    public Guid CargoId { get; private set; }
    public Cargo? Cargo { get; private set; }
    public decimal ValorAtual { get; set; }
    private readonly List<Atividade> atividades = [];
}
