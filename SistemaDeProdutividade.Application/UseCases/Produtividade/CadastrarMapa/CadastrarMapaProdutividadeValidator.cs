using FluentValidation;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Application.UseCases.Produtividade.CadastrarMapa;
public class CadastrarMapaProdutividadeValidator : AbstractValidator<CadastrarProdutividadeRequestJson>
{
    public CadastrarMapaProdutividadeValidator()
    {
        RuleFor(p => p.Cargo).NotEmpty().NotNull().WithMessage(ResourceMessagesException.NAME_EMPTY);
        RuleFor(p => p.Valor).NotEmpty().NotNull().WithMessage(ResourceMessagesException.VALOR_PROD_INVALID);
    }
}
