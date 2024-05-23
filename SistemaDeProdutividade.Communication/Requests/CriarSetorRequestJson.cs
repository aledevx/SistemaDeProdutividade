namespace SistemaDeProdutividade.Communication.Requests;
public record CriarSetorRequestJson(string Nome, string TipoSetor, Guid SetorSuperiorId, Guid ChefeId, Guid AssinanteResponsavelId);