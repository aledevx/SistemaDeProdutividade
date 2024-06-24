namespace SistemaDeProdutividade.Web.Requests;

public class InserirUsuarioRequestJson
{
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public string Perfil { get; set; } = string.Empty;
}
