using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands
{
    public record OrdenTrabajoDetalleCrearCommand(
        int EmpresaId,
        long OrdenTrabajoCabeceraId,
        long UbicacionTecnicaId,
        int LaborId,
        int HorasProyectadas,
        int HorasEjecutadas,
        string? Descripcion,
        OrdenTrabajoDetalleEstado Estado
    ) : IRequest<OrdenTrabajoDetalle>, IOrdenTrabajoDetalleGenericCommand;
}
