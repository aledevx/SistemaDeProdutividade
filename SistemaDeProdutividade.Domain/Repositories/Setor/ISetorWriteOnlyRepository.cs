using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Repositories.Setor;

public interface ISetorWriteOnlyRepository
{
    Task Add(Entities.Setor setor);
}
