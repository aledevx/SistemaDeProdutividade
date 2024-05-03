using Microsoft.Extensions.DependencyInjection;
using SistemaDeProdutividade.Application.Services.EntityMapper;
using SistemaDeProdutividade.Application.UseCases.Usuario.Cadastrar;
using SistemaDeProdutividade.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services) 
    {
        AddEntityMappingService(services);
        AddUseCases(services);
    }
    private static void AddEntityMappingService(IServiceCollection services) 
    {
        services.AddScoped<IRequestEntityMapperService, EntityMapperService>();
    }
    private static void AddUseCases(IServiceCollection services) 
    {
        services.AddScoped<ICadastrarUsuarioUseCase, CadastrarUsuarioUseCase>();
    }

}
