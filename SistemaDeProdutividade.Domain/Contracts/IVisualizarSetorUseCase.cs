using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Entities;

namespace SistemaDeProdutividade.Domain.Contracts
{
    public interface IVisualizarSetorUseCase
    {
        Task<SetorResponseJson> Execute(Guid id);
    }
}