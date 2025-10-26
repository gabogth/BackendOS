using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionActivos.Commands
{
    public record UbicacionActivoCrearCommand(
        int EmpresaId,
        long ActivoId,
        long UbicacionTecnicaId,
        string? Comentario,
        long? ContratoCabeceraId,
        DateTime FechaIngreso,
        DateTime? FechaSalida
    ) : IRequest<UbicacionActivo>, ICommandBase;
}
