using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Entities;
using SistemaDeProdutividade.Domain.Enums;

namespace SistemaDeProdutividade.Application.Services.EntityMapper;
public class EntityMapperService : IRequestEntityMapperService
{
    public Usuario MappingToUsuario(CadastrarUsuarioRequestJson request)
    {
        var usuario = new Usuario(request.Nome, request.Matricula, request.Cpf, request.Perfil);

        return usuario;
    }
    public Setor MappingToSetor(CriarSetorRequestJson request)
    {
        var tipoSetor = (TipoSetor)Enum.Parse(typeof(TipoSetor), request.TipoSetor);
        var setor = new Setor(request.Nome, tipoSetor, request.SetorSuperiorId, request.ChefeId, request.AssinanteResponsavelId);

        return setor;
    }
    public Setor MappingToSetorEdit(EditarSetorRequestJson request)
    {
        var tipoSetor = (TipoSetor)Enum.Parse(typeof(TipoSetor), request.TipoSetor);
        var setor = new Setor(request.Nome, tipoSetor, request.SetorSuperiorId, request.ChefeId, request.AssinanteResponsavelId);

        return setor;
    }
}
