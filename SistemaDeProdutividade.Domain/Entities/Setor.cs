using SistemaDeProdutividade.Domain.Enums;

namespace SistemaDeProdutividade.Domain.Entities;
public class Setor
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public required TipoSetor TipoSetor { get; set; }
    public Guid? SetorSuperiorId { get; set; }
    public Guid? ChefeId { get; set; }
    public Usuario? Chefe { get; set; }
    public Guid? AssinanteResponsavelId { get; set; }
}
