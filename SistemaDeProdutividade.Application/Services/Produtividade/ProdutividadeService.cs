using SistemaDeProdutividade.Communication.DTOs.Atividades;
using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;
using SistemaDeProdutividade.Domain.Repositories.Usuario;

namespace SistemaDeProdutividade.Application.Services.Produtividade;
public class ProdutividadeService : IProdutividadeService
{
    private readonly IProdutividadeReadOnlyRepository _prodReadOnlyRepository;
    private readonly IUsuarioReadOnlyRepository _userReadOnlyRepository;
    public ProdutividadeService(IProdutividadeReadOnlyRepository prodReadOnlyRepository,
        IUsuarioReadOnlyRepository userReadOnlyRepository)
    {
        _prodReadOnlyRepository = prodReadOnlyRepository;
        _userReadOnlyRepository = userReadOnlyRepository;
    }
    public async Task<ProdutividadeFeitaResponseJson> FazerProdutividade(string cpf)
    {
        var userId = _userReadOnlyRepository.BuscarIdUsuario(cpf);
        var userData = await _userReadOnlyRepository.BuscarPerfilCompletoSemProd(userId);
        var mapaProd = await _prodReadOnlyRepository.BuscarMapaProd(userData.Cargo);
        var codigo = GerarCodigo();
        var codigoExist = await _prodReadOnlyRepository.CodigoExist(codigo);
        while (codigoExist is true) 
        {
            codigo = GerarCodigo();
            codigoExist = await _prodReadOnlyRepository.CodigoExist(codigo);
        }

        var result = new ProdutividadeFeitaResponseJson(codigo,
            userData.Nome,
            userData.Matricula,
            userData.Cargo, 
            userData.Setor,
            userId, 
            mapaProd.ValorProd);

        result.Status = Domain.Enums.StatusProdutividade.EmCriacao;

        foreach (var item in mapaProd.Atividades) 
        {
            var atividPontDto = new AtividadePontuadaDTO(item.Descricao, item.Pontuacao, 00);
            result.AddAtividade(atividPontDto);
        }

        return result;

    }

    public string GerarCodigo()
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public decimal CalcularPercentualValorProd(int percent, decimal valorProd) 
    {
        var result = (valorProd / 100) * percent;
        return result;
    }
}
