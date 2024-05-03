using FluentValidation;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Application.UseCases.Usuario.Cadastrar;
public class CadastrarUsuarioValidator : AbstractValidator<CadastrarUsuarioRequestJson>
{
    public CadastrarUsuarioValidator()
    {
        RuleFor(u => u.Nome).NotEmpty().NotNull().WithMessage(ResourceMessagesException.NAME_EMPTY);
        RuleFor(u => u.Cpf).NotEmpty().Length(11).NotNull().WithMessage(ResourceMessagesException.CPF_INVALID);
        RuleFor(u => u.Matricula).NotEmpty().NotNull().WithMessage(ResourceMessagesException.REGISTRATION_EMPTY);
        RuleFor(u => u.Perfil).NotEmpty().NotNull();
    }
}
