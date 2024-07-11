namespace SistemaDeProdutividade.Web.DTOs;

public class UsuarioDto
{
    public Guid Id { get; set; }
    public string Cpf { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Perfil { get; set; } = string.Empty;
}
