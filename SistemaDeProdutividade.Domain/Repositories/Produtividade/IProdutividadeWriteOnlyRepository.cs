using SistemaDeProdutividade.Domain.Entities;

namespace SistemaDeProdutividade.Domain.Repositories.Produtividade;
public interface IProdutividadeWriteOnlyRepository
{
    Task AddMapa(Entities.Produtividade mapaProdutividade);
    Task AddProd(ProdutividadeFeita prodFeita);
    void UpdateProd(ProdutividadeFeita prodFeita);
}
