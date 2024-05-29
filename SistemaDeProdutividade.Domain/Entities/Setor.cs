using System.Diagnostics.CodeAnalysis;
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
    [SetsRequiredMembers]
    public Setor(string nome, TipoSetor tipoSetor, Guid? setorSuperiorId, Guid? chefeId, Guid? assinanteResponsavelId)
    {
        Nome = nome;
        TipoSetor = tipoSetor;
        SetorSuperiorId = setorSuperiorId;
        ChefeId = chefeId;
        AssinanteResponsavelId = assinanteResponsavelId;
    }
}
