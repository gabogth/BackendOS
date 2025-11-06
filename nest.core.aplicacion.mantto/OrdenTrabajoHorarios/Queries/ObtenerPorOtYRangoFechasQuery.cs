using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Queries
{
    public sealed record ObtenerPorOtYRangoFechasQuery(
        long OrdenTrabajoCabeceraId, 
        DateOnly Inicio, 
        DateOnly Fin
    ) : IRequest<List<OrdenTrabajoHorario>>, IQueryBase;
}
