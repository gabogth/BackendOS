using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.Security.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities
{
    public class RegistroAsistenciaAdjunto : IEntity<long>, IAuditable, ITenantEntity
    {
        public long Id { get; set; }
        public int EmpresaId { get; set; }
        public long AdjuntoId { get; set; }
        public RegistroAsistencia RegistroAsistencia { get; set; }
        public Adjunto Adjunto { get; set; }

    }
}
