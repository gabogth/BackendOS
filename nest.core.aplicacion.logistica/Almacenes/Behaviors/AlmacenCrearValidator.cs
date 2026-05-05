using FluentValidation;
using nest.core.aplicacion.logistica.Almacenes.Commands;
using nest.core.aplicacion.rrhh.Cargos.Behaviors;

namespace nest.core.aplicacion.logistica.Almacenes.Behaviors;

public class AlmacenCrearValidator : AbstractValidator<AlmacenCrearCommand>
{
    public AlmacenCrearValidator()
    {
        Include(new AlmacenGenericValidator<AlmacenCrearCommand>());
    }
}
