using FluentValidation;
using nest.core.aplicacion.general.AdjuntoTipos.Commands;

namespace nest.core.aplicacion.general.AdjuntoTipos.Behaviors
{
    public class AdjuntoTipoModificarValidator : AbstractValidator<AdjuntoTipoModificarCommand>
    {
        public AdjuntoTipoModificarValidator()
        {
            RuleFor(x => x.Id)
                .IsInEnum().WithMessage("El identificador es inválido.");
            Include(new AdjuntoTipoGenericValidator<AdjuntoTipoModificarCommand>());
        }
    }
}
