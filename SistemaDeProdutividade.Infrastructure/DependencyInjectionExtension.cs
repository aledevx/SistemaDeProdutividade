using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;
using SistemaDeProdutividade.Domain.Repositories.Setor;
using SistemaDeProdutividade.Domain.Repositories.Usuario;
using SistemaDeProdutividade.Infrastructure.DataAccess;
using SistemaDeProdutividade.Infrastructure.DataAccess.Repositories;

namespace SistemaDeProdutividade.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var conectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ProdContext>(options =>
        {
            options.UseSqlServer(conectionString, b => b.MigrationsAssembly("SistemaDeProdutividade.API"));
        });
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUsuarioWriteOnlyRepository, UsuarioRepository>();
        services.AddScoped<IUsuarioReadOnlyRepository, UsuarioRepository>();
        services.AddScoped<IProdutividadeWriteOnlyRepository, ProdutividadeRepository>();
        services.AddScoped<IProdutividadeReadOnlyRepository, ProdutividadeRepository>();
        services.AddScoped<ISetorWriteOnlyRepository, SetorRepository>();
        services.AddScoped<ISetorReadOnlyRepository, SetorRepository>();
    }
}
