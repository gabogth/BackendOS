using FluentValidation;
using nest.core.aplicacion.general.Sexos.Commands;

namespace nest.core.aplicacion.general.Sexos.Behaviors
{
    public class SexoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : ISexoGenericCommand
    {
        public SexoGenericValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(100).WithMessage("El nombre no debe exceder 100 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(50).WithMessage("El nombre corto no debe exceder 50 caracteres.");
        }
    }
}
