using AutoMapper;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.rrhh
{
    public class HorarioDetalleEventoRepository : CrudRepositoryBase<HorarioDetalleEvento, HorarioDetalleEventoCrearDto, long>, IHorarioDetalleEventoRepository
    {
        public HorarioDetalleEventoRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }
        public Task<HorarioDetalleEvento> ObtenerPorId(long id) => GetByIdAsync(id);
        public Task<List<HorarioDetalleEvento>> ObtenerPorIds(List<long> ids) => GetByIdsAsync(ids);
        public Task<List<HorarioDetalleEvento>> ObtenerTodos() => GetAllAsync();
        public async Task<HorarioDetalleEvento> Agregar(HorarioDetalleEventoCrearDto entidad) => await this.AddAsync(entidad);
        public async Task<HorarioDetalleEvento[]> AgregarRange(HorarioDetalleEventoCrearDto[] entidad)
        {
            HorarioDetalleEvento[] results = await this.AddRangeAsync(entidad);
            List<HorarioDetalleEvento> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }
        public async Task<HorarioDetalleEvento> Modificar(long id, HorarioDetalleEventoCrearDto entidad) => await this.UpdateAsync(id, entidad);
        public async Task<HorarioDetalleEvento[]> ModificarRange((long id, HorarioDetalleEventoCrearDto entidad)[] entidad)
        {
            HorarioDetalleEvento[] results = await this.UpdateRangeAsync(entidad);
            List<HorarioDetalleEvento> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }
        public async Task<HorarioDetalleEvento[]> FusionarRange(HorarioDetalleEvento[] originalEntities, (long id, HorarioDetalleEventoCrearDto entidad)[] entidad)
        {
            HorarioDetalleEvento[] results = await this.MergeRangeAsync(originalEntities, entidad);
            List<HorarioDetalleEvento> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }
        public async Task Eliminar(long id) => await this.DeleteAsync(id);
        public async Task EliminarRange(long[] ids) => await this.DeleteRangeAsync(ids);
    }
}
