using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface IFinalizarProdutividadeUseCase
{
    Task<MensagemSucessoResponseJson> Execute(FinalizarProdutividadeRequestJson request);
}
