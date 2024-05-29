using System.Threading.Tasks;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Responses;

namespace SistemaDeProdutividade.Domain.Contracts
{
    public interface IEditarSetorUseCase
    {
        Task<MensagemSucessoResponseJson> Execute(EditarSetorRequestJson request);
    }
}