using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Domain.Entities;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface IRequestEntityMapperService
{
    Usuario MappingToUsuario(CadastrarUsuarioRequestJson request);
    Setor MappingToSetor(CriarSetorRequestJson request);
    Setor MappingToSetorEdit(EditarSetorRequestJson request);
}
