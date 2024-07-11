using Microsoft.EntityFrameworkCore;
using SistemaDeProdutividade.Communication.Responses.Setores;
using SistemaDeProdutividade.Communication.ViewModel.Setores;
using SistemaDeProdutividade.Domain.Entities;
using SistemaDeProdutividade.Domain.Repositories.Setor;

namespace SistemaDeProdutividade.Infrastructure.DataAccess.Repositories;
public class SetorRepository : ISetorReadOnlyRepository, ISetorWriteOnlyRepository
{
    private readonly ProdContext _context;
    public SetorRepository(ProdContext context)
    {
        _context = context;
    }

    public async Task Add(Setor setor)
    {
        await _context.Setores.AddAsync(setor);
        await _context.SaveChangesAsync();
    }

    public async void AddChefeSetor(Usuario usuario, Guid setorId)
    {
        var setor = await BuscarSetor(setorId);

        setor.ChefeId = usuario.Id;
        setor.AddChefe(usuario);
    }

    public async Task<Setor> BuscarSetor(Guid id)
    {
        var setor = await _context.Setores.Include(s => s.Chefe).FirstAsync(s => s.Id == id);
        return setor;
    }

    public async Task<List<Setor>> BuscarSetoresSubordinados(Guid setorId)
    {
        var setores = await _context.Setores.Where(s => s.SetorSuperiorId == setorId).ToListAsync();

        return setores;
    }

    public async Task<bool> ExisteSetor(Guid setorId)
    {
        var exist = await _context.Setores.AnyAsync(s => s.Id == setorId);
        return exist;
    }

    public async Task<bool> ExisteSetorNome(string nome)
    {
        var exist = await _context.Setores.AnyAsync(s => s.Nome.ToLower().Trim().Equals(nome.ToLower().Trim()));
        return exist;
    }

    public async Task<SetoresResponseJson> GetAll()
    {
        var setores = await _context.Setores.Select(s => new SetorIndexVM(s.Id, s.Nome)).ToListAsync();

        return new SetoresResponseJson(setores);

    }
}
