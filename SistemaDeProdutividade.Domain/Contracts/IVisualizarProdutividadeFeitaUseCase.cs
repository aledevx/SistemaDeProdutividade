using SistemaDeProdutividade.Communication.Responses.Produtividades;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface IVisualizarProdutividadeFeitaUseCase
{
    Task<ProdutividadeFeitaResponseJson> Execute(Guid id);
}
