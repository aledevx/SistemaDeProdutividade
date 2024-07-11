namespace SistemaDeProdutividade.Communication.Requests.Usuarios;
public record LotarUsuarioRequestJson(Guid SetorId, Guid CargoId, string cpfUsuarioLogado, string Perfil);
