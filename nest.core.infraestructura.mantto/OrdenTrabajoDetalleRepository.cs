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

        public Task<List<OrdenTrabajoDetalle>> ObtenerPorIds(List<long> ids) => GetByIdsAsync(ids);

        public async Task<List<OrdenTrabajoDetalle>> ObtenerPorCabecera(long ordenTrabajoCabeceraId)
        {
            return await Query()
                .Where(x => x.OrdenTrabajoCabeceraId == ordenTrabajoCabeceraId)
                .ToListAsync();
        }

        public Task<OrdenTrabajoDetalle> Agregar(OrdenTrabajoDetalleCrearDto dto) => AddAsync(dto);

        public async Task<OrdenTrabajoDetalle[]> AgregarRange(OrdenTrabajoDetalleCrearDto[] dto)
        {
            OrdenTrabajoDetalle[] results = await AddRangeAsync(dto);
            List<OrdenTrabajoDetalle> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }

        public Task<OrdenTrabajoDetalle> Modificar(long id, OrdenTrabajoDetalleCrearDto dto) => UpdateAsync(id, dto);

        public async Task<OrdenTrabajoDetalle[]> ModificarRange((long id, OrdenTrabajoDetalleCrearDto dto)[] dto)
        {
            OrdenTrabajoDetalle[] results = await UpdateRangeAsync(dto);
            List<OrdenTrabajoDetalle> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }

        public Task Eliminar(long id) => DeleteAsync(id);

        public Task EliminarRange(long[] ids) => DeleteRangeAsync(ids);

        public async Task<OrdenTrabajoDetalle[]> FusionarRange(OrdenTrabajoDetalle[] originalEntities, (long id, OrdenTrabajoDetalleCrearDto dto)[] dto)
        {
            OrdenTrabajoDetalle[] results = await MergeRangeAsync(originalEntities, dto);
            List<OrdenTrabajoDetalle> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }
    }
}
