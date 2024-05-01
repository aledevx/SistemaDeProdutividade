using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Application.UseCases.Usuarios.CadastrarUsuario;
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
        Validate(request);

        var user = _mappingEntity.MappingToUsuario(request);

        await _writeOnlyRepository.Add(user);

        return new MensagemSucessoCadastroResponseJson("Teste");

    }
    private void Validate(CadastrarUsuarioRequestJson request) 
    {

    }
}   
