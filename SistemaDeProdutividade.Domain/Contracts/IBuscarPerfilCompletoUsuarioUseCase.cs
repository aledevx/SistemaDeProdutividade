using SistemaDeProdutividade.Communication.Requests.Usuarios;
using SistemaDeProdutividade.Communication.Responses.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface IBuscarPerfilCompletoUsuarioUseCase
{
   Task<PerfilUsuarioResponseJson> Execute(string cpfUserLogado, Guid id);
}
