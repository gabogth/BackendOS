using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using System.Linq;

namespace nest.core.infraestructura.mantto
{
    public class OrdenTrabajoDetalleActivoRepository : CrudRepositoryBase<OrdenTrabajoDetalleActivo, OrdenTrabajoDetalleActivoCrearDto, long>, IOrdenTrabajoDetalleActivoRepository
    {
        public OrdenTrabajoDetalleActivoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<OrdenTrabajoDetalleActivo> Query()
        {
            return base.Query()
                .Include(x => x.OrdenTrabajoDetalle)
                    .ThenInclude(d => d.Labor)
                .Include(x => x.OrdenTrabajoDetalle)
                    .ThenInclude(d => d.UbicacionTecnica)
                .Include(x => x.Activo);
        }

        public async Task<OrdenTrabajoDetalleActivo> ObtenerPorId(long id) => await GetByIdAsync(id);

        public async Task<List<OrdenTrabajoDetalleActivo>> ObtenerPorDetalle(long ordenTrabajoDetalleId)
        {
            return await Query()
                .Where(x => x.Id == ordenTrabajoDetalleId)
                .ToListAsync();
        }

        public Task<OrdenTrabajoDetalleActivo> Agregar(OrdenTrabajoDetalleActivoCrearDto dto) => AddAsync(dto);

        public Task<OrdenTrabajoDetalleActivo> Modificar(long id, OrdenTrabajoDetalleActivoCrearDto dto) => UpdateAsync(id, dto);

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
