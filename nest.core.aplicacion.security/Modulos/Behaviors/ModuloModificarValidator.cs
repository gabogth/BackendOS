using FluentValidation;
using nest.core.aplicacion.security.Modulos.Commands;

namespace nest.core.aplicacion.security.Modulos.Behaviors;

public class ModuloModificarValidator : AbstractValidator<ModuloModificarCommand>
{
    public ModuloModificarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
            Include(new ModuloGenericValidator<ModuloModificarCommand>());
    }
}
