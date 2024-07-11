using SistemaDeProdutividade.Communication.Requests.Usuarios;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Constants;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;
using SistemaDeProdutividade.Domain.Repositories.Setor;
using SistemaDeProdutividade.Domain.Repositories.Usuario;
using SistemaDeProdutividade.Exception;
using SistemaDeProdutividade.Exception.ExceptionsBase;

namespace SistemaDeProdutividade.Application.UseCases.Usuario.Lotar;
public class LotarUsuarioUseCase : ILotarUsuarioUseCase
{
    private readonly IUsuarioWriteOnlyRepository _usuarioWriteOnlyRepository;
    private readonly IUsuarioReadOnlyRepository _usuarioReadOnlyRepository;
    private readonly IRequestEntityMapperService _mapperService;
    private readonly ISetorReadOnlyRepository _setorReadOnlyRespository;
    private readonly ISetorWriteOnlyRepository _setorWriteOnlyRepository;
    private readonly IProdutividadeReadOnlyRepository _produtividadeReadOnlyRepository;
    public LotarUsuarioUseCase(IUsuarioWriteOnlyRepository writeOnlyRepository,
        IUsuarioReadOnlyRepository readOnlyRepository,
        IRequestEntityMapperService mapperService,
        ISetorReadOnlyRepository setorReadOnlyRepository,
        ISetorWriteOnlyRepository setorWriteOnlyRepository,
        IProdutividadeReadOnlyRepository produtividadeReadOnlyRepository)
    {
        _usuarioWriteOnlyRepository = writeOnlyRepository;
        _usuarioReadOnlyRepository = readOnlyRepository;
        _mapperService = mapperService;
        _setorReadOnlyRespository = setorReadOnlyRepository;
        _setorWriteOnlyRepository = setorWriteOnlyRepository;
        _produtividadeReadOnlyRepository = produtividadeReadOnlyRepository;
    }
    public async Task<MensagemSucessoCadastroResponseJson> Execute(Guid id,LotarUsuarioRequestJson request)
    {
        await Validate(id, request);

        var idUserLogado = _usuarioReadOnlyRepository.BuscarIdUsuario(request.cpfUsuarioLogado);
        var mapToLotacao = _mapperService.MappingToLotacao(id, request.SetorId, request.CargoId, idUserLogado);

        if (request.Perfil == Perfil.Chefe) 
        {
            var usuario = _usuarioReadOnlyRepository.BuscarUsuarioPorId(id).Result;
            _setorWriteOnlyRepository.AddChefeSetor(usuario, request.SetorId);
        }

        await _usuarioWriteOnlyRepository.LotarUsuario(mapToLotacao);

        return new MensagemSucessoCadastroResponseJson("Usuário lotado com sucesso");
    }
    private async Task Validate(Guid id, LotarUsuarioRequestJson request)
    {
        var errors = new List<string>();
        var setorExist = await _setorReadOnlyRespository.ExisteSetor(request.SetorId);
        if (setorExist is false) 
        {
            errors.Add(ResourceMessagesException.SETOR_NOT_FOUND);
        }
        var cargoExist = await _produtividadeReadOnlyRepository.ExisteCargo(request.CargoId);
        if (cargoExist is false) 
        {
            errors.Add(ResourceMessagesException.CARGO_NOT_FOUND);
        }
        var usuarioExist = await _usuarioReadOnlyRepository.ExisteUsuarioId(id);
        if (usuarioExist is false)
        {
            errors.Add(ResourceMessagesException.USER_NOT_FOUND);
        }
        var cpfExist = await _usuarioReadOnlyRepository.ExisteUsuarioCpf(request.cpfUsuarioLogado);
        if (cpfExist is false)
        {
            errors.Add(ResourceMessagesException.CPF_INVALID);
        }
        else 
        {
        var temPermissaoDeAdmin = await _usuarioReadOnlyRepository.TemPermissaoAdmin(request.cpfUsuarioLogado);

            if (temPermissaoDeAdmin is false) 
            {
                errors.Add(ResourceMessagesException.USER_UNAUTHORIZED);
            }
        }

        if (errors.Any())
        {
            throw new ErrorOnValidationException(errors);
        }
    }
}
