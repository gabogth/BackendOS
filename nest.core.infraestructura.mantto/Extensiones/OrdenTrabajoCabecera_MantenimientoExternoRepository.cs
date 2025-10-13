using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoMantenimientoExternoEntities;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.mantto.Extensiones
{
    public class OrdenTrabajoCabecera_MantenimientoExternoRepository : OrdenTrabajoCabeceraRepository, IOrdenTrabajoCabecera_MantenimientoExternoRepository
    {
        public OrdenTrabajoCabecera_MantenimientoExternoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<OrdenTrabajoCabecera> Query()
        {
            return base.Query()
                .Include(x => x.OrdenTrabajoDetalles).ThenInclude(x => x.OrdenTrabajoDetalleActivo)
                .Include(x => x.Personales)
                .Include(x => x.Personales).ThenInclude(x => x.Persona)
                .Include(x => x.OrdenTrabajoDetalles).ThenInclude(x => x.OrdenTrabajoDetalleActivo).ThenInclude(x => x.Activo);
        }  
    }
}
