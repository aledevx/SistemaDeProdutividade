using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;
using SistemaDeProdutividade.Exception;
using SistemaDeProdutividade.Exception.ExceptionsBase;

namespace SistemaDeProdutividade.Application.UseCases.Produtividade.CadastrarMapa;
public class CadastrarMapaProdutividadeUseCase : ICadastrarMapaProdutividadeUseCase
{
    private readonly IProdutividadeReadOnlyRepository _readOnlyRepository;
    private readonly IProdutividadeWriteOnlyRepository _writeOnlyRepository;
    private readonly IRequestEntityMapperService _mappingEntity;
    public CadastrarMapaProdutividadeUseCase(IProdutividadeReadOnlyRepository readOnlyRepository,IProdutividadeWriteOnlyRepository writeOnlyRepository, IRequestEntityMapperService mappingEntity)
    {
        _readOnlyRepository = readOnlyRepository;
        _writeOnlyRepository = writeOnlyRepository;
        _mappingEntity = mappingEntity;
    }
    public async Task<MensagemSucessoCadastroResponseJson> Execute(CadastrarProdutividadeRequestJson request)
    {
        await Validate(request);

        var data = _mappingEntity.MappingToProdutividadeMapa(request);
        await _writeOnlyRepository.AddMapa(data);
        return new MensagemSucessoCadastroResponseJson("Mapa de produtividade cadastrado com sucesso!");
    }
    private async Task Validate(CadastrarProdutividadeRequestJson request)
    {
        var validator = new CadastrarMapaProdutividadeValidator();

        var result = validator.Validate(request);

        var cargoExits = await _readOnlyRepository.ExisteMapaProdCadastrado(request.Cargo);

        if (cargoExits)
        {
            result.Errors.Add(new FluentValidation
                .Results
                .ValidationFailure(string.Empty, ResourceMessagesException.CARGO_ALREADY_REGISTERED));
        }

        if (!(request.Atividades.Any())) 
        {
            result.Errors.Add(new FluentValidation
                .Results
                .ValidationFailure(string.Empty, ResourceMessagesException.ATIVIDADE_NOT_NULL));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(r => r.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

}
