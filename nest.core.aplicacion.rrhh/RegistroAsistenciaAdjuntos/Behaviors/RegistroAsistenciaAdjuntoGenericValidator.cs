using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Behaviors
{
    public class RegistroAsistenciaAdjuntoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IRegistroAsistenciaAdjuntoGenericCommand
    {
        public RegistroAsistenciaAdjuntoGenericValidator()
        {
            RuleFor(x => x.RegistroAsistenciaId)
                .GreaterThan(0).WithMessage("El identificador del registro de asistencia es obligatorio.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("La empresa es obligatoria.");

            RuleFor(x => x.AdjuntoId)
                .GreaterThan(0).WithMessage("El adjunto es obligatorio.");
        }
    }
}
