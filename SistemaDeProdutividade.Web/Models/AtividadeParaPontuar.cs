namespace SistemaDeProdutividade.Web.Models;

public class AtividadeParaPontuar
{
    public int Number { get; set; }
    public string Descricao { get; set; } = string.Empty!;
    public int Peso { get; set; }
    public int Quantidade { get; set; } = 0;
}
