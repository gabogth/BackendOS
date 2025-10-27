using FluentValidation;
using nest.core.aplicacion.mantto.MantenimientoTipos.Commands;

namespace nest.core.aplicacion.mantto.MantenimientoTipos.Behaviors
{
    public class MantenimientoTipoModificarValidator : AbstractValidator<MantenimientoTipoModificarCommand>
    {
        public MantenimientoTipoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan((short)0).WithMessage("El identificador debe ser mayor a 0.");
            Include(new MantenimientoTipoGenericValidator<MantenimientoTipoModificarCommand>());
        }
    }
}
