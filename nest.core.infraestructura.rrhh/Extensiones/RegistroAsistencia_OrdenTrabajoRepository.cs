using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.rrhh.Extensiones
{
    public class RegistroAsistencia_OrdenTrabajoRepository : RegistroAsistenciaRepository, IRegistroAsistencia_OrdenTrabajoRepository
    {
        public RegistroAsistencia_OrdenTrabajoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<RegistroAsistencia> Query()
        {
            return base.Query()
                .Include(x => x.RegistroAsistenciaOrdenTrabajo)
                .Include(x => x.RegistroAsistenciaOrdenTrabajo).ThenInclude(x => x.OrdenTrabajoCabecera)
                .Include(x => x.RegistroAsistenciaAdjunto)
                .Include(x => x.RegistroAsistenciaAdjunto).ThenInclude(x => x.Adjunto);
        }
    }
}
