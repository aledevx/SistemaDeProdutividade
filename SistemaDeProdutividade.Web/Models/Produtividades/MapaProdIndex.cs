namespace SistemaDeProdutividade.Web.Models.Produtividades;

public class MapaProdIndex
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public MapaProdIndex(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}
