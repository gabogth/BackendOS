using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.LaborEntities;

namespace nest.core.aplicacion.mantto.Labores.Queries
{
    public sealed record ObtenerPorIdQuery(
        int Id
    ) : IRequest<Labor>, IQueryBase;
}
