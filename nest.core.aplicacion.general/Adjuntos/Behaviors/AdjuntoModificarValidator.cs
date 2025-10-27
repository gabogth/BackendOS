using FluentValidation;
using nest.core.aplicacion.general.Adjuntos.Commands;

namespace nest.core.aplicacion.general.Adjuntos.Behaviors
{
    public class AdjuntoModificarValidator : AbstractValidator<AdjuntoModificarCommand>
    {
        public AdjuntoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            Include(new AdjuntoGenericValidator<AdjuntoModificarCommand>());
        }
    }
}
