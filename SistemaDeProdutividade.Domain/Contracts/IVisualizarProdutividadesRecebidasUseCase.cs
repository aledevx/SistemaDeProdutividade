using SistemaDeProdutividade.Communication.Responses.Produtividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface IVisualizarProdutividadesRecebidasUseCase
{
    Task<ProdsFeitasResponseJson> Execute(string cpfUsuarioLogado);
}
