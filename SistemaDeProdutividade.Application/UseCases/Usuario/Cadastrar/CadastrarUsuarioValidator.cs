using FluentValidation;
using SistemaDeProdutividade.Communication.Requests;
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
        RuleFor(u => u.Nome).NotEmpty().NotNull();
        RuleFor(u => u.Cpf).NotEmpty().Length(11).NotNull();
        RuleFor(u => u.Matricula).NotEmpty().NotNull();
        RuleFor(u => u.Perfil).NotEmpty().NotNull();
    }
}
