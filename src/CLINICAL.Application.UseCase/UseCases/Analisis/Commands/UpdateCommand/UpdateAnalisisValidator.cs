using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Commands.UpdateCommand
{
    public class UpdateAnalisisValidator : AbstractValidator<UpdateAnalisisCommand>
    {
        public UpdateAnalisisValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo nombre no puede ser vacío");
        }
    }
}