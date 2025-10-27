using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Behaviors
{
    public class RegistroAsistenciaOrdenTrabajoCrearUsuarioActualValidator : AbstractValidator<RegistroAsistenciaOrdenTrabajoCrearUsuarioActualCommand>
    {
        public RegistroAsistenciaOrdenTrabajoCrearUsuarioActualValidator()
        {
            RuleFor(x => x.DiferenciaMinutos)
                .GreaterThanOrEqualTo(0).WithMessage("La diferencia de minutos no puede ser negativa.");
        }
    }
}
