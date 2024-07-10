using SistemaDeProdutividade.Application.Services.Produtividade;
using SistemaDeProdutividade.Communication.Requests.Assinaturas;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;
using SistemaDeProdutividade.Domain.Repositories.Usuario;

namespace SistemaDeProdutividade.Application.UseCases.Produtividade.Assinar;
public class AssinarProdutividadeUseCase : IAssinarProdutividadeUseCase
{
    private readonly IProdutividadeService _produtividadeService;
    private readonly IProdutividadeWriteOnlyRepository _prodWriteOnlyRepository;
    private readonly IProdutividadeReadOnlyRepository _prodReadOnlyRepository;
    private readonly IRequestEntityMapperService _mappingEntity;
    private readonly IUsuarioReadOnlyRepository _userReadOnlyRepository;
    public AssinarProdutividadeUseCase(IProdutividadeService produtividadeService,
        IProdutividadeWriteOnlyRepository prodWriteOnlyRepository,
        IProdutividadeReadOnlyRepository prodReadOnlyRepository,
        IRequestEntityMapperService mappingEntity,
        IUsuarioReadOnlyRepository userReadOnlyRepository)
    {
        _produtividadeService = produtividadeService;
        _prodWriteOnlyRepository = prodWriteOnlyRepository;
        _prodReadOnlyRepository = prodReadOnlyRepository;
        _mappingEntity = mappingEntity;
        _userReadOnlyRepository = userReadOnlyRepository;
    }
    public async Task<MensagemSucessoResponseJson> Execute(AssinarProdutividadeRequestJson request)
    {
        var prodFeita = await _prodReadOnlyRepository.BuscarProdFeitaParaAtt(request.ProdId);

        var assinanteId = _userReadOnlyRepository.BuscarIdUsuario(request.CpfAssinante);
        var dadosDoAssinante = await _userReadOnlyRepository.BuscarPerfilCompletoSemProd(assinanteId);

        var assinatura = _mappingEntity.MappingToAssinatura(dadosDoAssinante.Nome, dadosDoAssinante.Cargo, assinanteId);

        prodFeita.Status = Domain.Enums.StatusProdutividade.AguardandoRh;

        prodFeita.ValorDaProdutividade = _produtividadeService.CalcularPercentualValorProd(request.Percentual, prodFeita.ValorDaProdutividade);

        prodFeita.Assinaturas.Add(assinatura);

        _prodWriteOnlyRepository.UpdateProd(prodFeita);

        return new MensagemSucessoResponseJson("Produtividade assinada com sucesso");
    }
}
