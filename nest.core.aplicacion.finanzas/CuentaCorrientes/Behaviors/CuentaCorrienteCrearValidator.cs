using FluentValidation;
using nest.core.aplicacion.finanzas.CuentaCorrientes.Commands;
using nest.core.aplicacion.finanzas.CuentaCorrientes.Generics;

namespace nest.core.aplicacion.finanzas.CuentaCorrientes.Behaviors
{
    public class CuentaCorrienteCrearValidator : AbstractValidator<CuentaCorrienteCrearCommand>
    {
        public CuentaCorrienteCrearValidator()
        {
            Include(new CuentaCorrienteGenericValidator<CuentaCorrienteCrearCommand>());
        }
    }
}
