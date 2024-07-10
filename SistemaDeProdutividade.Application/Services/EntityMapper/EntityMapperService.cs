using SistemaDeProdutividade.Application.Services.Formatador;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Communication.Requests.Setores;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Entities;

namespace SistemaDeProdutividade.Application.Services.EntityMapper;
public class EntityMapperService : IRequestEntityMapperService
{
    private readonly FormatadorService _formatador;
    public EntityMapperService(FormatadorService formatador)
    {
        _formatador = formatador;
    }
    public Domain.Entities.Produtividade MappingToProdutividadeMapa(CadastrarProdutividadeRequestJson request)
    {
        var cargo = new Cargo(_formatador.CapitalizarNome(request.Cargo));
        var valorProd = new ValorProd(request.Valor);
        var prodMapa = new Domain.Entities.Produtividade(cargo, valorProd);
        if (request.Atividades != null)
        {
            foreach (var atv in request.Atividades)
            {
                var atividade = new Atividade(atv.Descricao, atv.Pontuacao);
                prodMapa.AddAtividade(atividade);
            }
        }

        return prodMapa;
    }

    public Usuario MappingToUsuario(CadastrarUsuarioRequestJson request)
    {
        var usuario = new Usuario(_formatador.CapitalizarNome(request.Nome), request.Matricula, request.Cpf, request.Perfil);

        return usuario;
    }
    public Setor MappingToSetor(CadastrarSetorRequestJson request) 
    {
        var setor = new Setor(_formatador.CapitalizarNome(request.Nome), request.TipoSetor);

        if (!(request.SetorChefeId is null))
        {
            setor.SetorSuperiorId = request.SetorChefeId;
        }

        return setor;

    }
    public Lotacao MappingToLotacao(Guid usuarioId, Guid setorId, Guid cargoId, Guid usuarioQueLotouId) 
    {
        var lotacao = new Lotacao(usuarioId, setorId, cargoId, usuarioQueLotouId);

        return lotacao;
    }

    public Assinatura MappingToAssinatura(string nomeUsuario, string cargo, Guid usuarioId)
    {
        var assinatura = new Assinatura(nomeUsuario, cargo, usuarioId);

        return assinatura;
    }

    public ProdutividadeFeita MappingToProdFeita(string codigo,
        string nomeUsuario, 
        string matriculaUsuario, 
        string cargoUsuario, 
        string setorLotado, 
        Guid usuarioId, 
        decimal valorDaProdutividade)
    {
        var produtividadeFeita = new ProdutividadeFeita(codigo,
            nomeUsuario, 
            matriculaUsuario, 
            cargoUsuario,
            setorLotado, 
            usuarioId, 
            valorDaProdutividade);

        return produtividadeFeita;
    }
}
