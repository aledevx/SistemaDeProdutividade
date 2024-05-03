using FluentValidation;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Application.UseCases.Usuario.Logar;
public class LogarUsuarioValidator : AbstractValidator<LoginRequestJson>
{
    public LogarUsuarioValidator()
    {
        RuleFor(u => u.Cpf).NotEmpty().Length(11).NotNull().WithMessage(ResourceMessagesException.CPF_INVALID);
    }
}
