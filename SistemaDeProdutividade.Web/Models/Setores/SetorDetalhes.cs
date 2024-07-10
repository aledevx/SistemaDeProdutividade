namespace SistemaDeProdutividade.Web.Models.Setores;

public class SetorDetalhes
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string TipoSetor { get; set; } = string.Empty;
    public string? Chefe { get; set; } = string.Empty;
    public string? SetorChefe { get; set; } = string.Empty;
    public List<UsuarioIndex> UsuariosLotados { get; set; } = [];

}
