using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;

namespace nest.core.aplicacion.rrhh.Horarios.Queries
{
    public sealed record ObtenerPorIdQuery(int Id) : IRequest<HorarioCabecera>, IQueryBase;
}
