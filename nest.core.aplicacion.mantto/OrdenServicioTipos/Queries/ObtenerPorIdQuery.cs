using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioTipos.Queries
{
    public sealed record ObtenerPorIdQuery(short Id) : IRequest<OrdenServicioTipo>, IQueryBase;
}
