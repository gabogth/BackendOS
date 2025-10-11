using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using System.Linq;

namespace nest.core.infraestructura.mantto
{
    public class OrdenTrabajoDetalleRepository : CrudRepositoryBase<OrdenTrabajoDetalle, OrdenTrabajoDetalleCrearDto, long>, IOrdenTrabajoDetalleRepository
    {
        public OrdenTrabajoDetalleRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<OrdenTrabajoDetalle> Query()
        {
            return base.Query()
                .Include(x => x.Labor)
                .Include(x => x.UbicacionTecnica);
        }

        public async Task<OrdenTrabajoDetalle> ObtenerPorId(long id) => await GetByIdAsync(id);

        public async Task<List<OrdenTrabajoDetalle>> ObtenerPorCabecera(long ordenTrabajoCabeceraId)
        {
            return await Query()
                .Where(x => x.OrdenTrabajoCabeceraId == ordenTrabajoCabeceraId)
                .ToListAsync();
        }

        public Task<OrdenTrabajoDetalle> Agregar(OrdenTrabajoDetalleCrearDto dto) => AddAsync(dto);

        public Task<OrdenTrabajoDetalle> Modificar(long id, OrdenTrabajoDetalleCrearDto dto) => UpdateAsync(id, dto);

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
