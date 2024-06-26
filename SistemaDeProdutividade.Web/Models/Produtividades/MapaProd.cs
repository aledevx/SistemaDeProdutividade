namespace SistemaDeProdutividade.Web.Models.Produtividades;

public class MapaProd
{
    public Guid Id { get; set; }
    public string Cargo { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public IEnumerable<MapaAtividade> Atividades { get; set; } = [];
    public MapaProd(Guid id, string cargo, decimal valor)
    {
        Id = id;
        Cargo = cargo;
        Valor = valor;
    }
}
