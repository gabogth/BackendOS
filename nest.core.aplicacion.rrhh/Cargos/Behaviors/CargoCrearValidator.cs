using FluentValidation;
using nest.core.aplicacion.rrhh.Cargos.Commands;

namespace nest.core.aplicacion.rrhh.Cargos.Behaviors;

public class CargoCrearValidator : AbstractValidator<CargoCrearCommand>
{
    public CargoCrearValidator()
    {
        Include(new CargoGenericValidator<CargoCrearCommand>());
    }
}
