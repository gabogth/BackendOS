using FluentValidation;
using nest.core.aplicacion.corporativo.Empresas.Commands;

namespace nest.core.aplicacion.corporativo.Empresas.Behaviors
{
    public class EmpresaModificarValidator : AbstractValidator<EmpresaModificarCommand>
    {
        public EmpresaModificarValidator()
        {
            Include(new EmpresaCrearValidator());

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador de la empresa debe ser mayor a cero.");
        }
    }
}
