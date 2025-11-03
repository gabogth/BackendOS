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
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.")
                .Matches(@"[A-Z]").WithMessage("Debe contener al menos una letra mayúscula.")
                .Matches(@"[a-z]").WithMessage("Debe contener al menos una letra minúscula.")
                .Matches(@"\d").WithMessage("Debe contener al menos un número.")
                .Matches(@"[!@#$%^&*(),.?\:{}|<>]").WithMessage("Debe contener al menos un carácter especial.");
        }
    }
}
