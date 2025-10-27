using FluentValidation;
using nest.core.aplicacion.rrhh.HorarioDetalles.Commands;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Behaviors;

public class HorarioDetalleCrearValidator : AbstractValidator<HorarioDetalleCrearCommand>
{
    public HorarioDetalleCrearValidator()
    {
        Include(new HorarioDetalleGenericValidator<HorarioDetalleCrearCommand>());
    }
}
