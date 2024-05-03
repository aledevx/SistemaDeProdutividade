using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Usuario;
using SistemaDeProdutividade.Exception;
using SistemaDeProdutividade.Exception.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Application.UseCases.Usuario.Cadastrar;
public class CadastrarUsuarioUseCase : ICadastrarUsuarioUseCase
{
    private readonly IUsuarioReadOnlyRepository _readOnlyRepository;
    private readonly IUsuarioWriteOnlyRepository _writeOnlyRepository;
    private readonly IRequestEntityMapperService _mappingEntity;
    public CadastrarUsuarioUseCase(IUsuarioReadOnlyRepository readOnlyRepository,
        IUsuarioWriteOnlyRepository writeOnlyRepository, 
        IRequestEntityMapperService mappingEntity)
    {
        _readOnlyRepository = readOnlyRepository;
        _writeOnlyRepository = writeOnlyRepository;
        _mappingEntity = mappingEntity;
    }
    public async Task<MensagemSucessoCadastroResponseJson> Execute(CadastrarUsuarioRequestJson request) 
    {
        await Validate(request);

        var user = _mappingEntity.MappingToUsuario(request);

        await _writeOnlyRepository.Add(user);

        return new MensagemSucessoCadastroResponseJson("Teste");

    }
    private async Task Validate(CadastrarUsuarioRequestJson request) 
    {
        var validator = new CadastrarUsuarioValidator();

        var result = validator.Validate(request);

       var cpfExist = await _readOnlyRepository.ExisteUsuarioCpf(request.Cpf);

        if (cpfExist)
        {
            result.Errors.Add(new FluentValidation
                .Results
                .ValidationFailure(string.Empty, ResourceMessagesException.CPF_ALREADY_REGISTERED));
        }

        if (result.IsValid == false) 
        {
            var errorMessages = result.Errors.Select(r => r.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}   
