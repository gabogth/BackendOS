using System.Collections.Generic;
using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<OrdenTrabajoPersonal>>, IQueryBase;
}
