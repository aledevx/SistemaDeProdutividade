namespace SistemaDeProdutividade.Web.Models.Setores;

public class SetorIndex
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public SetorIndex(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}
