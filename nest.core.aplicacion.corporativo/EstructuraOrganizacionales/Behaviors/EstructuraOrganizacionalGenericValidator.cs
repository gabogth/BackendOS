using FluentValidation;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Commands;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Behaviors
{
    public class EstructuraOrganizacionalGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IEstructuraOrganizacionalGenericCommand
    {
        public EstructuraOrganizacionalGenericValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("La empresa es requerida.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre no debe exceder 150 caracteres.");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción es requerida.")
                .MaximumLength(250).WithMessage("La descripción no debe exceder 250 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(9).WithMessage("El nombre corto no debe exceder 9 caracteres.");

            RuleFor(x => x.EstructuraOrganizacionalTipoId)
                .GreaterThan(0).WithMessage("El tipo de estructura organizacional es requerido.");
        }
    }
}
