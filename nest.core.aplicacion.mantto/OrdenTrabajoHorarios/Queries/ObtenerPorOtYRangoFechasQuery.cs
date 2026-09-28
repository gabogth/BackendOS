using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities.Views;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Queries
{
    public sealed record ObtenerPorOtYRangoFechasQuery(
        long OrdenTrabajoCabeceraId, 
        DateOnly Inicio, 
        DateOnly Fin
    ) : IRequest<List<OrdenTrabajoHorarioView_PorOTRangoFechas>>, IQueryBase;
}
