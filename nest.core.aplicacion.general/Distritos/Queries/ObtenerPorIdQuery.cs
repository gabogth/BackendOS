using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.Distritos.Queries
{
    public sealed record ObtenerPorIdQuery(
        int Id
    ) : IRequest<Distrito>, IQueryBase;
}
