using FluentValidation;
using nest.core.aplicacion.patrimonial.UbicacionActivos.Commands;

namespace nest.core.aplicacion.patrimonial.UbicacionActivos.Behaviors
{
    public class UbicacionActivoCrearValidator : AbstractValidator<UbicacionActivoCrearCommand>
    {
        public UbicacionActivoCrearValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("El identificador de la empresa es obligatorio.");

            RuleFor(x => x.ActivoId)
                .GreaterThan(0).WithMessage("El identificador del activo es obligatorio.");

            RuleFor(x => x.UbicacionTecnicaId)
                .GreaterThan(0).WithMessage("La ubicación técnica es obligatoria.");

            RuleFor(x => x.FechaIngreso)
                .NotEqual(default(DateTime)).WithMessage("La fecha de ingreso es obligatoria.");

            RuleFor(x => x.FechaSalida)
                .GreaterThan(x => x.FechaIngreso)
                .When(x => x.FechaSalida.HasValue)
                .WithMessage("La fecha de salida debe ser posterior a la fecha de ingreso.");
        }
    }
}
