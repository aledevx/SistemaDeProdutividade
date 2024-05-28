using System;
using System.Threading.Tasks;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Setor;
using SistemaDeProdutividade.Exception.ExceptionsBase;

namespace SistemaDeProdutividade.Application.UseCases.Setor.Criar;
public class CriarSetorUseCase : ICriarSetorUseCase
{
    private readonly ISetorWriteOnlyRepository _setorWriteOnlyRepository;
    private readonly IRequestEntityMapperService _mappingEntity;

    public CriarSetorUseCase(ISetorWriteOnlyRepository setorWriteOnlyRepository, IRequestEntityMapperService mappingEntity)
    {
        _setorWriteOnlyRepository = setorWriteOnlyRepository;
        _mappingEntity = mappingEntity;
    }
    public async Task<MensagemSucessoCadastroResponseJson> Execute(CriarSetorRequestJson request)
    {
        await Validate(request);
        
        var setor = _mappingEntity.MappingToSetor(request);

        await _setorWriteOnlyRepository.Add(setor);

        return new MensagemSucessoCadastroResponseJson("Setor criado com sucesso!");
    }

    private async Task Validate(CriarSetorRequestJson request)
    {
        var validator = new CriarSetorValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false) 
        {
            var errorMessages = result.Errors.Select(r => r.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
