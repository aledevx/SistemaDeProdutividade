using Microsoft.EntityFrameworkCore;
using SistemaDeProdutividade.Communication.DTOs.Assinaturas;
using SistemaDeProdutividade.Communication.DTOs.Atividades;
using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Communication.ViewModel.Atividades;
using SistemaDeProdutividade.Communication.ViewModel.Produtividades;
using SistemaDeProdutividade.Domain.Entities;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;

namespace SistemaDeProdutividade.Infrastructure.DataAccess.Repositories;
public class ProdutividadeRepository : IProdutividadeWriteOnlyRepository, IProdutividadeReadOnlyRepository
{
    private readonly ProdContext _prodContext;
    public ProdutividadeRepository(ProdContext prodContext)
    {
        _prodContext = prodContext;
    }

    public async Task AddMapa(Produtividade prodMapa)
    {
        await _prodContext.Produtividades.AddAsync(prodMapa);
        await _prodContext.SaveChangesAsync();

    }

    public async Task AddProd(ProdutividadeFeita prodFeita)
    {
        await _prodContext.ProdutividadesFeitas.AddAsync(prodFeita);
        await _prodContext.SaveChangesAsync();
    }

    public CargosResponseJson BuscarCargos()
    {
        var cargos = _prodContext.Cargos.Select(c => new CargoIndexVM(c.Id, c.Nome)).ToList();

        return new CargosResponseJson(cargos);
    }

    public async Task<MapaProdutividadeVM> BuscarMapaProd(string cargoNome)
    {
        var mapaProd = await _prodContext.Produtividades.Include(p => p.Cargo).Include(p => p.ValorProd).Include(p => p.Atividades)
                        .Where(c => c.Cargo!.Nome.Equals(cargoNome)).FirstOrDefaultAsync();

        var result = new MapaProdutividadeVM(mapaProd!.Cargo!.Nome, mapaProd.ValorProd!.Valor);

        var atividades = mapaProd.Atividades.Select(a => new AtividadeVM(a.Descricao, a.Pontuacao));

        foreach (var item in atividades) 
        {
            result.AddAtividade(item);
        }

        return result;
    }

    public async Task<bool> CodigoExist(string codigo)
    {
        var exist = await _prodContext.ProdutividadesFeitas.AnyAsync(p => p.Codigo.Equals(codigo));

        return exist;
    }

    public async Task<bool> ExisteCargo(Guid cargoId)
    {
        var exist = await _prodContext.Cargos.AnyAsync(c => c.Id == cargoId);
        return exist;
    }

    public async Task<bool> ExisteMapaProdCadastrado(string cargo)
    {
        return await _prodContext.Cargos.AnyAsync(c => c.Nome.ToLower().Trim().Equals(cargo.ToLower().Trim()));
    }

    public async Task<bool> ExisteProdFeita(Guid prodFeitaId)
    {
        var exist = await _prodContext.ProdutividadesFeitas.AnyAsync(p => p.Id == prodFeitaId);

        return exist;
    }

    public async Task<bool> PeriodoInvalido(Guid usuarioId, DateTime dataInicio, DateTime dataFim)
    {
        var periodInvalid = await _prodContext.ProdutividadesFeitas.Where(p => p.UsuarioId == usuarioId &&
             p.Ativo)
            .AnyAsync(p => dataInicio < p.DataFim &&
        dataFim > p.DataInicio);

        return periodInvalid;
    }

    public async Task<ProdsFeitasResponseJson> BuscarProdutividadesFeitas()
    {
        var prodsFeitas = await _prodContext.ProdutividadesFeitas
            .Where(p => p.Ativo)
            .Select(p => new ProdFeitaIndexVM(p.Id,
            0, 
            p.Codigo, 
            p.NomeUsuario, 
            p.CargoUsuario, 
            p.MatriculaUsuario, 
            p.SetorLotado, p.DataCriacao, p.Status, p.UsuarioId)).ToListAsync();

        return new ProdsFeitasResponseJson(prodsFeitas);
    }

    public void UpdateProd(ProdutividadeFeita prodFeita)
    {
        _prodContext.ProdutividadesFeitas.Update(prodFeita);
        _prodContext.SaveChanges();
    }

    public async Task<ProdutividadeFeitaResponseJson> VisualizarProdFeita(Guid prodFeitaId)
    {
        var prodFeita = await _prodContext.ProdutividadesFeitas.Include(p => p.Assinaturas)
            .Include(p => p.Atividades).FirstAsync(p => p.Id == prodFeitaId);

        var result = new ProdutividadeFeitaResponseJson(prodFeita.Codigo, 
            prodFeita.NomeUsuario,
            prodFeita.MatriculaUsuario,
            prodFeita.CargoUsuario,
            prodFeita.SetorLotado,
            prodFeita.UsuarioId,
            prodFeita.ValorDaProdutividade);

        result.AddStatus(prodFeita.Status);
        result.AddDatas(prodFeita.DataInicio, prodFeita.DataFim, prodFeita.DataCriacao);

        if (!(string.IsNullOrEmpty(prodFeita.Observacao))) 
        {
            result.AddObservacao(prodFeita.Observacao);
        }

        foreach (var item in prodFeita.Atividades) 
        {
            var atividadeDto = new AtividadePontuadaDTO(item.DescricaoAtividade, item.PontuacaoAtividade, item.QtdRealizada);
            result.Atividades.Add(atividadeDto);
        }

        foreach (var item in prodFeita.Assinaturas) 
        {
            if (item.Ativo) 
            {
                var assinaturaDto = new AssinaturaDTO(item.Nome, item.Cargo, item.DataAssinatura);
                result.Assinaturas.Add(assinaturaDto);
            }
        }

        return result;

    }
    public async Task<ProdutividadeFeita> BuscarProdFeitaParaAtt(Guid prodFeitaId)
    {
        var prodFeita = await _prodContext.ProdutividadesFeitas.FirstAsync(p => p.Id == prodFeitaId);

        return prodFeita;
    }

    public async Task<ProdsFeitasResponseJson> BuscarMinhasProds(Guid usuarioId)
    {
        var prods = await _prodContext.ProdutividadesFeitas
            .Where(p => p.UsuarioId == usuarioId)
            .Select(p => new ProdFeitaIndexVM(p.Id, 0, p.Codigo,
            p.NomeUsuario, p.CargoUsuario, p.MatriculaUsuario,
            p.SetorLotado, p.DataCriacao, p.Status, p.UsuarioId)).ToListAsync();

        var result = new ProdsFeitasResponseJson(prods);

        return result;
    }

    public async Task<List<MapaProdIndexVM>> BuscarMapas()
    {
        var mapas = await _prodContext.Produtividades
            .Include(p => p.Cargo)
            .Include(p => p.ValorProd)
            .Select(p => new MapaProdIndexVM(p.Id, p.Cargo!.Nome, p.ValorProd!.Valor))
            .ToListAsync();

        return mapas;
    }
}
