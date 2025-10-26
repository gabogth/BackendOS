using FluentValidation;
using nest.core.aplicacion.general.Departamentos.Commands;

namespace nest.core.aplicacion.general.Departamentos.Behaviors
{
    public class DepartamentoCrearValidator : AbstractValidator<DepartamentoCrearCommand>
    {
        public DepartamentoCrearValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre no debe superar los 150 caracteres.");

            RuleFor(x => x.PaisId)
                .GreaterThan(0).WithMessage("El país es requerido.");
        }
    }
}
