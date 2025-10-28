using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Behaviors
{
    public class RegistroAsistenciaCrearUsuarioActualValidator : AbstractValidator<RegistroAsistenciaCrearUsuarioActualCommand>
    {
        public RegistroAsistenciaCrearUsuarioActualValidator()
        {
            RuleFor(x => x.Latitud)
                .NotNull().WithMessage("La latitud es obligatoria.");
            RuleFor(x => x.Longitud)
                .NotNull().WithMessage(x => $"La longitud es obligatoria.");
        }
    }
}
