using FluentValidation;
using nest.core.aplicacion.mantto.MantenimientoTipos.Commands;

namespace nest.core.aplicacion.mantto.MantenimientoTipos.Behaviors
{
    public class MantenimientoTipoCrearValidator : AbstractValidator<MantenimientoTipoCrearCommand>
    {
        public MantenimientoTipoCrearValidator()
        {
            Include(new MantenimientoTipoGenericValidator<MantenimientoTipoCrearCommand>());
        }
    }
}
