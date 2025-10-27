using FluentValidation;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Commands;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Behaviors
{
    public class EstructuraOrganizacionalTipoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IEstructuraOrganizacionalTipoGenericCommand
    {
        public EstructuraOrganizacionalTipoGenericValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre no debe exceder 150 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(50).WithMessage("El nombre corto no debe exceder 50 caracteres.");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción es requerida.")
                .MaximumLength(250).WithMessage("La descripción no debe exceder 250 caracteres.");
        }
    }
}
