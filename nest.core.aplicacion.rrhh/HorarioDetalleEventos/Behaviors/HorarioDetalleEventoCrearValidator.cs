using FluentValidation;
using nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Behaviors;

public class HorarioDetalleEventoCrearValidator : AbstractValidator<HorarioDetalleEventoCrearCommand>
{
    public HorarioDetalleEventoCrearValidator()
    {
        Include(new HorarioDetalleEventoGenericValidator<HorarioDetalleEventoCrearCommand>());
    }
}
