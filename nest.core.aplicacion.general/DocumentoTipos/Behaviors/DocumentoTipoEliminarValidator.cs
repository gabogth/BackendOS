using FluentValidation;
using nest.core.aplicacion.general.DocumentoTipos.Commands;

namespace nest.core.aplicacion.general.DocumentoTipos.Behaviors
{
    public sealed class DocumentoTipoEliminarValidator : AbstractValidator<DocumentoTipoEliminarCommand>
    {
        public DocumentoTipoEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
        }
    }
}
