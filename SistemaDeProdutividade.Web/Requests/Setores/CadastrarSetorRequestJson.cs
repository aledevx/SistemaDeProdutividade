namespace SistemaDeProdutividade.Web.Requests.Setores;

public class CadastrarSetorRequestJson 
{
    public string Nome { get; set; } = string.Empty;
    public string TipoSetor { get; set; } = string.Empty;
    public Guid? SetorSuperiorId { get; set; }
}
