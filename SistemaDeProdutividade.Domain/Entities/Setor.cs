using SistemaDeProdutividade.Communication.Enums;

namespace SistemaDeProdutividade.Domain.Entities;
public class Setor
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public TipoSetor TipoSetor { get; set; }
    public Guid? SetorSuperiorId { get; set; }
    public Guid? ChefeId { get; set; }
    public Usuario? Chefe { get; set; }
    public Setor()
    {
        
    }
    public Setor(string nome, TipoSetor tipoSetor)
    {
        Nome = nome;
        TipoSetor = tipoSetor;
    }
    public void AddSetorSuperior(Guid setorSuperiorId)
    {
        SetorSuperiorId = setorSuperiorId;
    }
    public void AddChefe(Usuario chefe) 
    {
        Chefe = chefe;
    }
}
