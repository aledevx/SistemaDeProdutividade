using Microsoft.Extensions.DependencyInjection;
using SistemaDeProdutividade.Application.Services.AD;
using SistemaDeProdutividade.Application.Services.EntityMapper;
using SistemaDeProdutividade.Application.UseCases.Setor.Criar;
using SistemaDeProdutividade.Application.UseCases.Setor.Editar;
using SistemaDeProdutividade.Application.UseCases.Usuario.Cadastrar;
using SistemaDeProdutividade.Application.UseCases.Usuario.Logar;
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
        AddADService(services);
    }
    private static void AddEntityMappingService(IServiceCollection services) 
    {
        services.AddScoped<IRequestEntityMapperService, EntityMapperService>();
    }
    private static void AddUseCases(IServiceCollection services) 
    {
        services.AddScoped<ICadastrarUsuarioUseCase, CadastrarUsuarioUseCase>();
        services.AddScoped<ICriarSetorUseCase, CriarSetorUseCase>();
        services.AddScoped<IEditarSetorUseCase, EditarSetorUseCase>();
        services.AddScoped<ILogarUsuarioUseCase, LogarUsuarioUseCase>();
    }
    private static void AddADService(IServiceCollection services)
    {
        services.AddTransient<ADService>();
    }

}
