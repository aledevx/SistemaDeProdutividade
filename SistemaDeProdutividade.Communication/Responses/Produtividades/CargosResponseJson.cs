using SistemaDeProdutividade.Communication.ViewModel.Produtividades;
using SistemaDeProdutividade.Communication.ViewModel.Setores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Communication.Responses.Produtividades;
public class CargosResponseJson
{
    public List<CargoIndexVM> Cargos { get; set; } = [];
    public CargosResponseJson(List<CargoIndexVM> cargos)
    {
        Cargos = cargos;
    }
}
