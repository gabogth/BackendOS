using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioTipos.Commands
{
    public sealed record OrdenServicioTipoCrearCommand(
        string Nombre,
        string NombreCorto,
        bool Estado
    ) : IRequest<OrdenServicioTipo>, ICommandBase;
}
