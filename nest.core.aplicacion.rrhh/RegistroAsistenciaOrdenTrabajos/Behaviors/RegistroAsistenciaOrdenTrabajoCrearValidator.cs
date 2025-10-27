using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Behaviors;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Behaviors
{
    public class RegistroAsistenciaOrdenTrabajoCrearValidator : AbstractValidator<RegistroAsistenciaOrdenTrabajoCrearCommand>
    {
        public RegistroAsistenciaOrdenTrabajoCrearValidator()
        {
            Include(new RegistroAsistenciaGenericValidator<RegistroAsistenciaOrdenTrabajoCrearCommand>());
        }
    }
}
