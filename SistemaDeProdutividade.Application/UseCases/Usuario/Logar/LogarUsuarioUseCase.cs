using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Usuario;
using SistemaDeProdutividade.Exception;
using SistemaDeProdutividade.Exception.ExceptionsBase;

namespace SistemaDeProdutividade.Application.UseCases.Usuario.Logar;
public class LogarUsuarioUseCase : ILogarUsuarioUseCase
{
    private readonly IUsuarioReadOnlyRepository _readOnlyRepository;
    public LogarUsuarioUseCase(IUsuarioReadOnlyRepository readOnlyRepository)
    {
        _readOnlyRepository = readOnlyRepository;
    }
    public async Task<UsuarioResponseJson> Execute(LoginRequestJson request)
    {
        await Validate(request);

        var userData = _readOnlyRepository.BuscarUsuarioCpf(request.Cpf);

        return new UsuarioResponseJson(userData.Result.Cpf, userData.Result.Nome, userData.Result.Perfil);
    }
    private async Task Validate(LoginRequestJson request)
    {
        var validator = new LogarUsuarioValidator();

        var result = validator.Validate(request);

        if (result.IsValid) 
        {
            var userExists = await _readOnlyRepository.ExisteUsuarioCpf(request.Cpf);

            if (!userExists)
            {
                var errorMessage = ResourceMessagesException.USER_NOT_FOUND;

                throw new NotFoundException(errorMessage);
            }
        }else
        {
            var errorMessages = result.Errors.Select(r => r.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
