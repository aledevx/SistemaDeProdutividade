using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Usuarios;
using SistemaDeProdutividade.Communication.ViewModel;
using SistemaDeProdutividade.Domain.Entities;

namespace SistemaDeProdutividade.Domain.Repositories.Usuario;
public interface IUsuarioReadOnlyRepository
{
    Task<bool> ExisteUsuarioCpf(string cpf);
    Task<bool> ExistLotacaoUsuario(string cpf);
    Task<bool> ExisteUsuarioMatricula(string matricula);
    Task<bool> ExisteUsuarioId(Guid id);
    Task<UsuarioResponseJson> BuscarUsuarioCpf(string cpf);
    Task<List<IndexUsuarioVM>> BuscarUsuarios();
    Guid BuscarIdUsuario(string cpf);
    Task<Guid> BuscarIdUsuario(Guid id);
    Task<PerfilUsuarioResponseJson> BuscarPerfilCompletoComProd(Guid id);
    Task<PerfilUsuarioResponseJson> BuscarPerfilCompletoSemProd(Guid id);
    Task<bool> TemPermissaoAdmin(Guid id);
    Task<bool> TemPermissaoChefe(Guid id);
    Task<bool> TemPermissaoAdmin(string cpf);
    Task<bool> TemPermissaoChefe(string cpf);
    Task<LotacaoAtualUsuarioResponseJson> LotacaoAtual(Guid userId);
    Task<Lotacao> LotacaoAtualComIds(Guid userId);
    Task<List<Lotacao>> Lotacoes();
    Task<Entities.Usuario> BuscarUsuarioPorId(Guid userId);

}
