using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;

namespace nest.core.aplicacion.finanzas.CuentaCorriente.Commands
{
    public sealed record CuentaCorrienteModificarCommand(
        int Id,
        int EmpresaId,
        string Nombre,
        string NombreCorto,
        bool Activo,
        string CuentaNumero,
        int EntidadFinancieraId,
        long CuentaContableId
    ) : IRequest<CuentaCorriente>, ICommandBase;
}
