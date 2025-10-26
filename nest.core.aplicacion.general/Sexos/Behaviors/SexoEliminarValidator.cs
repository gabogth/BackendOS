using FluentValidation;
using nest.core.aplicacion.general.Sexos.Commands;

namespace nest.core.aplicacion.general.Sexos.Behaviors
{
    public class SexoEliminarValidator : AbstractValidator<SexoEliminarCommand>
    {
        public SexoEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan((byte)0).WithMessage("El identificador es requerido.");
        }
    }
}
