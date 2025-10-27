using FluentValidation;
using nest.core.aplicacion.general.AdjuntoTipos.Commands;

namespace nest.core.aplicacion.general.AdjuntoTipos.Behaviors
{
    public class AdjuntoTipoCrearValidator : AbstractValidator<AdjuntoTipoCrearCommand>
    {
        public AdjuntoTipoCrearValidator()
        {
            Include(new AdjuntoTipoGenericValidator<AdjuntoTipoCrearCommand>());
        }
    }
}
