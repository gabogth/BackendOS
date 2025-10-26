using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContableTipos.Commands
{
    public sealed record CuentaContableTipoCrearCommand(
        string Nombre,
        string NombreCorto,
        bool Activo
    ) : IRequest<CuentaContableTipo>, ICommandBase;
}
