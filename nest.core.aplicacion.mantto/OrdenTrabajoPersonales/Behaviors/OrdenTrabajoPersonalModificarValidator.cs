using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Behaviors
{
    public class OrdenTrabajoPersonalModificarValidator : AbstractValidator<OrdenTrabajoPersonalModificarCommand>
    {
        public OrdenTrabajoPersonalModificarValidator()
        {
            Include(new OrdenTrabajoPersonalGenericValidator<OrdenTrabajoPersonalModificarCommand>());
        }
    }
}
