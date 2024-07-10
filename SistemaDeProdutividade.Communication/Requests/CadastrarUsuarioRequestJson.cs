namespace SistemaDeProdutividade.Communication.Requests;
public record CadastrarUsuarioRequestJson(string Nome, string Matricula, string Cpf, string Perfil, string CpfUsuarioLogado, Guid CargoId, Guid SetorId);
