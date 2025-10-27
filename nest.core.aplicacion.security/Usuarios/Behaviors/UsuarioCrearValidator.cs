using FluentValidation;
using nest.core.aplicacion.security.Usuarios.Commands;

namespace nest.core.aplicacion.security.Usuarios.Behaviors
{
    public sealed class UsuarioCrearValidator : AbstractValidator<UsuarioCrearCommand>
    {
        public UsuarioCrearValidator()
        {
            RuleFor(x => x.Usuario)
                .NotNull().WithMessage("El usuario es requerido.");

            When(x => x.Usuario is not null, () =>
            {
                RuleFor(x => x.Usuario.Email)
                    .NotEmpty().WithMessage("El correo es requerido.")
                    .EmailAddress().WithMessage("El correo no es válido.");

                RuleFor(x => x.Usuario.PhoneNumber)
                    .NotEmpty().WithMessage("El número de teléfono es requerido.");
            });

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es requerida.")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.");
        }
    }
}
