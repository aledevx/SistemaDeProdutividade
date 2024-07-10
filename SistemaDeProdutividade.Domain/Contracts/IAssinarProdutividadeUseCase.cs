using SistemaDeProdutividade.Communication.Requests.Assinaturas;
using SistemaDeProdutividade.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface IAssinarProdutividadeUseCase
{
    Task<MensagemSucessoResponseJson> Execute(AssinarProdutividadeRequestJson request);
}
