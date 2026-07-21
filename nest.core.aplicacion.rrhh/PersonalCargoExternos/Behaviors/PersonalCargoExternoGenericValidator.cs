using FluentValidation;
using nest.core.aplicacion.rrhh.PersonalCargoExternos.Commands;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Behaviors
{
    public class PersonalCargoExternoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IPersonalCargoExternoGenericCommand
    {
        public PersonalCargoExternoGenericValidator()
        {
            RuleFor(x => x.EmpresaId).GreaterThan(0).WithMessage("La empresa es obligatoria.");
            RuleFor(x => x.PersonalId).GreaterThan(0).WithMessage("El personal es obligatorio.");
            RuleFor(x => x.CargoId).GreaterThan(0).WithMessage("El cargo es obligatorio.");
        }
    }
}
