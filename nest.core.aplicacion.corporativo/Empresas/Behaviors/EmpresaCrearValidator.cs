using FluentValidation;
using nest.core.aplicacion.corporativo.Empresas.Commands;

namespace nest.core.aplicacion.corporativo.Empresas.Behaviors
{
    public class EmpresaCrearValidator : AbstractValidator<EmpresaCrearCommand>
    {
        public EmpresaCrearValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre no debe exceder 150 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(50).WithMessage("El nombre corto no debe exceder 50 caracteres.");
        }
    }
}
