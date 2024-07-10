using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Usuario;
using SistemaDeProdutividade.Exception;
using SistemaDeProdutividade.Exception.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Application.UseCases.Produtividade.VisualizarParaPontuar;
public class VisualizarParaPontuarProdutividadeUseCase : IVisualizarParaPontuarProdutividadeUseCase
{
    private readonly IProdutividadeService _produtividadeService;
    private readonly IUsuarioReadOnlyRepository _usuarioReadOnlyRepository;
    public VisualizarParaPontuarProdutividadeUseCase(IProdutividadeService produtividadeService,
        IUsuarioReadOnlyRepository usuarioReadOnlyRepository)
    {
        _produtividadeService = produtividadeService;
        _usuarioReadOnlyRepository = usuarioReadOnlyRepository;
    }
    public async Task<ProdutividadeFeitaResponseJson> Execute(string cpf)
    {
        await Validate(cpf);

        var result = _produtividadeService.FazerProdutividade(cpf).Result;

        return result;
    }
    private async Task Validate(string cpf)
    {
        var errors = new List<string>();
        var existLotacao = await _usuarioReadOnlyRepository.ExistLotacaoUsuario(cpf);
        if (existLotacao is false) 
        {
            errors.Add(ResourceMessagesException.LOTACAO_NOT_FOUND);
        }

        if (errors.Any()) 
        {
            throw new ErrorOnValidationException(errors);
        }
    }
}
