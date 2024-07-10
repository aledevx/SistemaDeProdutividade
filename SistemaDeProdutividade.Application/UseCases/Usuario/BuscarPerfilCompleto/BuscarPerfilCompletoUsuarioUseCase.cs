using SistemaDeProdutividade.Communication.Responses.Usuarios;
using SistemaDeProdutividade.Domain.Constants;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Usuario;
using SistemaDeProdutividade.Exception;
using SistemaDeProdutividade.Exception.ExceptionsBase;

namespace SistemaDeProdutividade.Application.UseCases.Usuario.BuscarPerfilCompleto;
public class BuscarPerfilCompletoUsuarioUseCase : IBuscarPerfilCompletoUsuarioUseCase
{
    private readonly IUsuarioReadOnlyRepository _readOnlyRepository;
    public BuscarPerfilCompletoUsuarioUseCase(IUsuarioReadOnlyRepository readOnlyRepository)
    {
        _readOnlyRepository = readOnlyRepository;
    }
    public async Task<PerfilUsuarioResponseJson> Execute(string cpfUserLogado, Guid id)
    {
        await Validate(cpfUserLogado, id);

        var perfilUsuario = await _readOnlyRepository.BuscarPerfilCompletoComProd(id);


        return perfilUsuario;
    }
    private async Task Validate(string cpfUserLogado, Guid id)
    {
        var usuarioLogado = await _readOnlyRepository.BuscarUsuarioCpf(cpfUserLogado);

        var errors = new List<string>();

        if (usuarioLogado is null)
        {
            errors.Add(ResourceMessagesException.CPF_INVALID);
        }
        else 
        {
            var usuarioId = await _readOnlyRepository.BuscarIdUsuario(id);
            if (usuarioId != Guid.Empty) 
            {
                if (usuarioLogado.Perfil != Perfil.Admin ||
                    usuarioId != id)
                {
                    errors.Add(ResourceMessagesException.USER_UNAUTHORIZED);
                }
            }
        }

        if (errors.Any())
        {
            throw new ErrorOnValidationException(errors);
        }
    }
}
