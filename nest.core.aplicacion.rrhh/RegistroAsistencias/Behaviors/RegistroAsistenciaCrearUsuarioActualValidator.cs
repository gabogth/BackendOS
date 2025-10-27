using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Behaviors
{
    public class RegistroAsistenciaCrearUsuarioActualValidator : AbstractValidator<RegistroAsistenciaCrearUsuarioActualCommand>
    {
        public RegistroAsistenciaCrearUsuarioActualValidator()
        {
            RuleFor(x => x.DiferenciaMinutos)
                .GreaterThanOrEqualTo(0).WithMessage("La diferencia de minutos no puede ser negativa.");
        }
    }
}
