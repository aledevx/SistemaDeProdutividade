using SistemaDeProdutividade.Communication.Enums;
using SistemaDeProdutividade.Communication.ViewModel.Setores;

namespace SistemaDeProdutividade.Communication.Responses.Setores;
public class SetorResponseJson 
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public TipoSetor TipoSetor { get; set; }
    public string? Chefe { get; set; } = string.Empty;
    public string? SetorChefe { get; set; } = string.Empty;
    public List<IndexUsuarioSetorVM> UsuariosLotados { get; set; } = [];
    public SetorResponseJson()
    {
    }
    public SetorResponseJson(Guid id, string nome, TipoSetor tipoSetor)
    {
        Id = id;
        Nome = nome;
        TipoSetor = tipoSetor;
    }
    public void AddUsuario(IndexUsuarioSetorVM usuario) 
    {
        UsuariosLotados.Add(usuario);
    }
    public void AddChefe(string nomeChefe) 
    {
        Chefe = nomeChefe;
    }
    public void AddSetorChefe(string nomeSetorChefe)
    {
        SetorChefe = nomeSetorChefe;
    }
}