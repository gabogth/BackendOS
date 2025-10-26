using FluentValidation;
using nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Behaviors;

public class HorarioDetalleEventoEliminarValidator : AbstractValidator<HorarioDetalleEventoEliminarCommand>
{
    public HorarioDetalleEventoEliminarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
    }
}
