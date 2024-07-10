using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;
using SistemaDeProdutividade.Domain.Repositories.Setor;
using SistemaDeProdutividade.Domain.Repositories.Usuario;

namespace SistemaDeProdutividade.Application.UseCases.Produtividade.Minhas;
public class MinhasProdutividadeUseCase : IMinhasProdutividadeUseCase
{
    private readonly IUsuarioReadOnlyRepository _userReadOnlyRepository;
    private readonly IProdutividadeReadOnlyRepository _prodReadOnlyRepository;
    public MinhasProdutividadeUseCase(IUsuarioReadOnlyRepository userReadOnlyRepository,
        IProdutividadeReadOnlyRepository prodReadOnlyRepository)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _prodReadOnlyRepository = prodReadOnlyRepository;
    }

    public async Task<ProdsFeitasResponseJson> Execute(string cpfUsuarioLogado)
    {
        var usuarioId = _userReadOnlyRepository.BuscarIdUsuario(cpfUsuarioLogado);

        var prods = await _prodReadOnlyRepository.BuscarMinhasProds(usuarioId);

        return prods;

    }
}
