using FluentValidation;
using nest.core.aplicacion.general.Departamentos.Commands;

namespace nest.core.aplicacion.general.Departamentos.Behaviors
{
    public class DepartamentoCrearValidator : AbstractValidator<DepartamentoCrearCommand>
    {
        public DepartamentoCrearValidator()
        {
            Include(new DepartamentoGenericValidator<DepartamentoCrearCommand>());
        }
    }
}
