using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using System.Linq;

namespace nest.core.infraestructura.mantto
{
    public class OrdenTrabajoPersonalRepository : CrudRepositoryBase<OrdenTrabajoPersonal, OrdenTrabajoPersonalCrearDto, long>, IOrdenTrabajoPersonalRepository
    {
        public OrdenTrabajoPersonalRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<OrdenTrabajoPersonal> Query()
        {
            return base.Query()
                .Include(x => x.Persona);
        }

        public async Task<OrdenTrabajoPersonal> ObtenerPorId(long id) => await GetByIdAsync(id);

        public Task<List<OrdenTrabajoPersonal>> ObtenerPorIds(List<long> ids) => GetByIdsAsync(ids);

        public async Task<List<OrdenTrabajoPersonal>> ObtenerPorCabecera(long ordenTrabajoCabeceraId)
        {
            return await Query()
                .Where(x => x.OrdenTrabajoCabeceraId == ordenTrabajoCabeceraId)
                .ToListAsync();
        }

        public Task<OrdenTrabajoPersonal> Agregar(OrdenTrabajoPersonalCrearDto dto) => AddAsync(dto);

        public async Task<OrdenTrabajoPersonal[]> AgregarRange(OrdenTrabajoPersonalCrearDto[] dto)
        {
            OrdenTrabajoPersonal[] results = await AddRangeAsync(dto);
            List<OrdenTrabajoPersonal> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }

        public Task<OrdenTrabajoPersonal> Modificar(long id, OrdenTrabajoPersonalCrearDto dto) => UpdateAsync(id, dto);

        public async Task<OrdenTrabajoPersonal[]> ModificarRange((long id, OrdenTrabajoPersonalCrearDto dto)[] dto)
        {
            OrdenTrabajoPersonal[] results = await UpdateRangeAsync(dto);
            List<OrdenTrabajoPersonal> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }

        public Task Eliminar(long id) => DeleteAsync(id);

        public Task EliminarRange(long[] ids) => DeleteRangeAsync(ids);

        public async Task<OrdenTrabajoPersonal[]> FusionarRange(OrdenTrabajoPersonal[] originalEntities, (long id, OrdenTrabajoPersonalCrearDto dto)[] dto)
        {
            OrdenTrabajoPersonal[] results = await MergeRangeAsync(originalEntities, dto);
            List<OrdenTrabajoPersonal> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }
    }
}
