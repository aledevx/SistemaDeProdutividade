using Microsoft.Extensions.DependencyInjection;
using SistemaDeProdutividade.Application.Services.AD;
using SistemaDeProdutividade.Application.Services.EntityMapper;
using SistemaDeProdutividade.Application.UseCases.Usuario.Cadastrar;
using SistemaDeProdutividade.Application.UseCases.Usuario.Logar;
using SistemaDeProdutividade.Domain.Contracts;

namespace SistemaDeProdutividade.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services) 
    {
        AddEntityMappingService(services);
        AddUseCases(services);
        AddCrossOrigin(services);
        AddADService(services);
    }
    private static void AddEntityMappingService(IServiceCollection services) 
    {
        services.AddScoped<IRequestEntityMapperService, EntityMapperService>();
    }
    private static void AddUseCases(IServiceCollection services) 
    {
        services.AddScoped<ICadastrarUsuarioUseCase, CadastrarUsuarioUseCase>();
        services.AddScoped<ILogarUsuarioUseCase, LogarUsuarioUseCase>();
    }
    private static void AddCrossOrigin(IServiceCollection services) 
    {
        services.AddCors(options => options.AddPolicy("wasm", policy =>
         policy.WithOrigins([Configuration.BackendUrl, Configuration.FrontendUrl]).AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
    }
    private static void AddADService(IServiceCollection services)
    {
        services.AddTransient<ADService>();
    }

}
