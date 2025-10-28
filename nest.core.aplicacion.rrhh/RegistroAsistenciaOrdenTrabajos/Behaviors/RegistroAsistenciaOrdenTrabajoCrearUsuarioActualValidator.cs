using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Behaviors
{
    public class RegistroAsistenciaOrdenTrabajoCrearUsuarioActualValidator : AbstractValidator<RegistroAsistenciaOrdenTrabajoCrearUsuarioActualCommand>
    {
        public RegistroAsistenciaOrdenTrabajoCrearUsuarioActualValidator()
        {
            RuleFor(x => x.AdjuntoId)
                .GreaterThan(0).WithMessage("Tienes que agregar una foto (AdjuntoId).");
            RuleFor(x => x.Latitud)
                .NotNull().WithMessage("La latitud no puede ser nula.");
            RuleFor(x => x.Longitud)
                .NotNull().WithMessage("La longitud no puede ser nula.");
        }
    }
}
