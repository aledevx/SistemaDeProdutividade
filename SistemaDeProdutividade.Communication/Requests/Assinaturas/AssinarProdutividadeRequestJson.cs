namespace SistemaDeProdutividade.Communication.Requests.Assinaturas;
public record AssinarProdutividadeRequestJson(Guid ProdId, string CpfAssinante, int Percentual);
