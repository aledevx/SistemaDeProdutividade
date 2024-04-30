using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Entities;
public class Produtividade
{
    public Guid Id { get; private set; }
    public Guid CargoId { get; set; }
    public Cargo? Cargo { get; set; }
    public Guid ValorProdId { get; set; }
    public ValorProd? ValorProd { get; set; }
    public List<Atividade> Atividades { get; set; } = [];
}
