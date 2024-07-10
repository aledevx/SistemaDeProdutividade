using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Enums;
public enum StatusProdutividade
{
    EmCriacao = 0,
    AguardandoAssinaturaChefe = 1,
    AguardandoRh = 3,
    Devolvida = 4,
    Finalizada = 5,
}
