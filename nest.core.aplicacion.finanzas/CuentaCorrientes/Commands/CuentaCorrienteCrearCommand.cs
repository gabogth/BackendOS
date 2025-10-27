using MediatR;
using nest.core.aplicacion.finanzas.CuentaCorrientes.Interfaces;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;

namespace nest.core.aplicacion.finanzas.CuentaCorrientes.Commands
{
    public sealed record CuentaCorrienteCrearCommand(
        int EmpresaId,
        string Nombre,
        string NombreCorto,
        bool Activo,
        string CuentaNumero,
        int EntidadFinancieraId,
        long CuentaContableId
    ) : IRequest<CuentaCorriente>, ICommandBase, ICuentaCorrienteGenericCommand;
}
