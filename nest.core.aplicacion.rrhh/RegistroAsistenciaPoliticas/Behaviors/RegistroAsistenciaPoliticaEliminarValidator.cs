using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Behaviors;

public class RegistroAsistenciaPoliticaEliminarValidator : AbstractValidator<RegistroAsistenciaPoliticaEliminarCommand>
{
    public RegistroAsistenciaPoliticaEliminarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
    }
}
