using FluentValidation;
using nest.core.aplicacion.security.Modulos.Commands;

namespace nest.core.aplicacion.security.Modulos.Behaviors;

public class ModuloCrearValidator : AbstractValidator<ModuloCrearCommand>
{
    public ModuloCrearValidator()
    {
        Include(new ModuloGenericValidator<ModuloCrearCommand>());
    }
}
