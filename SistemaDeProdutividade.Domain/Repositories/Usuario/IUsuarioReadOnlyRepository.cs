using SistemaDeProdutividade.Communication.Responses;

namespace SistemaDeProdutividade.Domain.Repositories.Usuario;
public interface IUsuarioReadOnlyRepository
{
    Task<bool> ExisteUsuarioCpf(string cpf);
    Task<bool> ExisteUsuarioMatricula(string matricula);
    Task<UsuarioResponseJson> BuscarUsuarioCpf(string cpf);
}
