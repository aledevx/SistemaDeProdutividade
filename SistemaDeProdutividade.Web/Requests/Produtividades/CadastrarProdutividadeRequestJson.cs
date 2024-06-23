using SistemaDeProdutividade.Web.DTOs.Atividades;

namespace SistemaDeProdutividade.Web.Requests.Produtividades;

public record CadastrarProdutividadeRequestJson(string Cargo, IList<AtividadeDTO> Atividades);
