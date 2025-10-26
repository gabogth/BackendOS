using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands
{
    public record OrdenTrabajoDetalleActivoCrearCommand(
        int EmpresaId,
        long OrdenTrabajoDetalleId,
        long ActivoId
    ) : IRequest<OrdenTrabajoDetalleActivo>, ICommandBase;
}
