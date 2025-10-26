using FluentValidation;
using nest.core.aplicacion.general.Adjuntos.Commands;

namespace nest.core.aplicacion.general.Adjuntos.Behaviors
{
    public class AdjuntoEliminarValidator : AbstractValidator<AdjuntoEliminarCommand>
    {
        public AdjuntoEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
        }
    }
}
