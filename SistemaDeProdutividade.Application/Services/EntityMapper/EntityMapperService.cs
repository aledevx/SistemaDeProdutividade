using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Entities;

namespace SistemaDeProdutividade.Application.Services.EntityMapper;
public class EntityMapperService : IRequestEntityMapperService
{
    public Usuario MappingToUsuario(CadastrarUsuarioRequestJson request)
    {
        var usuario = new Usuario(request.Nome, request.Matricula, request.Cpf, request.Perfil);

        return usuario;
    }
}
