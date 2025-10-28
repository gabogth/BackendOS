using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Behaviors
{
    public class RegistroAsistenciaAdjuntoEliminarValidator : AbstractValidator<RegistroAsistenciaAdjuntoEliminarCommand>
    {
        public RegistroAsistenciaAdjuntoEliminarValidator()
        {
            RuleFor(x => x.RegistroAsistenciaId)
                .GreaterThan(0).WithMessage("El identificador del registro de asistencia es obligatorio.");
        }
    }
}
