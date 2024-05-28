using SistemaDeProdutividade.Domain.Entities;
using SistemaDeProdutividade.Domain.Repositories.Setor;

namespace SistemaDeProdutividade.Infrastructure.DataAccess.Repositories;
public class SetorRepository : ISetorWriteOnlyRepository
{
    private readonly ProdContext _dbContext;
    public SetorRepository(ProdContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(Setor setor)
    {
        await _dbContext.Setores.AddAsync(setor);
        await _dbContext.SaveChangesAsync();
    }
}
