using SistemaDeProdutividade.Communication.Enums;

namespace SistemaDeProdutividade.Communication.Requests.Setores;
public record CadastrarSetorRequestJson(string Nome, TipoSetor TipoSetor, Guid? SetorChefeId);
