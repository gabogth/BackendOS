using FluentValidation;
using nest.core.aplicacion.general.AdjuntoTipos.Commands;

namespace nest.core.aplicacion.general.AdjuntoTipos.Behaviors
{
    public class AdjuntoTipoEliminarValidator : AbstractValidator<AdjuntoTipoEliminarCommand>
    {
        public AdjuntoTipoEliminarValidator()
        {
            RuleFor(x => x.Id)
                .IsInEnum().WithMessage("El identificador es inválido.");
        }
    }
}
