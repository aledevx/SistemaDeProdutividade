namespace SistemaDeProdutividade.Communication.ViewModel.Setores;
public class SetorVM
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string TipoSetor { get; set; } = string.Empty;
    public string? Chefe { get; set; } = string.Empty;
    public string? SetorChefe { get; set; } = string.Empty;
    public List<IndexUsuarioSetorVM> UsuariosLotados { get; set; } = [];
    public SetorVM()
    {
    }
    public SetorVM(string nome, string tipoSetor)
    {
        Nome = nome;
        TipoSetor = tipoSetor;
    }
    public SetorVM(string nome, string tipoSetor, string? chefe, string setorChefe)
    {
        Nome = nome;
        TipoSetor = tipoSetor;
        Chefe = chefe;
        SetorChefe = setorChefe;
    }
}
