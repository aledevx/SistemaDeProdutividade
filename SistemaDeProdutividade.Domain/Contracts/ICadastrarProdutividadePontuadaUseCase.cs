using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Produtividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface ICadastrarProdutividadePontuadaUseCase
{
    Task<MensagemSucessoCadastroResponseJson> Execute(ProdutividadeFeitaResponseJson request);
}
