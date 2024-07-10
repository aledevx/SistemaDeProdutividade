using Microsoft.Extensions.DependencyInjection;
using SistemaDeProdutividade.Application.Services.AD;
using SistemaDeProdutividade.Application.Services.EntityMapper;
using SistemaDeProdutividade.Application.Services.Formatador;
using SistemaDeProdutividade.Application.Services.Produtividade;
using SistemaDeProdutividade.Application.UseCases.Produtividade.Assinar;
using SistemaDeProdutividade.Application.UseCases.Produtividade.BuscarTodosCargos;
using SistemaDeProdutividade.Application.UseCases.Produtividade.CadastrarMapa;
using SistemaDeProdutividade.Application.UseCases.Produtividade.CadastrarProdutividadePontuada;
using SistemaDeProdutividade.Application.UseCases.Produtividade.Finalizar;
using SistemaDeProdutividade.Application.UseCases.Produtividade.Index;
using SistemaDeProdutividade.Application.UseCases.Produtividade.Mapas;
using SistemaDeProdutividade.Application.UseCases.Produtividade.Minhas;
using SistemaDeProdutividade.Application.UseCases.Produtividade.Visualizar;
using SistemaDeProdutividade.Application.UseCases.Produtividade.VisualizarParaPontuar;
using SistemaDeProdutividade.Application.UseCases.Produtividade.VisualizarRecebidas;
using SistemaDeProdutividade.Application.UseCases.Setor.BuscarTodos;
using SistemaDeProdutividade.Application.UseCases.Setor.Cadastrar;
using SistemaDeProdutividade.Application.UseCases.Setor.Visualizar;
using SistemaDeProdutividade.Application.UseCases.Usuario.Buscar;
using SistemaDeProdutividade.Application.UseCases.Usuario.BuscarPerfilCompleto;
using SistemaDeProdutividade.Application.UseCases.Usuario.Cadastrar;
using SistemaDeProdutividade.Application.UseCases.Usuario.Logar;
using SistemaDeProdutividade.Application.UseCases.Usuario.Lotar;
using SistemaDeProdutividade.Domain.Contracts;

namespace SistemaDeProdutividade.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services) 
    {
        AddEntityMappingService(services);
        AddProdutividadeService(services);
        AddUseCases(services);
        AddCrossOrigin(services);
        AddADService(services);
        AddFormatadorService(services);
    }
    private static void AddEntityMappingService(IServiceCollection services) 
    {
        services.AddScoped<IRequestEntityMapperService, EntityMapperService>();
    }
    private static void AddProdutividadeService(IServiceCollection services) 
    {
        services.AddScoped<IProdutividadeService, ProdutividadeService>();
    }
    private static void AddUseCases(IServiceCollection services) 
    {
        services.AddScoped<ICadastrarUsuarioUseCase, CadastrarUsuarioUseCase>();
        services.AddScoped<ILogarUsuarioUseCase, LogarUsuarioUseCase>();
        services.AddScoped<IBuscarUsuariosUseCase, BuscarUsuariosUseCase>();
        services.AddScoped<ICadastrarMapaProdutividadeUseCase, CadastrarMapaProdutividadeUseCase>();
        services.AddScoped<ICadastrarSetorUseCase, CadastrarSetorUseCase>();
        services.AddScoped<IBuscarTodosSetorUseCase, BuscarTodosSetorUseCase>();
        services.AddScoped<IBuscarTodosCargosProdutividadeUseCase, BuscarTodosCargosProdutividadeUseCase>();
        services.AddScoped<IBuscarPerfilCompletoUsuarioUseCase, BuscarPerfilCompletoUsuarioUseCase>();
        services.AddScoped<ILotarUsuarioUseCase, LotarUsuarioUseCase>();
        services.AddScoped<IVisualizarParaPontuarProdutividadeUseCase, VisualizarParaPontuarProdutividadeUseCase>();
        services.AddScoped<ICadastrarProdutividadePontuadaUseCase, CadastrarProdutividadePontuadaUseCase>();
        services.AddScoped<IVisualizarProdutividadesRecebidasUseCase, VisualizarProdutividadesRecebidasUseCase>();
        services.AddScoped<IVisualizarProdutividadeFeitaUseCase, VisualizarProdutividadeFeitaUseCase>();
        services.AddScoped<IAssinarProdutividadeUseCase, AssinarProdutividadeUseCase>();
        services.AddScoped<IFinalizarProdutividadeUseCase, FinalizarProdutividadeUseCase>();
        services.AddScoped<IIndexProdutividadesFeitasUseCase, IndexProdutividadesFeitasUseCase>();
        services.AddScoped<IMinhasProdutividadeUseCase, MinhasProdutividadeUseCase>();
        services.AddScoped<IVisualizarSetorUseCase, VisualizarSetorUseCase>();
        services.AddScoped<IMapasProdutividadeUseCase, MapasProdutividadeUseCase>();
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
    private static void AddFormatadorService(IServiceCollection services)
    {
        services.AddTransient<FormatadorService>();
    }

}
