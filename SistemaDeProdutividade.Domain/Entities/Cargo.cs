using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Entities;
public class Cargo
{
    public Guid Id { get; }
    public string Nome { get; set; } = string.Empty;
}
