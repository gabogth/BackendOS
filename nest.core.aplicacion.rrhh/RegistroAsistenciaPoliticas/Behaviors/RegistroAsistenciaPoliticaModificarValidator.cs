using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Behaviors;

public class RegistroAsistenciaPoliticaModificarValidator : AbstractValidator<RegistroAsistenciaPoliticaModificarCommand>
{
    public RegistroAsistenciaPoliticaModificarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
            Include(new RegistroAsistenciaPoliticaGenericValidator<RegistroAsistenciaPoliticaModificarCommand>());
    }
}
