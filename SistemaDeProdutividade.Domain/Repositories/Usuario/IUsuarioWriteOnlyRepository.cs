using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Repositories.Usuario;
public interface IUsuarioWriteOnlyRepository
{
    Task Add(Entities.Usuario usuario);
}
