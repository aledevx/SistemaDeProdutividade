using SistemaDeProdutividade.Communication.Requests.Usuarios;
using SistemaDeProdutividade.Communication.Responses;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface ILotarUsuarioUseCase
{
    Task<MensagemSucessoCadastroResponseJson> Execute(Guid id, LotarUsuarioRequestJson request);
}
