using FluentValidation;
using nest.core.aplicacion.security.UsuarioEmpresas.Commands;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Behaviors
{
    public class UsuarioEmpresaGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IUsuarioEmpresaGenericCommand
    {
        public UsuarioEmpresaGenericValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty().WithMessage("El identificador del usuario es requerido.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("El identificador de la empresa es requerido.");
        }
    }
}
