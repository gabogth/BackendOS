using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Behaviors
{
    public class OrdenTrabajoPersonalCrearValidator : AbstractValidator<OrdenTrabajoPersonalCrearCommand>
    {
        public OrdenTrabajoPersonalCrearValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador del registro es obligatorio.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("El identificador de la empresa es obligatorio.");

            RuleFor(x => x.OrdenTrabajoCabeceraId)
                .GreaterThan(0).WithMessage("La cabecera de orden de trabajo es obligatoria.");

            RuleFor(x => x.PersonaId)
                .GreaterThan(0).WithMessage("El identificador de la persona es obligatorio.");
        }
    }
}
