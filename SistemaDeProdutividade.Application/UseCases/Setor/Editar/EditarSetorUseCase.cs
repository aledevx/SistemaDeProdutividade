using System;
using System.Threading.Tasks;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Setor;
using SistemaDeProdutividade.Exception.ExceptionsBase;

namespace SistemaDeProdutividade.Application.UseCases.Setor.Editar;

public class EditarSetorUseCase : IEditarSetorUseCase
{
    private readonly ISetorWriteOnlyRepository _setorWriteOnlyRepository;
    private readonly IRequestEntityMapperService _mappingEntity;

    public EditarSetorUseCase(ISetorWriteOnlyRepository setorWriteOnlyRepository, IRequestEntityMapperService mappingEntity)
    {
        _setorWriteOnlyRepository = setorWriteOnlyRepository;
        _mappingEntity = mappingEntity;
    }
    public async Task<MensagemSucessoResponseJson> Execute(EditarSetorRequestJson request)
    {
        await Validate(request);
        
        var setor = _mappingEntity.MappingToSetorEdit(request);

        await _setorWriteOnlyRepository.Editar(setor);

        return new MensagemSucessoResponseJson("Setor editado com sucesso!");
    }    

    private async Task Validate(EditarSetorRequestJson request)
    {
        var validator = new EditarSetorValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false) 
        {
            var errorMessages = result.Errors.Select(r => r.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
