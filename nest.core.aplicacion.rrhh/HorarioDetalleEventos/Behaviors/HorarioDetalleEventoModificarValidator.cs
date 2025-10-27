using FluentValidation;
using nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Behaviors;

public class HorarioDetalleEventoModificarValidator : AbstractValidator<HorarioDetalleEventoModificarCommand>
{
    public HorarioDetalleEventoModificarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
            Include(new HorarioDetalleEventoGenericValidator<HorarioDetalleEventoModificarCommand>());
    }
}
