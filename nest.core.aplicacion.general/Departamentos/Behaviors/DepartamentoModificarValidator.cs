using FluentValidation;
using nest.core.aplicacion.general.Departamentos.Commands;

namespace nest.core.aplicacion.general.Departamentos.Behaviors
{
    public class DepartamentoModificarValidator : AbstractValidator<DepartamentoModificarCommand>
    {
        public DepartamentoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a cero.");
            Include(new DepartamentoGenericValidator<DepartamentoModificarCommand>());
        }
    }
}
