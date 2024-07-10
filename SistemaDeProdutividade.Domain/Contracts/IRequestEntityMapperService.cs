using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Communication.Requests.Setores;
using SistemaDeProdutividade.Domain.Entities;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface IRequestEntityMapperService
{
    Usuario MappingToUsuario(CadastrarUsuarioRequestJson request);
    Produtividade MappingToProdutividadeMapa(CadastrarProdutividadeRequestJson request);
    Setor MappingToSetor(CadastrarSetorRequestJson request);
    Lotacao MappingToLotacao(Guid usuarioId, Guid setorId, Guid cargoId, Guid usuarioQueLotouId);
    Assinatura MappingToAssinatura(string nomeUsuario, string cargo, Guid usuarioId);
    ProdutividadeFeita MappingToProdFeita(string codigo,
        string nomeUsuario,
        string matriculaUsuario,
        string cargoUsuario,
        string setorLotado,
        Guid usuarioId,
        decimal valorDaProdutividade);
}
