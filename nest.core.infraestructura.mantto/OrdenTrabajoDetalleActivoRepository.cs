using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using System.Linq;

namespace nest.core.infraestructura.mantto
{
    public class OrdenTrabajoDetalleActivoRepository : CrudRepositoryBase<OrdenTrabajoDetalleActivo, long>, IOrdenTrabajoDetalleActivoRepository
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

        public Task<List<OrdenTrabajoDetalleActivo>> ObtenerPorIds(List<long> ids) => GetByIdsAsync(ids);

        public async Task<List<OrdenTrabajoDetalleActivo>> ObtenerPorDetalle(long ordenTrabajoDetalleId)
        {
            return await Query()
                .Where(x => x.Id == ordenTrabajoDetalleId)
                .ToListAsync();
        }

        public Task<OrdenTrabajoDetalleActivo> Agregar(OrdenTrabajoDetalleActivo dto) => AddAsync(dto);

        public async Task<OrdenTrabajoDetalleActivo[]> AgregarRange(OrdenTrabajoDetalleActivo[] dto)
        {
            OrdenTrabajoDetalleActivo[] results = await AddRangeAsync(dto);
            List<OrdenTrabajoDetalleActivo> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }

        public Task<OrdenTrabajoDetalleActivo> Modificar(OrdenTrabajoDetalleActivo dto) => UpdateAsync(dto);

        public async Task<OrdenTrabajoDetalleActivo[]> ModificarRange(OrdenTrabajoDetalleActivo[] dto)
        {
            OrdenTrabajoDetalleActivo[] results = await UpdateRangeAsync(dto);
            List<OrdenTrabajoDetalleActivo> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }

        public Task Eliminar(long id) => DeleteAsync(id);

        public Task EliminarRange(long[] ids) => DeleteRangeAsync(ids);

        public async Task<OrdenTrabajoDetalleActivo[]> FusionarRange(OrdenTrabajoDetalleActivo[] originalEntities, OrdenTrabajoDetalleActivo[] dto)
        {
            OrdenTrabajoDetalleActivo[] results = await MergeRangeAsync(originalEntities, dto);
            List<OrdenTrabajoDetalleActivo> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }
    }
}
