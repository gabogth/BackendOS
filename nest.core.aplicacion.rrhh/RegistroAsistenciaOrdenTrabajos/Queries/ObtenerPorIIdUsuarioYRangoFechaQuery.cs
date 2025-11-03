using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Queries
{    public sealed record ObtenerPorIIdUsuarioYRangoFechaQuery(
        string UsuarioId, 
        DateTime fechaInicio, 
        DateTime fechaFin
    ) : IRequest<List<RegistroAsistencia>>, IQueryBase;
}
