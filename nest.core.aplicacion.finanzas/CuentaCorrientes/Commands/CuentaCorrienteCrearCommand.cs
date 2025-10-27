using MediatR;
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
    ) : IRequest<CuentaCorriente>, ICuentaCorrienteGenericCommand;
}
