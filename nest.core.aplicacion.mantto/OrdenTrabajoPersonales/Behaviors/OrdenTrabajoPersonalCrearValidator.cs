using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Behaviors
{
    public class OrdenTrabajoPersonalCrearValidator : AbstractValidator<OrdenTrabajoPersonalCrearCommand>
    {
        public OrdenTrabajoPersonalCrearValidator()
        {
            Include(new OrdenTrabajoPersonalGenericValidator<OrdenTrabajoPersonalCrearCommand>());
        }
    }
}
