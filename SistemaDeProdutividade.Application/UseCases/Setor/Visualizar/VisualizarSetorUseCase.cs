using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Setor;

namespace SistemaDeProdutividade.Application.UseCases.Setor.Visualizar;

public class VisualizarSetorUseCase : IVisualizarSetorUseCase
{
    private readonly ISetorReadOnlyRepository _readOnlyRepository;

    public VisualizarSetorUseCase(ISetorReadOnlyRepository readOnlyRepository)
    {
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task<SetorResponseJson> Execute(Guid setorId)
    {
        var setor = await _readOnlyRepository.BuscarSetorPorId(setorId);

        return new SetorResponseJson(setor.Nome);
    }

    // public bool Validate()
    // {       
    //     return true;
    // }
}
