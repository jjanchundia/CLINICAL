using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Commands.CreateCommand
{
    //Uso de FluentValidator
    //Le pasamos clase a validar
    public class CreateAnalisisValidator:AbstractValidator<CreateAnalisisCommand>
    {
        public CreateAnalisisValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo nombre no puede ser vacío");
        }
    }
}