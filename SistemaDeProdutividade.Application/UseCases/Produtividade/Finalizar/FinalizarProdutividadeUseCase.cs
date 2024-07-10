using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;
using SistemaDeProdutividade.Domain.Repositories.Usuario;

namespace SistemaDeProdutividade.Application.UseCases.Produtividade.Finalizar;
public class FinalizarProdutividadeUseCase : IFinalizarProdutividadeUseCase
{
    private readonly IProdutividadeWriteOnlyRepository _prodWriteOnlyRepository;
    private readonly IProdutividadeReadOnlyRepository _prodReadOnlyRepository;
    private readonly IRequestEntityMapperService _mappingEntity;
    private readonly IUsuarioReadOnlyRepository _userReadOnlyRepository;
    public FinalizarProdutividadeUseCase(IProdutividadeWriteOnlyRepository prodWriteOnlyRepository,
        IProdutividadeReadOnlyRepository prodReadOnlyRepository,
        IRequestEntityMapperService mappingEntity,
        IUsuarioReadOnlyRepository userReadOnlyRepository)
    {
        _prodWriteOnlyRepository = prodWriteOnlyRepository;
        _prodReadOnlyRepository = prodReadOnlyRepository;
        _mappingEntity = mappingEntity;
        _userReadOnlyRepository = userReadOnlyRepository;
    }
    public async Task<MensagemSucessoResponseJson> Execute(FinalizarProdutividadeRequestJson request)
    {
        var prodFeita = await _prodReadOnlyRepository.BuscarProdFeitaParaAtt(request.ProdId);

        if (request.status == Domain.Enums.StatusProdutividade.Devolvida)
        {
            if (!(string.IsNullOrWhiteSpace(request.Observacao)))
            {
                prodFeita.AddObservacao(request.Observacao);
            }
            prodFeita.Status = Domain.Enums.StatusProdutividade.Devolvida;
        }
        else if (request.status == Domain.Enums.StatusProdutividade.Finalizada)
        {
            prodFeita.Status = Domain.Enums.StatusProdutividade.Finalizada;
            prodFeita.Ativo = false;
        }

        _prodWriteOnlyRepository.UpdateProd(prodFeita);

        return new MensagemSucessoResponseJson("Operação concluída com sucesso");
    }
}
