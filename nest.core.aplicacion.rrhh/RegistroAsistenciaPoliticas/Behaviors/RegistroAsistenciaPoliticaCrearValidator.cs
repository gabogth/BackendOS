using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Behaviors;

public class RegistroAsistenciaPoliticaCrearValidator : AbstractValidator<RegistroAsistenciaPoliticaCrearCommand>
{
    public RegistroAsistenciaPoliticaCrearValidator()
    {
        Include(new RegistroAsistenciaPoliticaGenericValidator<RegistroAsistenciaPoliticaCrearCommand>());
    }
}
