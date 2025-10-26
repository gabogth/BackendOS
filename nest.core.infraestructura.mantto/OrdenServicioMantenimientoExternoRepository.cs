using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.mantto
{
    public class OrdenServicioMantenimientoExternoRepository : CrudRepositoryBase<OrdenServicioMantenimientoExterno, long>, IOrdenServicioMantenimientoExternoRepository
    {
        public OrdenServicioMantenimientoExternoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<OrdenServicioMantenimientoExterno> Query()
        {
            return base.Query()
                .Include(x => x.Cliente)
                .Include(x => x.ClienteSupervisor)
                .Include(x => x.Contrato)
                .Include(x => x.ClientePlanner)
                .Include(x => x.ActaConformidad)
                .Include(x => x.Moneda)
                .Include(x => x.MantenimientoTipo)
                .Include(x => x.OrdenServicioCabecera);
        }

        public Task<OrdenServicioMantenimientoExterno> ObtenerPorId(long id) => GetByIdAsync(id);

        public Task<List<OrdenServicioMantenimientoExterno>> ObtenerTodos() => GetAllAsync();

        public Task<OrdenServicioMantenimientoExterno> Agregar(OrdenServicioMantenimientoExterno entity) => AddAsync(entity);

        public Task<OrdenServicioMantenimientoExterno> Modificar(OrdenServicioMantenimientoExterno entity) => UpdateAsync(entity);

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
