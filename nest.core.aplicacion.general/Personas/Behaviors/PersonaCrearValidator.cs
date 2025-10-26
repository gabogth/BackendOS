using FluentValidation;
using nest.core.aplicacion.general.Personas.Commands;

namespace nest.core.aplicacion.general.Personas.Behaviors
{
    public class PersonaCrearValidator : AbstractValidator<PersonaCrearCommand>
    {
        public PersonaCrearValidator()
        {
            RuleFor(x => x.EmpresaId)
                .NotEmpty().WithMessage("EmpresaId es requerido.")
                .GreaterThan(0).WithMessage("EmpresaId debe ser mayor a 0.");
            RuleFor(x => x.Nombres)
                .NotEmpty().WithMessage("El nombre es requerido.");
            RuleFor(x => x.ApellidoPaterno)
                .NotEmpty().WithMessage("El apellido paterno es requerido.");
            RuleFor(x => x.ApellidoMaterno)
                .NotEmpty().WithMessage("El apellido materno es requerido.");
            RuleFor(x => x.FechaNacimiento)
                .NotEmpty().WithMessage("La fecha de nacimiento es requerida.")
                .LessThan(DateTime.Now).WithMessage("La fecha de nacimiento debe ser una fecha pasada.");
            RuleFor(x => x.DocumentoIdentidad)
                .NotEmpty().WithMessage("El documento de identidad es requerido.");
            RuleFor(x => x.Correo)
                .NotEmpty().WithMessage("El correo es requerido.")
                .EmailAddress().WithMessage("Correo no es un correo válido.");
            RuleFor(x => x.Celular)
                .NotEmpty().WithMessage("El celular es requerido.");
            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("El estado es requerido.");
            RuleFor(x => x.SexoId)
                .NotEmpty().WithMessage("El sexo es requerido.");
            RuleFor(x => x.DistritoId)
                .NotEmpty().WithMessage("El distrito es requerido.");
            RuleFor(x => x.DocumentoIdentidadTipoId)
                .NotEmpty().WithMessage("El tipo de documento de identidad es requerido.");
        }
    }
}
