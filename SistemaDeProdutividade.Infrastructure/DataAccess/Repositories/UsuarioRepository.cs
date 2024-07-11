using Microsoft.EntityFrameworkCore;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Usuarios;
using SistemaDeProdutividade.Communication.ViewModel;
using SistemaDeProdutividade.Communication.ViewModel.Produtividades;
using SistemaDeProdutividade.Domain.Constants;
using SistemaDeProdutividade.Domain.Entities;
using SistemaDeProdutividade.Domain.Repositories.Usuario;

namespace SistemaDeProdutividade.Infrastructure.DataAccess.Repositories;
public class UsuarioRepository : IUsuarioWriteOnlyRepository, IUsuarioReadOnlyRepository
{
    private readonly ProdContext _dbContext;
    public UsuarioRepository(ProdContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Usuario usuario) 
    {
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<bool> ExisteUsuarioCpf(string cpf) 
    {
        return await _dbContext.Usuarios.AnyAsync(u => u.Cpf.Equals(cpf));
    }
    public async Task<bool> ExisteUsuarioMatricula(string matricula)
    {
        return await _dbContext.Usuarios.AnyAsync(u => u.Matricula.Equals(matricula));
    }
    public async Task<UsuarioResponseJson> BuscarUsuarioCpf(string cpf)
    {
        var data =await _dbContext.Usuarios.FirstAsync(u => u.Cpf.Equals(cpf));

        return new UsuarioResponseJson(data.Id, data.Cpf, data.Nome, data.Perfil);
    }
    public async Task<List<IndexUsuarioVM>> BuscarUsuarios() 
    {
        var usuarios = await _dbContext.Usuarios
                                        .AsNoTracking()
                                        .Select(u => new IndexUsuarioVM(u.Id, u.Nome, u.Cpf, u.Matricula))
                                        .ToListAsync();

        return usuarios;
    }
    public async Task LotarUsuario(Lotacao lotacao) 
    {
        await _dbContext.Lotacoes.AddAsync(lotacao);
        await _dbContext.SaveChangesAsync();
    }

    public Guid BuscarIdUsuario(string cpf)
    {
       var idUsuario = _dbContext.Usuarios.Where(u => u.Cpf.Equals(cpf)).First().Id;
        return idUsuario;
    }

    public async Task<bool> ExisteUsuarioId(Guid id)
    {
        var exist = await _dbContext.Usuarios.AnyAsync(u => u.Id == id);
        return exist;
    }

    public async Task<Guid> BuscarIdUsuario(Guid id)
    {
        var idUsuario = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

        return idUsuario!.Id;
    }

    public async Task<bool> TemPermissaoAdmin(Guid id)
    {
        var usuario = await _dbContext.Usuarios.FindAsync(id);
        if (usuario!.Perfil == Perfil.Admin)
        {
            return true;
        }
        else 
        {
            return false;
        }

    }

    public async Task<bool> TemPermissaoChefe(Guid id)
    {
        var usuario = await _dbContext.Usuarios.FindAsync(id);
        if (usuario!.Perfil == Perfil.Chefe)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> TemPermissaoAdmin(string cpf)
    {
        var usuario = await _dbContext.Usuarios.FirstAsync(u => u.Cpf.Equals(cpf));
        if (usuario!.Perfil == Perfil.Admin)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> TemPermissaoChefe(string cpf)
    {
        var usuario = await _dbContext.Usuarios.FirstAsync(u => u.Cpf.Equals(cpf));
        if (usuario!.Perfil == Perfil.Chefe)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public async Task<PerfilUsuarioResponseJson> BuscarPerfilCompletoComProd(Guid id)
    {
        var perfilCompletoSemProd = await BuscarPerfilCompletoSemProd(id);

        var prods = _dbContext.ProdutividadesFeitas
            .Where(p => p.UsuarioId == id && p.Status == Domain.Enums.StatusProdutividade.Finalizada)
            .Select(p => new ProdutividadeFinalizadaIndexVM(p.Id, p.Codigo, 0, p.CargoUsuario, p.DataInicio, p.DataFim, p.DataCriacao, p.Status))
            .AsNoTracking()
            .ToListAsync();

        if (prods.Result.Any())
        {
            perfilCompletoSemProd.AddProds(prods.Result);
        }

        return perfilCompletoSemProd;
    }

    public async Task<PerfilUsuarioResponseJson> BuscarPerfilCompletoSemProd(Guid id)
    {
        var usuarioData = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

        var lotacaoAtual = LotacaoAtual(id);
       
        var result = new PerfilUsuarioResponseJson(id, usuarioData!.Nome, usuarioData.Matricula, usuarioData.Cpf);


        if (string.IsNullOrEmpty(lotacaoAtual.Result.CargoNome) ||
            string.IsNullOrEmpty(lotacaoAtual.Result.SetorNome))
        {
            result.AddCargoESetor("O usuário ainda não foi lotado", "O usuário ainda não foi lotado");
        }
        else
        {
            result.AddCargoESetor(lotacaoAtual.Result.CargoNome, lotacaoAtual.Result.SetorNome);
        }

        return result;
    }

    public async Task<LotacaoAtualUsuarioResponseJson> LotacaoAtual(Guid userId)
    {
        var lotacaoAtualData = await _dbContext.Lotacoes.Where(l => l.UsuarioId == userId)
                                                   .AsNoTracking()
                                                   .OrderByDescending(l => l.DataLotacao)
                                                   .FirstOrDefaultAsync();
        if (lotacaoAtualData != null)
        {
            var nomeCargo = await _dbContext.Cargos.FirstOrDefaultAsync(c => c.Id == lotacaoAtualData.CargoId);
            var nomeSetor = await _dbContext.Setores.FirstOrDefaultAsync(s => s.Id == lotacaoAtualData.SetorId);

            var result = new LotacaoAtualUsuarioResponseJson(lotacaoAtualData.UsuarioId,
                                                                nomeCargo!.Nome,
                                                                nomeSetor!.Nome);

            return result;
        }
        else 
        {
            return new LotacaoAtualUsuarioResponseJson();
        }
    }
    public async Task<Lotacao> LotacaoAtualComIds(Guid userId)
    {
        var lotacaoAtualData = await _dbContext.Lotacoes.Where(l => l.UsuarioId == userId)
                                                   .AsNoTracking()
                                                   .OrderByDescending(l => l.DataLotacao)
                                                   .FirstOrDefaultAsync();
        return lotacaoAtualData;
    }

    public async Task<bool> ExistLotacaoUsuario(string cpf)
    {
        var userId = BuscarIdUsuario(cpf);

        var existLotacao = await _dbContext.Lotacoes.AnyAsync(l => l.UsuarioId == userId);

        return existLotacao;
    }

    public async Task<List<Lotacao>> Lotacoes()
    {
        var result = await _dbContext.Lotacoes.ToListAsync();

        return result;
    }

    public async Task<Usuario> BuscarUsuarioPorId(Guid userId)
    {
        var result = await _dbContext.Usuarios.FirstAsync(u => u.Id == userId);
        return result;
    }
}
