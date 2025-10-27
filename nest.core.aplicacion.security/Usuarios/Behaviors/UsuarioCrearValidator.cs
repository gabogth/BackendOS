using FluentValidation;
using nest.core.aplicacion.security.Usuarios.Commands;

namespace nest.core.aplicacion.security.Usuarios.Behaviors
{
    public sealed class UsuarioCrearValidator : AbstractValidator<UsuarioCrearCommand>
    {
        public UsuarioCrearValidator()
        {
            Include(new UsuarioGenericValidator<UsuarioCrearCommand>());
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es requerida.")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.");
        }
    }
}
