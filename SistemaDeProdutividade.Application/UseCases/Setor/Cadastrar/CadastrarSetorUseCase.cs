using SistemaDeProdutividade.Communication.Requests.Setores;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Setor;
using SistemaDeProdutividade.Exception;
using SistemaDeProdutividade.Exception.ExceptionsBase;

namespace SistemaDeProdutividade.Application.UseCases.Setor.Cadastrar;
public class CadastrarSetorUseCase : ICadastrarSetorUseCase
{
    private readonly ISetorWriteOnlyRepository _writeOnlyRepository;
    private readonly ISetorReadOnlyRepository _readOnlyRepository;
    private readonly IRequestEntityMapperService _mappingEntity;
    public CadastrarSetorUseCase(ISetorWriteOnlyRepository writeOnlyRepository,
        ISetorReadOnlyRepository readOnlyRepository,
        IRequestEntityMapperService mappingEntity)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _mappingEntity = mappingEntity;
    }

    public async Task<MensagemSucessoCadastroResponseJson> Execute(CadastrarSetorRequestJson request)
    {
        await Validate(request);
        var setor = _mappingEntity.MappingToSetor(request);

        await _writeOnlyRepository.Add(setor);

        return new MensagemSucessoCadastroResponseJson("Setor cadastrado com sucesso");
    }
    private async Task Validate(CadastrarSetorRequestJson request)
    {
        var validator = new CadastrarSetorValidator();

        var result = validator.Validate(request);

        var nomeExiste = await _readOnlyRepository.ExisteSetorNome(request.Nome);

        if (nomeExiste)
        {
            result.Errors.Add(new FluentValidation
                .Results
                .ValidationFailure(string.Empty, ResourceMessagesException.SETOR_ALREADY_REGISTERED));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(r => r.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
