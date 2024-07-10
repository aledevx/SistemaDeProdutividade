using SistemaDeProdutividade.Communication.Responses.Usuarios;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Usuario;

namespace SistemaDeProdutividade.Application.UseCases.Usuario.Buscar;
public class BuscarUsuariosUseCase : IBuscarUsuariosUseCase
{
    private readonly IUsuarioReadOnlyRepository _readOnlyRepository;
    public BuscarUsuariosUseCase(IUsuarioReadOnlyRepository readOnlyRepository)
    {
        _readOnlyRepository = readOnlyRepository;
    }
    public UsuariosResponseJson Execute()
    {
        var usuarios = _readOnlyRepository.BuscarUsuarios().Result;

        return new UsuariosResponseJson(usuarios);
    }
}
