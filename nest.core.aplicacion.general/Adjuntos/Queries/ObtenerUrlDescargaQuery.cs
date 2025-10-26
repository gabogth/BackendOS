using MediatR;
using nest.core.aplicacion.utils.Queries;

namespace nest.core.aplicacion.general.Adjuntos.Queries
{
    public sealed record ObtenerUrlDescargaQuery(long Id) : IRequest<string>, IQueryBase;
}
