using SistemaDeProdutividade.Communication.Responses.Setores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface IVisualizarSetorUseCase
{
    Task<SetorResponseJson> Execute(Guid id);
}
