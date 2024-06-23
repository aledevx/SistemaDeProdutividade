using SistemaDeProdutividade.Communication.DTOs.Atividades;

namespace SistemaDeProdutividade.Communication.Requests.Produtividades;
public record CadastrarProdutividadeRequestJson(string Cargo, IList<AtividadeDTO> Atividades);
