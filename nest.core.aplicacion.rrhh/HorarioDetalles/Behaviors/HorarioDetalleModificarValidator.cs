using FluentValidation;
using nest.core.aplicacion.rrhh.HorarioDetalles.Commands;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Behaviors;

public class HorarioDetalleModificarValidator : AbstractValidator<HorarioDetalleModificarCommand>
{
    public HorarioDetalleModificarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");

        Include(new HorarioDetalleCrearValidator());
    }
}
