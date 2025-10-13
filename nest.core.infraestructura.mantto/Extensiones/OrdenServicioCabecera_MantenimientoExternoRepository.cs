using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.mantto.Extensiones
{
    public class OrdenServicioCabecera_MantenimientoExternoRepository : OrdenServicioCabeceraRepository, IOrdenServicioCabecera_MantenimientoExternoRepository
    {
        public OrdenServicioCabecera_MantenimientoExternoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<OrdenServicioCabecera> Query()
        {
            return base.Query()
                .Include(x => x.OrdenServicioTipo)
                .Include(x => x.OrdenTrabajoCabeceras)
                .Include(x => x.OrdenServicioMantenimientoExterno)
                .Include(x => x.OrdenServicioMantenimientoExterno).ThenInclude(x => x.ClientePlanner)
                .Include(x => x.OrdenServicioMantenimientoExterno).ThenInclude(x => x.ActaConformidad)
                .Include(x => x.OrdenServicioMantenimientoExterno).ThenInclude(x => x.Cliente)
                .Include(x => x.OrdenServicioMantenimientoExterno).ThenInclude(x => x.ClienteSupervisor)
                .Include(x => x.OrdenServicioMantenimientoExterno).ThenInclude(x => x.Contrato)
                .Include(x => x.OrdenServicioMantenimientoExterno).ThenInclude(x => x.Contrato).ThenInclude(x => x.Detalles)
                .Include(x => x.OrdenServicioMantenimientoExterno).ThenInclude(x => x.MantenimientoTipo)
                .Include(x => x.OrdenServicioMantenimientoExterno).ThenInclude(x => x.Moneda);
        }
    }
}
