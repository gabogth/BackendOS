using System.Collections.Generic;
using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Queries
{
    public sealed record ObtenerTodosQuery
        : IRequest<List<OrdenTrabajoCabecera>>, IQueryBase;
}
