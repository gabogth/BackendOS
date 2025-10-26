using FluentValidation;
using nest.core.aplicacion.rrhh.HorarioDetalles.Commands;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Behaviors;

public class HorarioDetalleEliminarValidator : AbstractValidator<HorarioDetalleEliminarCommand>
{
    public HorarioDetalleEliminarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
    }
}
