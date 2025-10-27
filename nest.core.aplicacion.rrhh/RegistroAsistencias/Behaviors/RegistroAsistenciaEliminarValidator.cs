using FluentValidation;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Behaviors
{
    public class RegistroAsistenciaEliminarValidator : AbstractValidator<RegistroAsistenciaEliminarCommand>
    {
        public RegistroAsistenciaEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es obligatorio.");
        }
    }
}
