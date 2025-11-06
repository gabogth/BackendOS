using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Behaviors
{
    public class OrdenTrabajoHorarioCrearValidator : AbstractValidator<OrdenTrabajoHorarioCrearCommand>
    {
        public OrdenTrabajoHorarioCrearValidator()
        {
            Include(new OrdenTrabajoHorarioGenericValidator<OrdenTrabajoHorarioCrearCommand>());
        }
    }
}
