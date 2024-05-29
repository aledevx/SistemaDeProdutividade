using System;
using System.Threading.Tasks;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Setor;

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
    public async Task Execute()
    {
        await Validate(request);
        
        var setor = _mappingEntity.MappingToSetor(request);

        await _setorWriteOnlyRepository.Editar(setor);

        return new MensagemSucessoCadastroResponseJson("Setor criado com sucesso!");
    }

    private bool Validate()
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
