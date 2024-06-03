using FluentValidation;
using SistemaDeProdutividade.Application.UseCases.Setor.Criar;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Exception;

namespace SistemaDeProdutividade.Application.UseCases.Setor.Criar
{
    public class CriarSetorValidator : AbstractValidator<CriarSetorRequestJson>
    {
        public CriarSetorValidator()
        {
            RuleFor(s => s.Nome).NotEmpty().NotNull().WithMessage(ResourceMessagesException.NAME_EMPTY);
        }
    }
}