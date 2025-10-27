using FluentValidation;
using nest.core.aplicacion.security.Formularios.Commands;

namespace nest.core.aplicacion.security.Formularios.Behaviors;

public class FormularioCrearValidator : AbstractValidator<FormularioCrearCommand>
{
    public FormularioCrearValidator()
    {
        Include(new FormularioGenericValidator<FormularioCrearCommand>());
    }
}
