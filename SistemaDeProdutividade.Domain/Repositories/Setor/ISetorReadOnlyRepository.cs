using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Repositories.Setor;

public interface ISetorReadOnlyRepository
{
    Task<Entities.Setor> BuscarSetorPorId(Guid id);
}
