using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Behaviors
{
    public class RegistroAsistenciaTerminalZKTecoCrearValidator : AbstractValidator<RegistroAsistenciaTerminalZKTecoCrearCommand>
    {
        public RegistroAsistenciaTerminalZKTecoCrearValidator()
        {
            RuleFor(x => x.SerialNumber)
                .NotNull().NotEmpty().WithMessage("El número de serie es obligatorio.");

            RuleFor(x => x.DocumentoTipo)
                .GreaterThan(0).WithMessage("El tipo de documento es obligatorio.");

            RuleFor(x => x.DocumentoNumero)
                .NotNull().NotEmpty().WithMessage("El número de documento es obligatorio.");

            RuleFor(x => x.Fecha)
                .NotEmpty().WithMessage("La fecha es obligatoria.");
        }
    }
}
