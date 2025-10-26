using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Behaviors
{
    public class OrdenServicioMantenimientoExternoCrearValidator : AbstractValidator<OrdenServicioMantenimientoExternoCrearCommand>
    {
        public OrdenServicioMantenimientoExternoCrearValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("La empresa es requerida.");

            RuleFor(x => x.ClienteId)
                .GreaterThan(0).WithMessage("El cliente es requerido.");

            RuleFor(x => x.ClientePlannerId)
                .GreaterThan(0).WithMessage("El planner es requerido.");

            RuleFor(x => x.CotizacionId)
                .GreaterThan(0).WithMessage("La cotización es requerida.");

            RuleFor(x => x.ActaConformidadId)
                .GreaterThan(0).WithMessage("El acta de conformidad es requerida.");

            RuleFor(x => x.MonedaId)
                .GreaterThan(0).WithMessage("La moneda es requerida.");

            RuleFor(x => x.LicitacionCodigo)
                .NotEmpty().WithMessage("El código de licitación es requerido.");

            RuleFor(x => x.CPI)
                .NotEmpty().WithMessage("El CPI es requerido.");

            RuleFor(x => x.MontoBruto)
                .GreaterThanOrEqualTo(0).WithMessage("El monto bruto no puede ser negativo.");

            RuleFor(x => x.MontoNeto)
                .GreaterThanOrEqualTo(0).WithMessage("El monto neto no puede ser negativo.");

            RuleFor(x => x.MontoFianza)
                .GreaterThanOrEqualTo(0).WithMessage("El monto de fianza no puede ser negativo.");

            RuleFor(x => x.NumeroHES)
                .GreaterThanOrEqualTo(0).WithMessage("El número HES debe ser positivo.");

            RuleFor(x => x.NumeroFactura)
                .NotEmpty().WithMessage("El número de factura es requerido.");

            RuleFor(x => x.ValorFacturadoNeto)
                .GreaterThanOrEqualTo(0).WithMessage("El valor facturado no puede ser negativo.");
        }
    }
}
