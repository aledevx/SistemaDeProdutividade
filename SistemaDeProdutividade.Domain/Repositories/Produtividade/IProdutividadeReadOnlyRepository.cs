using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Communication.ViewModel.Produtividades;
using SistemaDeProdutividade.Domain.Entities;

namespace SistemaDeProdutividade.Domain.Repositories.Produtividade;
public interface IProdutividadeReadOnlyRepository
{
    Task<bool> ExisteMapaProdCadastrado(string cargo);
    Task<bool> ExisteCargo(Guid cargoId);
    CargosResponseJson BuscarCargos();
    Task<MapaProdutividadeVM> BuscarMapaProd(string cargoNome);
    Task<bool> CodigoExist(string codigo);
    Task<bool> PeriodoInvalido(Guid usuarioId, DateTime dataInicio, DateTime dataFim);
    Task<bool> ExisteProdFeita(Guid prodFeitaId);
    Task<ProdsFeitasResponseJson> BuscarProdutividadesFeitas();
    Task<ProdutividadeFeitaResponseJson> VisualizarProdFeita(Guid prodFeitaId);
    Task<ProdutividadeFeita> BuscarProdFeitaParaAtt(Guid prodFeitaId);
    Task<ProdsFeitasResponseJson> BuscarMinhasProds(Guid usuarioId);
    Task<List<MapaProdIndexVM>> BuscarMapas();
}
