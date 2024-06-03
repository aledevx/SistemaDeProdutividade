using FluentValidation;
using SistemaDeProdutividade.Application.UseCases.Setor.Criar;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Exception;

namespace SistemaDeProdutividade.Application.UseCases.Setor.Editar
{
    public class EditarSetorValidator : AbstractValidator<EditarSetorRequestJson>
    {
        public EditarSetorValidator()
        {
        }
    }
}