using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Entities;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;
using SistemaDeProdutividade.Exception;
using SistemaDeProdutividade.Exception.ExceptionsBase;

namespace SistemaDeProdutividade.Application.UseCases.Produtividade.CadastrarProdutividadePontuada;
public class CadastrarProdutividadePontuadaUseCase : ICadastrarProdutividadePontuadaUseCase
{
    private readonly IProdutividadeReadOnlyRepository _prodReadOnlyRepository;
    private readonly IProdutividadeWriteOnlyRepository _prodWriteOnlyRepository;
    private readonly IRequestEntityMapperService _mappingEntity;
    public CadastrarProdutividadePontuadaUseCase(IProdutividadeReadOnlyRepository prodReadOnlyRepository,
        IProdutividadeWriteOnlyRepository writeOnlyRepository,
        IRequestEntityMapperService mappingEntity)
    {
        _prodReadOnlyRepository = prodReadOnlyRepository;
        _prodWriteOnlyRepository = writeOnlyRepository;
        _mappingEntity = mappingEntity;
    }
    public async Task<MensagemSucessoCadastroResponseJson> Execute(ProdutividadeFeitaResponseJson request)
    {
        await Validate(request);

        var prodFeita = _mappingEntity.MappingToProdFeita(request.Codigo, 
            request.NomeUsuario, 
            request.MatriculaUsuario,
            request.CargoUsuario, 
            request.SetorLotado,
            request.UsuarioId,
            request.ValorDaProdutividade);

        prodFeita.AddPeriodo(request.DataInicio, request.DataFim);
        prodFeita.Status = Domain.Enums.StatusProdutividade.AguardandoAssinaturaChefe;

        foreach (var item in request.Atividades) 
        {
            var atividadePont = new AtividadePontuada(item.Descricao, item.Pontuacao, item.Qtd);
            prodFeita.Atividades.Add(atividadePont);
        }

        var assinatura = _mappingEntity.MappingToAssinatura(prodFeita.NomeUsuario,
            prodFeita.CargoUsuario, 
            prodFeita.UsuarioId);

        prodFeita.Assinaturas.Add(assinatura);

        await _prodWriteOnlyRepository.AddProd(prodFeita);

        return new MensagemSucessoCadastroResponseJson("Produtividade pontuada com sucesso");

    }
    private async Task Validate(ProdutividadeFeitaResponseJson request)
    {
        var errors = new List<string>();

        var periodoValido = await _prodReadOnlyRepository.PeriodoInvalido(request.UsuarioId, request.DataInicio, request.DataFim);

        if (periodoValido) 
        {
            errors.Add(ResourceMessagesException.PERIOD_INVALID);
        }

        if (errors.Any()) 
        {
            throw new ErrorOnValidationException(errors);
        }
    }
}
