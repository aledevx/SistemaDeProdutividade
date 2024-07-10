using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Constants;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;
using SistemaDeProdutividade.Domain.Repositories.Setor;
using SistemaDeProdutividade.Domain.Repositories.Usuario;
using SistemaDeProdutividade.Exception;
using SistemaDeProdutividade.Exception.ExceptionsBase;

namespace SistemaDeProdutividade.Application.UseCases.Usuario.Cadastrar;
public class CadastrarUsuarioUseCase : ICadastrarUsuarioUseCase
{
    private readonly IUsuarioReadOnlyRepository _readOnlyRepository;
    private readonly IUsuarioWriteOnlyRepository _writeOnlyRepository;
    private readonly ISetorReadOnlyRepository _setorReadOnlyRepository;
    private readonly ISetorWriteOnlyRepository _setorWriteOnlyRepository;
    private readonly IProdutividadeReadOnlyRepository _produtividadeReadOnlyRepository;
    private readonly IRequestEntityMapperService _mappingEntity;
    public CadastrarUsuarioUseCase(IUsuarioReadOnlyRepository readOnlyRepository,
        IUsuarioWriteOnlyRepository writeOnlyRepository, 
        ISetorReadOnlyRepository setorReadOnlyRepository,
        ISetorWriteOnlyRepository setorWriteOnlyRepository,
        IProdutividadeReadOnlyRepository produtividadeReadOnlyRepository,
        IRequestEntityMapperService mappingEntity)
    {
        _readOnlyRepository = readOnlyRepository;
        _writeOnlyRepository = writeOnlyRepository;
        _setorReadOnlyRepository = setorReadOnlyRepository;
        _setorWriteOnlyRepository = setorWriteOnlyRepository;
        _produtividadeReadOnlyRepository = produtividadeReadOnlyRepository;
        _mappingEntity = mappingEntity;
    }
    public async Task<MensagemSucessoCadastroResponseJson> Execute(CadastrarUsuarioRequestJson request) 
    {
        await Validate(request);

        var user = _mappingEntity.MappingToUsuario(request);

        var usuarioLogadoId = _readOnlyRepository.BuscarIdUsuario(request.CpfUsuarioLogado);

        await _writeOnlyRepository.Add(user);

        if (user.Perfil == Perfil.Chefe)
        {
            _setorWriteOnlyRepository.AddChefeSetor(user, request.SetorId);            
        }

        var lotacao = _mappingEntity.MappingToLotacao(user.Id, request.SetorId, request.CargoId, usuarioLogadoId);

        await _writeOnlyRepository.LotarUsuario(lotacao);

        return new MensagemSucessoCadastroResponseJson("Usuario cadastrado com sucesso!");

    }
    private async Task Validate(CadastrarUsuarioRequestJson request) 
    {
        var validator = new CadastrarUsuarioValidator();
        var result = validator.Validate(request);
        var cpfIsValid = ValidarCpf(request.Cpf);
        var cpfExist = await _readOnlyRepository.ExisteUsuarioCpf(request.Cpf);
        var usuarioDaRequest = _readOnlyRepository.BuscarUsuarioCpf(request.CpfUsuarioLogado);

        if (!cpfIsValid)
        {
            result.Errors.Add(new FluentValidation
                .Results
                .ValidationFailure(string.Empty, ResourceMessagesException.CPF_INVALID));
        }

        if (request.Perfil != Perfil.Chefe && 
            request.Perfil != Perfil.Servidor &&
            request.Perfil != Perfil.Admin) 
        {
            result.Errors.Add(new FluentValidation
               .Results
               .ValidationFailure(string.Empty, ResourceMessagesException.PERFIL_INVALID));
        }

        if (usuarioDaRequest.Result.Perfil != Perfil.Admin) 
        {
            result.Errors.Add(new FluentValidation
               .Results
               .ValidationFailure(string.Empty, ResourceMessagesException.USER_UNAUTHORIZED));
        }

        var setorExist = await _setorReadOnlyRepository.ExisteSetor(request.SetorId);
        if (!setorExist) 
        {
            result.Errors.Add(new FluentValidation
            .Results
            .ValidationFailure(string.Empty, ResourceMessagesException.SETOR_NOT_FOUND));
        }

        var cargoExist = await _produtividadeReadOnlyRepository.ExisteCargo(request.CargoId);
        if (!cargoExist)
        {
            result.Errors.Add(new FluentValidation
            .Results
            .ValidationFailure(string.Empty, ResourceMessagesException.CARGO_NOT_FOUND));
        }

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
    private static bool ValidarCpf(string cpf) 
    {
        if (cpf.Length != 11)
            return false;

        for (int i = 0; i < cpf.Length; i++)
            if (!char.IsDigit(cpf[i]))
                return false;

        int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf.Substring(0, 9);
        int sum = 0;

        for (int i = 0; i < 9; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

        int remainder = sum % 11;
        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;

        string digit = remainder.ToString();
        tempCpf = tempCpf + digit;
        sum = 0;

        for (int i = 0; i < 10; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

        remainder = sum % 11;
        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;

        digit = digit + remainder.ToString();

        return cpf.EndsWith(digit);
    }
}   
