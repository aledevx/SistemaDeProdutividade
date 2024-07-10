using SistemaDeProdutividade.Communication.Responses.Produtividades;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface IMinhasProdutividadeUseCase
{
    Task<ProdsFeitasResponseJson> Execute(string cpfUsuarioLogado);
}
