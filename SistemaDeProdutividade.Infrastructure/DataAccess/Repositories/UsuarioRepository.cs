using Microsoft.EntityFrameworkCore;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Entities;
using SistemaDeProdutividade.Domain.Repositories.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        return new UsuarioResponseJson(data.Cpf, data.Nome, data.Perfil);
    }
}
