using FluentValidation;
using nest.core.aplicacion.general.AdjuntoConfigProviders.Commands;

namespace nest.core.aplicacion.general.AdjuntoConfigProviders.Behaviors
{
    public class AdjuntoConfigProviderModificarValidator : AbstractValidator<AdjuntoConfigProviderModificarCommand>
    {
        public AdjuntoConfigProviderModificarValidator()
        {
            RuleFor(x => x.Id)
                .IsInEnum().WithMessage("El identificador es inválido.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre no debe exceder 150 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(75).WithMessage("El nombre corto no debe exceder 75 caracteres.");

            RuleFor(x => x.AdjuntoProvider)
                .IsInEnum().WithMessage("El proveedor indicado es inválido.");

            RuleFor(x => x.Container)
                .NotEmpty().WithMessage("El contenedor es requerido.")
                .MaximumLength(200).WithMessage("El contenedor no debe exceder 200 caracteres.");

            RuleFor(x => x.MainPath)
                .NotEmpty().WithMessage("La ruta principal es requerida.")
                .MaximumLength(200).WithMessage("La ruta principal no debe exceder 200 caracteres.");
        }
    }
}
