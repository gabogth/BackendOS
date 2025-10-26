using FluentValidation;
using nest.core.aplicacion.rrhh.HorarioDetalles.Commands;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Behaviors;

public class HorarioDetalleCrearValidator : AbstractValidator<HorarioDetalleCrearCommand>
{
    public HorarioDetalleCrearValidator()
    {
        RuleFor(x => x.EmpresaId)
            .GreaterThan(0).WithMessage("La empresa es obligatoria.");

        RuleFor(x => x.HorarioCabeceraId)
            .GreaterThan(0).WithMessage("La cabecera de horario es obligatoria.");
    }
}
