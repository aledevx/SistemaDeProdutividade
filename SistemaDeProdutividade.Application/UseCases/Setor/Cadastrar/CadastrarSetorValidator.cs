using FluentValidation;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Requests.Setores;
using SistemaDeProdutividade.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Application.UseCases.Setor.Cadastrar;
public class CadastrarSetorValidator : AbstractValidator<CadastrarSetorRequestJson>
{
    public CadastrarSetorValidator()
    {
        RuleFor(u => u.Nome).NotEmpty().NotNull().WithMessage(ResourceMessagesException.NAME_EMPTY);
        RuleFor(u => u.TipoSetor).NotNull().NotEmpty().WithMessage(ResourceMessagesException.TIPO_SETOR_NOT_NULL_OR_EMPTY);
    }
}
