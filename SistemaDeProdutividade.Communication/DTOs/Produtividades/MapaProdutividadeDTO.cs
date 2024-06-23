using SistemaDeProdutividade.Communication.DTOs.Atividades;

namespace SistemaDeProdutividade.Communication.DTOs.Produtividades;
public record MapaProdutividadeDTO(string NomeUsuario, string MatriculaUsuario, string CargoUsuario, string Periodo,
    ICollection<AtividadePontuadaDTO> Atividades);
