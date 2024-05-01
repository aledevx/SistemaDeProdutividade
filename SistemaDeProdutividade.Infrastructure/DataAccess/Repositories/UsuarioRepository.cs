using Microsoft.EntityFrameworkCore;
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
}
