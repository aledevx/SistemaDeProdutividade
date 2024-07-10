using SistemaDeProdutividade.Communication.Responses.Setores;

namespace SistemaDeProdutividade.Domain.Repositories.Setor;
public interface ISetorReadOnlyRepository
{
    Task<SetoresResponseJson> GetAll();
    Task<bool> ExisteSetorNome(string nome);
    Task<bool> ExisteSetor(Guid setorId);
    Task<Entities.Setor> BuscarSetor(Guid id);
    void AddChefeSetor(Entities.Usuario usuario, Guid setorId);
    Task<List<Entities.Setor>> BuscarSetoresSubordinados(Guid setorId);
}
