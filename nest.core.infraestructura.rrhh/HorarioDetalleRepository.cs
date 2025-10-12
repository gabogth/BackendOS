using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.rrhh
{
    public class HorarioDetalleRepository : CrudRepositoryBase<HorarioDetalle, HorarioDetalleCrearDto, long>, IHorarioDetalleRepository
    {
        public HorarioDetalleRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }

        protected override IQueryable<HorarioDetalle> Query() => context.HorarioDetalles
            .AsNoTracking()
            .Include(x => x.HorarioDetalleEventos);
        public Task<HorarioDetalle> ObtenerPorId(long id) => GetByIdAsync(id);
        public Task<List<HorarioDetalle>> ObtenerPorIds(List<long> ids) => GetByIdsAsync(ids);
        public Task<List<HorarioDetalle>> ObtenerTodos() => GetAllAsync();
        public Task<HorarioDetalle> Agregar(HorarioDetalleCrearDto entidad) => this.AddAsync(entidad);
        public async Task<HorarioDetalle[]> AgregarRange(HorarioDetalleCrearDto[] entidad)
        {
            HorarioDetalle[] results = await this.AddRangeAsync(entidad);
            List<HorarioDetalle> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }
        public Task<HorarioDetalle> Modificar(long id, HorarioDetalleCrearDto entidad) => this.UpdateAsync(id, entidad);
        public async Task<HorarioDetalle[]> ModificarRange((long id, HorarioDetalleCrearDto entidad)[] entidad)
        {
            HorarioDetalle[] results = await this.UpdateRangeAsync(entidad);
            List<HorarioDetalle> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }
        public Task Eliminar(long id) => this.DeleteAsync(id);
        public Task EliminarRange(long[] ids) => this.DeleteRangeAsync(ids);
        public async Task<HorarioDetalle[]> FusionarRange(HorarioDetalle[] originalEntities, (long id, HorarioDetalleCrearDto entidad)[] entidad)
        {
            HorarioDetalle[] results = await this.MergeRangeAsync(originalEntities, entidad);
            List<HorarioDetalle> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }
    }
}
