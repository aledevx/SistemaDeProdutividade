using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface IRequestEntityMapperService
{
    Usuario MappingToUsuario(CadastrarUsuarioRequestJson request);
}
