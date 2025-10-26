using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.DistritoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.aplicacion.general.Distritos.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<Distrito>>, IQueryBase;
}
