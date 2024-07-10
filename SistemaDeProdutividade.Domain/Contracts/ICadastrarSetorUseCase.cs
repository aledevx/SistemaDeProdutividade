using SistemaDeProdutividade.Communication.Requests.Setores;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Setores;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface ICadastrarSetorUseCase
{
    Task<MensagemSucessoCadastroResponseJson> Execute(CadastrarSetorRequestJson request);
}
