using SistemaDeProdutividade.Communication.ViewModel.Produtividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Communication.Responses.Produtividades;
public class MapasProdResponseJson
{
    public List<MapaProdIndexVM> Mapas { get; set; } = [];
    public MapasProdResponseJson(List<MapaProdIndexVM> mapas)
    {
        Mapas = mapas;
    }
}
