using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioCabeceras.Behaviors
{
    public class OrdenServicioCabeceraCrearValidator : AbstractValidator<OrdenServicioCabeceraCrearCommand>
    {
        public OrdenServicioCabeceraCrearValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("La empresa es requerida.");

            RuleFor(x => x.OrdenServicioTipoId)
                .GreaterThan((short)0).WithMessage("El tipo de orden de servicio es requerido.");

            RuleFor(x => x.CodigoOrdenInterna)
                .NotEmpty().WithMessage("El código interno es requerido.")
                .MaximumLength(50).WithMessage("El código interno no debe exceder 50 caracteres.");

            RuleFor(x => x.CodigoReferencial)
                .NotEmpty().WithMessage("El código referencial es requerido.")
                .MaximumLength(50).WithMessage("El código referencial no debe exceder 50 caracteres.");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción es requerida.");

            RuleFor(x => x.FechaInicial)
                .LessThanOrEqualTo(x => x.FechaFinal).WithMessage("La fecha inicial debe ser menor o igual a la fecha final.");

            RuleFor(x => x.FechaEntrega)
                .GreaterThanOrEqualTo(x => x.FechaInicial).WithMessage("La fecha de entrega debe ser posterior a la fecha inicial.");
        }
    }
}
