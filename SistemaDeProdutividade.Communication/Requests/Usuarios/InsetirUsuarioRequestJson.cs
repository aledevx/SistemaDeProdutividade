namespace SistemaDeProdutividade.Communication.Requests.Usuarios;
public class InsetirUsuarioRequestJson
{
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public string Perfil { get; set; } = string.Empty;
}
