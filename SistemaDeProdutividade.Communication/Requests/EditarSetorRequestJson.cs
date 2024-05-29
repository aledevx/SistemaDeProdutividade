namespace SistemaDeProdutividade.Communication.Requests;
public record EditarSetorRequestJson(string Nome, string TipoSetor, Guid SetorSuperiorId, Guid ChefeId, Guid AssinanteResponsavelId);