using Microsoft.EntityFrameworkCore;
using SistemaDeProdutividade.Domain.Entities;
using SistemaDeProdutividade.Domain.Repositories.Setor;

namespace SistemaDeProdutividade.Infrastructure.DataAccess.Repositories;
public class SetorRepository : ISetorWriteOnlyRepository, ISetorReadOnlyRepository
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
    public async Task<Setor> GetById(int id)
    {
        return await _dbContext.Setores.FirstAsync(s => s.Id.Equals(id));
    }
    public async Task Editar(Setor setor)
    {
        _dbContext.Setores.Update(setor);
        await _dbContext.SaveChangesAsync();
    }
}
