using SistemaDeProdutividade.Domain.Enums;

namespace SistemaDeProdutividade.Communication.Requests.Produtividades;
public record FinalizarProdutividadeRequestJson(Guid ProdId, string? Observacao, string CpfUsuarioLogado, StatusProdutividade status);
