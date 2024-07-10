namespace SistemaDeProdutividade.Domain.Entities;
public class Assinatura
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public Guid UsuarioId { get; set; }
    public Guid ProdutividadeFeitaId { get; set; }
    public DateTime DataAssinatura { get; set; } = DateTime.Now;
    public bool Ativo { get; set; } = true; // DESATIVAR QUANDO A PROD NÃO FOR ACEITA, DEVOLVIDA PELO ADMIN NO CASO
    public Assinatura()
    {
        
    }
    public Assinatura(string nomeUsuairo, string cargoUsuario, Guid usuarioId)
    {
        Nome = nomeUsuairo;
        Cargo = cargoUsuario;
        UsuarioId = usuarioId;
    }
}
