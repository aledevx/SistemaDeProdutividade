using SistemaDeProdutividade.Web.DTOs.Atividades;

namespace SistemaDeProdutividade.Web.DTOs.Produtividades;

public record MapaProdutividadeDTO(string NomeUsuario, string MatriculaUsuario, string CargoUsuario, string Periodo,
    ICollection<AtividadePontuadaDTO> Atividades);
