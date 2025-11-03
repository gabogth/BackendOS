using FluentValidation;
using nest.core.aplicacion.security.Usuarios.Commands;

namespace nest.core.aplicacion.security.Usuarios.Behaviors
{
    public sealed class UsuarioModificarValidator : AbstractValidator<UsuarioModificarCommand>
    {
        public UsuarioModificarValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El identificador del usuario es requerido.");
            Include(new UsuarioGenericValidator<UsuarioModificarCommand>());
                
        }
    }
}
