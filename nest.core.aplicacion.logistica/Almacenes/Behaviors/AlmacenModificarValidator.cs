using FluentValidation;
using nest.core.aplicacion.logistica.Almacenes.Commands;

namespace nest.core.aplicacion.rrhh.Cargos.Behaviors;

public class AlmacenModificarValidator : AbstractValidator<AlmacenModificarCommand>
{
    public AlmacenModificarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
        Include(new AlmacenGenericValidator<AlmacenModificarCommand>());
    }
}
