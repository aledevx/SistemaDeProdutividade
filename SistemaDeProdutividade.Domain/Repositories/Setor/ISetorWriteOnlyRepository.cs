using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Repositories.Setor;
public interface ISetorWriteOnlyRepository
{
    Task Add(Entities.Setor setor);
    void AddChefeSetor(Entities.Usuario usuario, Guid setorId);
}
