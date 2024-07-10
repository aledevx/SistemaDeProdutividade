using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;

namespace SistemaDeProdutividade.Application.UseCases.Produtividade.Mapas;
public class MapasProdutividadeUseCase : IMapasProdutividadeUseCase
{
    private readonly IProdutividadeReadOnlyRepository _prodReadOnlyRepository;
    public MapasProdutividadeUseCase(IProdutividadeReadOnlyRepository prodReadOnlyRepository)
    {
        _prodReadOnlyRepository = prodReadOnlyRepository;
    }
    public async Task<MapasProdResponseJson> Execute()
    {
        var mapas = await _prodReadOnlyRepository.BuscarMapas();

        return new MapasProdResponseJson(mapas);
    }
}
