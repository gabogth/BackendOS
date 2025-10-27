using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Behaviors;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Behaviors
{
    public class RegistroAsistenciaOrdenTrabajoModificarValidator : AbstractValidator<RegistroAsistenciaOrdenTrabajoModificarCommand>
    {
        public RegistroAsistenciaOrdenTrabajoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es obligatorio.");

            RuleFor(x => x.OrdenTrabajoCabeceraId)
                .GreaterThan(0).WithMessage("La orden de trabajo es obligatoria.");

            Include(new RegistroAsistenciaGenericValidator<RegistroAsistenciaOrdenTrabajoModificarCommand>());
        }
    }
}
