using FluentValidation;
using nest.core.aplicacion.corporativo.Empresas.Commands;

namespace nest.core.aplicacion.corporativo.Empresas.Behaviors
{
    public class EmpresaEliminarValidator : AbstractValidator<EmpresaEliminarCommand>
    {
        public EmpresaEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador de la empresa debe ser mayor a cero.");
        }
    }
}
