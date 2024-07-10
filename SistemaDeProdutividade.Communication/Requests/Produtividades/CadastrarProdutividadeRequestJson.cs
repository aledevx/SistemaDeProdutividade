using SistemaDeProdutividade.Communication.DTOs.Atividades;

namespace SistemaDeProdutividade.Communication.Requests.Produtividades;
public record CadastrarProdutividadeRequestJson(string Cargo, decimal Valor, List<AtividadeDTO> Atividades);
