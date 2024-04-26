using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Enums;
public enum StatusProdutividade
{
    Criada = 0,
    Pontuada = 1,
    AguardandoAssinaturaChefe = 2,
    DisponivelParaRH = 3,
    Devolvida = 4,
    FinalizadaPeloRh = 5,
}
