using SistemaDeProdutividade.Communication.Responses.Produtividades;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface IIndexProdutividadesFeitasUseCase
{
    Task<ProdsFeitasResponseJson> Execute(string cpfUsuarioLogado);
}
