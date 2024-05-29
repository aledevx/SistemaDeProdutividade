using FluentValidation;
using SistemaDeProdutividade.Application.UseCases.Setor.Criar;

namespace SistemaDeProdutividade.Application.UseCases.Setor.Editar
{
    public class EditarSetorValidator : AbstractValidator<EditarSetorRequestJson>
    {
        public EditarSetorValidator()
        {
            // Add your validation rules here
        }
    }
}