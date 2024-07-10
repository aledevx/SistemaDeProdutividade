using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Communication.ViewModel.Produtividades;
using SistemaDeProdutividade.Domain.Constants;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;
using SistemaDeProdutividade.Domain.Repositories.Setor;
using SistemaDeProdutividade.Domain.Repositories.Usuario;

namespace SistemaDeProdutividade.Application.UseCases.Produtividade.Index;
public class IndexProdutividadesFeitasUseCase : IIndexProdutividadesFeitasUseCase
{
    private readonly IUsuarioReadOnlyRepository _userReadOnlyRepository;
    private readonly IProdutividadeReadOnlyRepository _prodReadOnlyRepository;
    private readonly ISetorReadOnlyRepository _setorReadOnlyRepository;
    public IndexProdutividadesFeitasUseCase(IUsuarioReadOnlyRepository userReadOnlyRepository,
        IProdutividadeReadOnlyRepository prodReadOnlyRepository, ISetorReadOnlyRepository setorReadOnlyRepository)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _prodReadOnlyRepository = prodReadOnlyRepository;
        _setorReadOnlyRepository = setorReadOnlyRepository;
    }
    public async Task<ProdsFeitasResponseJson> Execute(string cpfUsuarioLogado)
    {
        var usuario = await _userReadOnlyRepository.BuscarUsuarioCpf(cpfUsuarioLogado);
        var prodsRecebidas = await _prodReadOnlyRepository.BuscarProdutividadesFeitas();

        var lotacaoUserLogado = await _userReadOnlyRepository.LotacaoAtual(usuario.Id);

        var lotacaoAtualComIds = await _userReadOnlyRepository.LotacaoAtualComIds(usuario.Id);

        if (usuario.Perfil == Perfil.Chefe)
        {
            var setoresSubordinados = await _setorReadOnlyRepository.BuscarSetoresSubordinados(lotacaoAtualComIds.SetorId);

            var idsChefesSubordinados = setoresSubordinados.Select(s => s.ChefeId).ToList();

            var result = prodsRecebidas.Prods.Where(p =>
             p.Lotacao.Trim().ToLower() == lotacaoUserLogado.SetorNome.Trim().ToLower() || 
             idsChefesSubordinados.Contains(p.UsuarioId)).Select(p => new ProdFeitaIndexVM(p.Id,
             0,
             p.Codigo,
             p.NomeUsuario,
             p.Cargo,
             p.Matricula,
             p.Lotacao, p.DataCriacao, p.Status, p.UsuarioId)).ToList();

            return new ProdsFeitasResponseJson(result);

        }
        else if (usuario.Perfil == Perfil.Admin)
        {
            var result = prodsRecebidas.Prods.Select(p => new ProdFeitaIndexVM(p.Id,
            0,
            p.Codigo,
            p.NomeUsuario,
            p.Cargo,
            p.Matricula,
            p.Lotacao, p.DataCriacao, p.Status, p.UsuarioId)).ToList();

            return new ProdsFeitasResponseJson(result);
        }

        return prodsRecebidas;
    }
}
