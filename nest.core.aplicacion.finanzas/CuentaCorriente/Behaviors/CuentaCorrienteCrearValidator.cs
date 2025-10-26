using FluentValidation;
using nest.core.aplicacion.finanzas.CuentaCorriente.Commands;

namespace nest.core.aplicacion.finanzas.CuentaCorriente.Behaviors
{
    public class CuentaCorrienteCrearValidator : AbstractValidator<CuentaCorrienteCrearCommand>
    {
        public CuentaCorrienteCrearValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId es requerido.");
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(200).WithMessage("El nombre no puede superar los 200 caracteres.");
            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(100).WithMessage("El nombre corto no puede superar los 100 caracteres.");
            RuleFor(x => x.CuentaNumero)
                .NotEmpty().WithMessage("El número de cuenta es requerido.")
                .MaximumLength(50).WithMessage("El número de cuenta no puede superar los 50 caracteres.");
            RuleFor(x => x.EntidadFinancieraId)
                .GreaterThan(0).WithMessage("La entidad financiera es requerida.");
            RuleFor(x => x.CuentaContableId)
                .GreaterThan(0).WithMessage("La cuenta contable es requerida.");
        }
    }
}
