using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;

namespace SistemaDeProdutividade.Application.UseCases.Produtividade.Visualizar;
public class VisualizarProdutividadeFeitaUseCase : IVisualizarProdutividadeFeitaUseCase
{
    private readonly IProdutividadeReadOnlyRepository _prodReadOnlyRepository;
    public VisualizarProdutividadeFeitaUseCase(IProdutividadeReadOnlyRepository prodReadOnlyRepository)
    {
        _prodReadOnlyRepository = prodReadOnlyRepository;
    }
    public Task<ProdutividadeFeitaResponseJson> Execute(Guid id)
    {
        var prodFeita = _prodReadOnlyRepository.VisualizarProdFeita(id);

        return prodFeita;

    }
}
